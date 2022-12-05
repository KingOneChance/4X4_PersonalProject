using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LobbyScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject ScoreMgr;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        if (FindObjectOfType<ScoreManager>() == null)
            Instantiate(ScoreMgr);
       
        score.text = "Best Score \n" + ScoreManager.Instance.score.ToString()+ " % ";
    }
    public void On_ClickToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
