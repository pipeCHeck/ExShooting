using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectManager : MonoBehaviour
{
    [SerializeField]
    Button[] MenuButtons; //게임시작, 연습모드, 플레이어기록, 설정, 종료
    int focusingButtonIndex; //배열기준 선택되고있는 버튼값
    string sceneName;

    void Start()
    {
        ButtonFocus();
        focusingButtonIndex = 0;
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        KeyManager();

    }


    void KeyManager()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TransButtonFocus(true); //아랫 방향키를 눌렀으니 값이 올라감
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TransButtonFocus(false); //윗 방향키를 눌렀으니 값이 내려감
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ActionButton();
        }
        if(Input.GetKeyDown(KeyCode.X) && sceneName == "GameModeScene")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
    
    void TransButtonFocus(bool isValueUp) 
    {
        MenuButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = Vector4.zero;

        if(isValueUp)
        {
            if (focusingButtonIndex == MenuButtons.Length - 1)
            {
                focusingButtonIndex = 0;
            }
            else
            {
                SetFocusButtonIndex(++focusingButtonIndex);
            }
        }
        else
        {
            if (focusingButtonIndex == 0)
            {
                focusingButtonIndex = MenuButtons.Length - 1;
            }
            else
            {
                SetFocusButtonIndex(--focusingButtonIndex);
            }
        }
        ButtonFocus();
    }

    void SetFocusButtonIndex(int value)
    {
        focusingButtonIndex = value;
    }

    int GetFocusingButtonIndex()
    {
        return focusingButtonIndex;
    }

    void ButtonFocus()
    {
        Color colorValue = new Vector4(0,0,1f,0.3f);
        MenuButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = colorValue;
    }

    void ActionButton()
    {
        if(sceneName == "MainScene")
        {
            switch (GetFocusingButtonIndex())
            {
                case 0: // 게임모드
                    SceneManager.LoadScene("TestGameScene");
                    break;
                case 1: // 연습모드

                    break;

                case 2: // 플레이어 데이터

                    break;

                case 3: // 설정

                    break;

                case 4: // 종료
                    Application.Quit();
                    break;
            }
        }        
    }

}
