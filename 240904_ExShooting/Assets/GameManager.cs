using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    EnemyManager enemyManager;
    [SerializeField] GameObject panel; //�⺻���� ���� ���� ���� ����â. �Ͻ�����, �¸�, �й� ��� �̷��� ������ ���� �г��� ����
    [SerializeField] GameObject[] panelModes; //�� �г� �� �г� �� ���빰�� �ٷ�� ������Ʈ. ���� Pause, Win, lose, �������� ���� �߰��� Ȯ��â�̴�.

    int enemyCount; //���� ���� Ȯ�� ����
    int playerLifeCount; //�÷��̾� �����. ���ӸŴ����� �ؾ��ϴ°� �´ٰ� �����ϰ�, �ڵ� �帧�� ���� �Ŵ����� �δ� ���� ���ٰ� �Ǵ�
    int stageScore; //���� ���������� ������

    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Update()
    {
        PauseKeyDown();
    }

    void PauseKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }

    public void SetEnemyCount(int transValue)
    {
        enemyCount = transValue;
        if(enemyManager.GetAllWavesCompleted() && enemyCount == 0)
        {
            GameClear();
        }
    }
    void GamePause()
    {
        Debug.Log("��� �����մϴ�");
        panel.SetActive(true); // actionPanel
        panelModes[0].SetActive(true); // win. �̰ܼ� ������ �Լ��̹Ƿ�
        GetComponent<UI_SelectManager>().UpdateButtons("Pause");
        GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    void GameClear()
    {
        Debug.Log("��ġ����..? " + enemyCount.ToString());
        DataManager.instance.SetPlayData("Test", stageScore);
        panel.SetActive(true); // actionPanel
        panelModes[1].SetActive(true); // win. �̰ܼ� ������ �Լ��̹Ƿ�
        GetComponent<UI_SelectManager>().UpdateButtons("Win");
        GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    void GameOver()
    {
        Debug.Log("�й�");
        DataManager.instance.SetPlayData("Test", stageScore);
        panel.SetActive(true); // actionpanel
        panelModes[2].SetActive(true); //lose. ���� ������ �Լ�
        GetComponent<UI_SelectManager>().UpdateButtons("Lose");
        GetComponent<UI_SelectManager>().ButtonFocus();

        Time.timeScale = 0.0f;
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
