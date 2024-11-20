using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectManager : MonoBehaviour
{
    //enum�� ���� �ش� ��ũ��Ʈ�� ��Ȳ�� ���� ó���� ������
    public enum SceneState
    {
        MainScene,
        GameScene,
        DataScene

    }

    public SceneState sceneState;

    [SerializeField]
    Button[] LoadedButtons; //�� ������ �����ϴ� ��ư���� ����Ű�� ������� ���� �� zŰ�� ������ ������ �����Ϸ��� ��ư���� ����Ǿ� �� �� �ε带 �ؾ� �ϱ� ����
    [SerializeField]
    GameObject[] buttonDummies; //��ư�� �ӱݴ� ������Ʈ�� ����. �� ���� �ϳ��� ����. ���� ���� �� �ֱ� ������ �迭�� ����
    int focusingButtonIndex; //�迭 ���� ���õǰ��ִ� ��ư��
    string sceneName;

    void Start()
    {
        Init();
        
    }

    void Update()
    {
        KeyManager();
    }

    void Init()
    {

        focusingButtonIndex = 0;
        sceneName = SceneManager.GetActiveScene().name;


        //������ �����ؾ� �ϴ� Ÿ�̹��̳� Ư¡�� �ٸ��� ������ �۾���
        switch (sceneState)
        {
            case SceneState.MainScene:
                UpdateButtons("Buttons");
                ButtonFocus();

                break;
            case SceneState.GameScene:
                break;
            case SceneState.DataScene:
                break;
        }

    }


    void KeyManager()
    {
        if (LoadedButtons.Length >= 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TransButtonFocus(true); //�Ʒ� ����Ű�� �������� ���� �ö�
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TransButtonFocus(false); //�� ����Ű�� �������� ���� ������
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ActionButton();
            }
            if (Input.GetKeyDown(KeyCode.X) && sceneName == "GameModeScene")
            {
                SceneManager.LoadScene("MainScene");
            }
        }

    }

    //��ư���� ���ִ� ���� ������Ʈ�� �ҷ��� ��, �ڽ� ��ư���� ��� �ҷ��� �迭ȭ
    public void UpdateButtons(string arrayName)
    {
        //����Ƽ�� ��Ÿ ����� ���� �����Ƿ� for���� ����ؼ� ���� Ȯ���ϰ� ����. ���� �ε����� Ȯ���ϰ�, ���ϴ� ��ư����Ʈ���� ���� ���� ������Ʈ�� �ҷ��� �ش� ������Ʈ�� �ڽĹ�ư���� ��� ������
        int ButtonDummiesindex = -1;
        for (int i = 0; i < buttonDummies.Length; i++)
        {
            if (buttonDummies[i].name == arrayName)
            {
                ButtonDummiesindex = i;
                break;
            }
        }
        LoadedButtons = buttonDummies[ButtonDummiesindex].GetComponentsInChildren<Button>(); //��ư ���빰 ����
    }


    void TransButtonFocus(bool isValueUp) 
    {
        LoadedButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = Vector4.zero;

        if(isValueUp)
        {
            if (focusingButtonIndex == LoadedButtons.Length - 1)
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
                focusingButtonIndex = LoadedButtons.Length - 1;
            }
            else
            {
                SetFocusButtonIndex(--focusingButtonIndex);
            }
        }
        ButtonFocus(); //
    }

    void SetFocusButtonIndex(int value)
    {
        focusingButtonIndex = value;
    }

    int GetFocusingButtonIndex()
    {
        return focusingButtonIndex;
    }

    public void ButtonFocus()
    {
        Color colorValue = new Vector4(0,0,1f,0.3f);
        LoadedButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = colorValue;
    }

    void ActionButton()
    {
        LoadedButtons[GetFocusingButtonIndex()].onClick.Invoke(); //�̷��� �ص� ���� ����. �� button���� onClick�κ��� �������ָ� ȿ�������� ó���� �� ����
    }
}
