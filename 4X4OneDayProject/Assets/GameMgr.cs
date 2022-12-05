using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMgr : MonoBehaviour
{
    [SerializeField] public PlayerMove player;
    [SerializeField] public Spawner spawner;
    [SerializeField] public GameObject winLogo;
    [SerializeField] public GameObject loseLogo;
    [SerializeField] public bool gameOver;
    [SerializeField] public bool gameWin;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        spawner = FindObjectOfType<Spawner>();
    }
    public void GameOver()
    {
        player = null;
        spawner = null;
        gameOver = true;
        loseLogo.SetActive(true);
    }
    public void GameWine()
    {
        player = null;
        spawner = null;
        gameOver = true;
        gameWin = true;
        winLogo.SetActive(true);
    }
    private void Update()
    {
        if (gameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }

        else if (gameOver == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }
}
