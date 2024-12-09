using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    //scene�� �ε��ϴ� ��ɵ�
    public void LoadMainScene()
    {
        //����ȭ�� �ε�
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;

    }

    public void LoadGamePsjScene()
    {
        //���Ӿ� �ε�
        SceneManager.LoadScene("TestScenePsj1117");
        Time.timeScale = 1.0f;
    }

    public void LoadScoreDataScene()
    {
        //���� â �ε�
        SceneManager.LoadScene("ScoreDataScene");
    }
    public void LoadGameScene()
    {
        //���Ӿ� �ε�(��)
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void GameExit()
    {
        //�ý��� ����
        Application.Quit();
    }

    public void BackInTheGame()
    {
        //����ȭ�� �� pause ������ �����ϴ� ���
        Time.timeScale = 1.0f;
        GameManager.instance.SetAciPanelState(0, false);
        Debug.Log(this.transform.parent + "??");
    }
    

}
