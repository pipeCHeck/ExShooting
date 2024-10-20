using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EnemyManager enemyManager;
    int enemyCount; //���� ���� Ȯ�� ����
    int playerLifeCount; //�÷��̾� �����. ���ӸŴ����� �ؾ��ϴ°� �´ٰ� �����ϰ�, �ڵ� �帧�� ���� �Ŵ����� �δ� ���� ���ٰ� �Ǵ�
    int stageScore; //���� ���������� ������

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
        Debug.Log("��ġ����..? " + enemyCount.ToString());
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

    //���� ������ �������� Ư�� �̺�Ʈ�� �ǽ��ؼ� �ش� �������� �����Ǿ� ����
    public void SetStageScore(int scoreValue)
    {
        stageScore += scoreValue;
    }
}
