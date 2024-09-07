using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectManager : MonoBehaviour
{
    [SerializeField]
    Button[] MenuButtons; //���ӽ���, �������, �÷��̾���, ����, ����
    int focusingButtonIndex; //�迭���� ���õǰ��ִ� ��ư��
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
            TransButtonFocus(true); //�Ʒ� ����Ű�� �������� ���� �ö�
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TransButtonFocus(false); //�� ����Ű�� �������� ���� ������
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
                case 0: // ���Ӹ��
                    SceneManager.LoadScene("TestGameScene");
                    break;
                case 1: // �������

                    break;

                case 2: // �÷��̾� ������

                    break;

                case 3: // ����

                    break;

                case 4: // ����
                    Application.Quit();
                    break;
            }
        }        
    }

}
