using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    //scene을 로드하는 기능들
    public void LoadMainScene()
    {
        //메인화면 로드
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;

    }

    public void LoadGamePsjScene()
    {
        //게임씬 로드
        SceneManager.LoadScene("TestScenePsj1117");
        Time.timeScale = 1.0f;
    }

    public void LoadScoreDataScene()
    {
        //점수 창 로드
        SceneManager.LoadScene("ScoreDataScene");
    }
    public void LoadGameScene()
    {
        //게임씬 로드(구)
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void GameExit()
    {
        //시스템 종료
        Application.Quit();
    }

    public void BackInTheGame()
    {
        //게임화면 내 pause 해제시 실행하는 기능
        Time.timeScale = 1.0f;
        GameManager.instance.SetAciPanelState(0, false);
        Debug.Log(this.transform.parent + "??");
    }
    

}
