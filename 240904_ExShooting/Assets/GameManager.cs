using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EnemyManager enemyManager;
    int enemyCount; //몬스터 잔존 확인 유무
    int playerLifeCount; //플레이어 목숨값. 게임매니저가 해야하는게 맞다고 생각하고, 코드 흐름상 게임 매니저에 두는 것이 낫다고 판단
    int stageScore; //현재 스테이지의 점수값

    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    public void SetEnemyCount(int transValue)
    {
        enemyCount = transValue;
        if(enemyManager.GetAllWavesCompleted() && enemyCount == 0)
        {
            GameEnd();
        }
    }

    void GameEnd()
    {
        Debug.Log("해치웠나..? " + enemyCount.ToString());
        //DataManager.instance.SetPlayData("Test", stageScore);
        DataManager.instance.SetPlayData("Test", 123);
        Debug.Log(DataManager.instance.scoreList[0].score);

        SceneManager.LoadScene("MainScene");
    }

    public void ResetEnemyCount()
    {
        enemyCount = 0;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public int GetPlayerLifeCount()
    {
        return playerLifeCount;
    }

    public void SetPlayerLifeCount(int lifeValue)
    {
        playerLifeCount = lifeValue;
    }

    public int GetStageScore()
    {
        return stageScore;
    }

    //추후 점수가 내려가는 특정 이벤트를 의식해서 해당 수식으로 구성되어 있음
    public void SetStageScore(int scoreValue)
    {
        stageScore += scoreValue;
    }
}
