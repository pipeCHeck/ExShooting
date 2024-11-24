using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject weaponLevelUp; //������ ŰƮ�� �켱 ���Ӹ������� �־��µ�, ���� ������ ���� ���� �� ��ġ�� �ٲ� �� ����

    [SerializeField] GameObject panel; //�⺻���� ���� ���� ���� ����â. �Ͻ�����, �¸�, �й� ��� �̷��� ������ ���� �г��� ����
    [SerializeField] GameObject[] panelModes; //�� �г� �� �г� �� ���빰�� �ٷ�� ������Ʈ. ���� Pause, Win, lose, �������� ���� �߰��� Ȯ��â�̴�.

    int enemyCount; //���� ���� Ȯ�� ����. ���� ������ ����
    int playerLifeCount; //�÷��̾� �����. ���ӸŴ����� �ؾ��ϴ°� �´ٰ� �����ϰ�, �ڵ� �帧�� ���� �Ŵ����� �δ� ���� ���ٰ� �Ǵ�
    int stageScore; //���� ���������� ������

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        PauseKeyDown();
        AdminKey();
    }

    

    void PauseKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }

    void AdminKey()
    {
        //���ӿ��� �߻��ϴ� �̺�Ʈ�� Ư�� Ű�� ���� ������ ȣ���Ϸ��� �ǵ�. ���� ������ ŰƮ�� �����ϴ� �� �ۿ� ����
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 instanceVec = new Vector3(11f, 0, 0);
            GameObject instance = Instantiate(weaponLevelUp, instanceVec, transform.rotation);
            Destroy(instance, 10f);
        }
    }


    void GamePause()
    {
        Debug.Log("��� �����մϴ�");
        SetAciPanelState(0, true); // pause �г� Ȱ��ȭ
        //GetComponent<UI_SelectManager>().UpdateButtons("Pause");
        //GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    public void GameClear()
    {
        Debug.Log("��ġ����..? " + enemyCount.ToString());
        StartCoroutine(ShowResultPanel(1));
        //DataManager.instance.SetPlayData("Test", stageScore);
        //GetComponent<UI_SelectManager>().UpdateButtons("Win");
        //GetComponent<UI_SelectManager>().ButtonFocus();
    }

    public void GameOver()
    {
        Debug.Log("�й�");
        //DataManager.instance.SetPlayData("Test", stageScore);
        SetAciPanelState(2, true); //lose. ���� ������ �Լ�
        //GetComponent<UI_SelectManager>().UpdateButtons("Lose");
        //GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    //���� ����� ��Ȳ�� �´� ����� �����ֱ� ���� ���. ����� �¸��� ���� �־���
    IEnumerator ShowResultPanel(int panelArray)
    {
        yield return new WaitForSeconds(5f);
        SetAciPanelState(1, true);
        Time.timeScale = 0.0f;
    }

    //ActionPanel �� ���ϴ� �г� �� �������� �����Ӱ� ������ �� �ִ� ���
    public void SetAciPanelState(int panelIndex, bool state)
    {
        panel.SetActive(state);
        panelModes[panelIndex].SetActive(state);
    }

    public void GameEnd() // ���� �¸� Ȥ�� �й� ó��
    {

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

    public void SetPlayerLifeCount(int lifeValue) //���� ������ ���� ����
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
