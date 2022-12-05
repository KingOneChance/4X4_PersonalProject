using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Player,
    PointBlock,
    LineBlock,
}

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameMgr gameMgr;
    [SerializeField] int playerLife;
    ObjectType type;
    SpriteRenderer Render;
    float playerPosX;
    float playerPosY;
    Vector2 playerPos;
    bool hit;
 
    private void Start()
    {
        playerLife = 3;
        type = ObjectType.Player;
        playerPosX = 0.5f;
        playerPosY = 0.5f;
        playerPos = new Vector2(playerPosX, playerPosY);
        gameObject.transform.position = playerPos;
        Render = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (gameMgr.gameOver == true) return;
        if (playerLife <= 0)
        {
            gameMgr.GameOver();
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) playerPosY += 1;
        if (Input.GetKeyDown(KeyCode.DownArrow)) playerPosY -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow)) playerPosX += 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) playerPosX -= 1;

        if (playerPosX < -1.5f) playerPosX = 1.5f;
        else if (playerPosX > 1.5f) playerPosX = -1.5f;
        else if (playerPosY < -1.5f) playerPosY = 1.5f;
        else if (playerPosY > 1.5f) playerPosY = -1.5f;
        playerPos = new Vector2(playerPosX, playerPosY);
        gameObject.transform.position = playerPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hit == true) return;
        Debug.Log("??");
        if (collision.gameObject.tag == "Enemy") playerLife--;
        if (playerLife == 2) Render.color = Color.blue;
        if (playerLife == 1) Render.color = Color.red;

        StartCoroutine(Co_CamShake(0.2f));
    }

    IEnumerator Co_CamShake(float time)
    {
        hit = true;
        float shakeTime=0;
        Vector3 pos;
        while (shakeTime<time)
        {
            shakeTime += Time.deltaTime;
            pos = Random.insideUnitCircle;
            pos.z = -10;
            Camera.main.transform.position = pos;
            
          yield return null;
        }
        pos = new Vector3(0, 0, -10);
        Camera.main.transform.position = pos;
        yield return null;
        hit = false;
    }


}
