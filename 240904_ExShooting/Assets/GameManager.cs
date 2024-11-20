using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject weaponLevelUp; //레벨업 키트를 우선 게임메이저에 넣었는데, 추후 구조에 의해 변경 시 위치가 바뀔 수 있음

    EnemyManager enemyManager;
    [SerializeField] GameObject panel; //기본적인 게임 씬의 설정 상태창. 일시정지, 승리, 패배 등등 이러한 옿션을 가진 패널을 뜻함
    [SerializeField] GameObject[] panelModes; //위 패널 및 패널 내 내용물을 다루는 오브젝트. 현재 Pause, Win, lose, 마지막은 추후 추가할 확인창이다.

    int enemyCount; //몬스터 잔존 확인 유무. 추후 없어질 예정
    int playerLifeCount; //플레이어 목숨값. 게임매니저가 해야하는게 맞다고 생각하고, 코드 흐름상 게임 매니저에 두는 것이 낫다고 판단
    int stageScore; //현재 스테이지의 점수값

    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
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
        //게임에서 발생하는 이벤트를 특정 키를 통해 강제로 호출하려는 의도. 현재 레벨업 키트를 생성하는 것 밖에 없다
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 instanceVec = new Vector3(11f, 0, 0);
            GameObject instance = Instantiate(weaponLevelUp, instanceVec, transform.rotation);
            Destroy(instance, 10f);
        }
    }

    public void SetEnemyCount(int transValue) //추후 없어질 예정
    {
        enemyCount = transValue;
        if(enemyManager.GetAllWavesCompleted() && enemyCount == 0)
        {
            GameClear();
        }
    }

    void GamePause()
    {
        Debug.Log("장비를 정지합니다");
        panel.SetActive(true); // actionPanel
        panelModes[0].SetActive(true); // pause 패널 활성화
        //GetComponent<UI_SelectManager>().UpdateButtons("Pause");
        //GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    public void GameClear()
    {
        Debug.Log("해치웠나..? " + enemyCount.ToString());
        DataManager.instance.SetPlayData("Test", stageScore);
        panel.SetActive(true); // actionPanel
        panelModes[1].SetActive(true); // win. 이겨서 나오는 함수이므로
        //GetComponent<UI_SelectManager>().UpdateButtons("Win");
        //GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        Debug.Log("패배");
        DataManager.instance.SetPlayData("Test", stageScore);
        panel.SetActive(true); // actionpanel
        panelModes[2].SetActive(true); //lose. 져서 나오는 함수
        //GetComponent<UI_SelectManager>().UpdateButtons("Lose");
        //GetComponent<UI_SelectManager>().ButtonFocus();
        Time.timeScale = 0.0f;
    }

    public void GameEnd() // 게임 승리 혹은 패배 처리
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

    public void SetPlayerLifeCount(int lifeValue) //추후 없어질 수도 있음
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
