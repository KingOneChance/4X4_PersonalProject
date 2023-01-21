using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject[] Pattern;
    [SerializeField] private GameMgr gameMgr;
    [SerializeField] private Slider percentGage;
    [SerializeField] private Text text;
    [SerializeField] private float runTime;
    [SerializeField] private float nowTime;
    [SerializeField] private float insttime;
    [SerializeField] private float pattern1Time;
    [SerializeField] private float pattern2Time;
    [SerializeField] private float pattern3Time;
    List<GameObject> objList = new List<GameObject>();
    List<GameObject> objPool1 = new List<GameObject>();
    List<GameObject> objPool2 = new List<GameObject>();
    List<GameObject> objPool3 = new List<GameObject>();
    [SerializeField] int patternCount = 0;
    bool recycle;
    void Start()
    {
        insttime = 1f;
        GameObject pool = new GameObject("Pool1");
        objList.Add(pool);
        StartCoroutine(Co_Pattern(insttime, pattern1Time));
    }
    private void Update()
    {
        if (ScoreManager.Instance.score< (int)percentGage.value)
            ScoreManager.Instance.score = (int)percentGage.value;
        if (gameMgr.gameOver == true) return;
        if (nowTime > runTime)
        {
            gameMgr.GameWine();
            return;
        }
        nowTime += Time.deltaTime;
        percentGage.value = nowTime;
        text.text = (int)percentGage.value + " ... % ";

    }
    private void PatternDone()
    {
        patternCount++;
        if (patternCount == 1) Pattern2();
        if (patternCount == 2) Pattern3();
        if (patternCount == 3) Pattern4();
    }
    private void Pattern2()
    {
        insttime = 0.7f;
        GameObject pool = new GameObject("Pool2");
        objList.Add(pool);
        StartCoroutine(Co_Pattern2(insttime, pattern2Time));
    }
    private void Pattern3()
    {
        insttime = 1f;
        GameObject pool = new GameObject("Pool3");
        objList.Add(pool);
        StartCoroutine(Co_Pattern3(insttime, pattern3Time));
    }
    private void Pattern4()
    {
        Boss = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
    }
    public void Pattern4_BossReSpawn()
    {
        Debug.Log("»ì·Á");
        Boss = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
    }
    WaitForFixedUpdate initiTime = new WaitForFixedUpdate();
    IEnumerator Co_Pattern(float delayTime, float endTime)
    {
        while (nowTime < endTime)
        {
            GameObject Enemy;
            recycle = false;
            if (objPool1.Count == 0)
            {
                Enemy = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
                Enemy.transform.SetParent(objList[patternCount].transform);
                objPool1.Add(Enemy);
            }
            else
            {
                for (int i = 0; i < objPool1.Count; i++)
                {
                    if (objPool1[i].activeSelf == false)
                    {
                        objPool1[i].SetActive(true);
                        recycle = true;
                        break;
                    }
                }
                if (recycle == false)
                {
                    Enemy = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
                    Enemy.transform.SetParent(objList[patternCount].transform);
                    objPool1.Add(Enemy);
                }
            }
            yield return new WaitForSeconds(delayTime);
        }
        PatternDone();
    }
    IEnumerator Co_Pattern2(float delayTime, float endTime)
    {
        while (nowTime < endTime)
        {
            GameObject Enemy;
            recycle = false;
            if (objPool2.Count == 0)
            {
                Enemy = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
                Enemy.transform.SetParent(objList[patternCount].transform);
                objPool2.Add(Enemy);
            }
            else
            {
                for (int i = 0; i < objPool2.Count; i++)
                {
                    if (objPool2[i].activeSelf == false)
                    {
                        objPool2[i].SetActive(true);
                        recycle = true;
                        break;
                    }
                }
                if (recycle == false)
                {
                    Enemy = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
                    Enemy.transform.SetParent(objList[patternCount].transform);
                    objPool2.Add(Enemy);
                }
            }
            yield return new WaitForSeconds(delayTime);
        }
        PatternDone();
    }
    IEnumerator Co_Pattern3(float delayTime, float endTime)
    {
        while (nowTime < endTime)
        {
            GameObject Enemy;
            recycle = false;
            if (objPool3.Count == 0)
            {
                Enemy = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
                Enemy.transform.SetParent(objList[patternCount].transform);
                objPool3.Add(Enemy);
            }
            else
            {
                for (int i = 0; i < objPool3.Count; i++)
                {
                    if (objPool3[i].activeSelf == false)
                    {
                        objPool3[i].SetActive(true);
                        recycle = true;
                        break;
                    }
                }
                if (recycle == false)
                {
                    Enemy = Instantiate(Pattern[patternCount], gameObject.transform.position, Quaternion.identity);
                    Enemy.transform.SetParent(objList[patternCount].transform);
                    objPool3.Add(Enemy);
                }
            }
            yield return new WaitForSeconds(delayTime);
        }
        PatternDone();
    }
}
