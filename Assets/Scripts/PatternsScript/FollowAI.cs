using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    GameObject player;
    float timer = 0;
    float AiSpeed = 1.5f;
    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        Vector2 Pos = new Vector2(-0.5f, -3.5f);
        player = FindObjectOfType<PlayerMove>().gameObject;
        gameObject.transform.position = Pos;

        StartCoroutine(Co_FollowPlayer());
    }
    private void OnEnable()
    {
        Vector2 Pos = new Vector2(-0.5f, -3.5f);
        player = FindObjectOfType<PlayerMove>().gameObject;
        StartCoroutine(Co_FollowPlayer());
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (AiSpeed > 0.5f) AiSpeed = AiSpeed - (timer / 10) * 0.1f;
    }

    IEnumerator Co_FollowPlayer()
    {
        while (player.transform.position.x != gameObject.transform.position.x || player.transform.position.y != gameObject.transform.position.y)
        {
            if (player.transform.position.x != gameObject.transform.position.x)
            {
                if (player.transform.position.x > gameObject.transform.position.x)
                    gameObject.transform.Translate(Vector3.right / 2);

                else if (player.transform.position.x < gameObject.transform.position.x)
                    gameObject.transform.Translate(Vector3.left / 2);
            }
            yield return new WaitForSeconds(AiSpeed);
            yield return null;
            if (player.transform.position.y != gameObject.transform.position.y)
            {
                if (player.transform.position.y > gameObject.transform.position.y)
                    gameObject.transform.Translate(Vector3.up / 2);

                else if (player.transform.position.y < gameObject.transform.position.y)
                    gameObject.transform.Translate(Vector3.down / 2);
            }
            yield return new WaitForSeconds(AiSpeed);
            yield return null;
        }
        yield return null;
        spawner.Pattern4_BossReSpawn();
        gameObject.SetActive(false);
    }
}
