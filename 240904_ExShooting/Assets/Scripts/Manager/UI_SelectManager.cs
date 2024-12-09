using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectManager : MonoBehaviour
{
    //enum�� ���� �ش� ��ũ��Ʈ�� ��Ȳ�� ���� ó���� ������. ����ȭ��, ����ȭ��, ������ȭ���� ������
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
        Init(); //�� ���� �� �ʱⵥ���� ����
        
    }

    void Update()
    {
        KeyManager(); //����� ������� ������ ��ư�� �����ϱ� ���� ����Ű�� ���� ���ϴ� ��ư�� �ɼ��� ��Ŀ���� �� ����
    }

    void Init()
    {

        focusingButtonIndex = 0; //�迭�� ����ϹǷ� �ʱⰪ�� 0���� ����
        sceneName = SceneManager.GetActiveScene().name; // ���� �� �̸��� �ҷ��� ���� ���� ó���� �ٸ�����


        //������ �����ؾ� �ϴ� Ÿ�̹��̳� Ư¡�� �ٸ��� ������ �۾���. ����ȭ���� 
        switch (sceneState)
        {
            case SceneState.MainScene: //����ȭ���� ��� ù ���� �� �ٷ� �����ؾ� �ϹǷ�, ��ư�� ������ �ٷ� �ҷ��� �� ���� ��ư�� ��Ŀ���ǰ� ó����
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
        //��ư�� �ϳ��� �־�߸� ������ ����
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
                ActionButton(); //�ش� ��ư�� ��ȣ�ۿ��ϰ� �ʹٸ� ZŰ�� ���� ����
            }
            if (Input.GetKeyDown(KeyCode.X) && sceneName == "GameModeScene")
            {
                SceneManager.LoadScene("MainScene"); //XŰ�� ���� �ڷΰ����� �� ����
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
        //Ű�� ���� ��Ŀ���Ǵ� ��ư�� �ٲ� ������ ������ ��ư ���� �����ϰ�, ��ư�� �迭������ �����Ͽ� ���� ��Ŀ���Ǵ� ��ư�� �ľ��� �� ����.
        LoadedButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = Vector4.zero;

        if(isValueUp)
        {
            //�� �Ʒ� ��ư���� �Ʒ� Ű�� ���� �� �� ���� �̵�
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
            //�� �� ��ư���� �� Ű�� ���� �� �� �Ʒ��� �̵�
            if (focusingButtonIndex == 0)
            {
                focusingButtonIndex = LoadedButtons.Length - 1;
            }
            else
            {
                SetFocusButtonIndex(--focusingButtonIndex);
            }
        }
        ButtonFocus(); //������ �Ǿ����� �ش� ��ȣ�� ��ư�� ��Ŀ��ó��
    }

    public void ButtonFocus()
    {
        //��ư�� ��Ŀ���Ǹ� ��ư���� �����Ͽ� �ð������� ������
        Color colorValue = new Vector4(0, 0, 1f, 0.3f);
        LoadedButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = colorValue;
    }

    void ActionButton()
    {
        LoadedButtons[GetFocusingButtonIndex()].onClick.Invoke(); //�̷��� �ص� ���� ����. �� button���� onClick�κ��� �������ָ� ȿ�������� ó���� �� ����
    }

    //getset
    void SetFocusButtonIndex(int value)
    {
        focusingButtonIndex = value;
    }

    int GetFocusingButtonIndex()
    {
        return focusingButtonIndex;
    }

    
}
