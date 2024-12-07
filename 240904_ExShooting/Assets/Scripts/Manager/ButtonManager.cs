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
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;

    }

    public void LoadGamePsjScene()
    {
        SceneManager.LoadScene("TestScenePsj1117");
        Time.timeScale = 1.0f;
    }

    public void LoadScoreDataScene()
    {
        SceneManager.LoadScene("ScoreDataScene");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void BackInTheGame()
    {
        Time.timeScale = 1.0f;
        GameManager.instance.SetAciPanelState(0, false);
        Debug.Log(this.transform.parent + "??");
    }
    

}
