using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectManager : MonoBehaviour
{
    //enum을 통해 해당 스크립트가 상황에 따른 처리를 관리함
    public enum SceneState
    {
        MainScene,
        GameScene,
        DataScene

    }

    public SceneState sceneState;

    [SerializeField]
    Button[] LoadedButtons; //각 씬마다 존재하는 버튼들은 방향키를 기반으로 선택 후 z키를 누르기 때문에 편집하려는 버튼들이 변경되야 할 때 로드를 해야 하기 때문
    [SerializeField]
    GameObject[] buttonDummies; //버튼을 머금는 오브젝트들 모음. 씬 마다 하나일 수도. 여러 개일 수 있기 때문에 배열로 선언
    int focusingButtonIndex; //배열 기준 선택되고있는 버튼값
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


        //씬마다 적용해야 하는 타이밍이나 특징이 다르기 떄문에 작업함
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
                TransButtonFocus(true); //아랫 방향키를 눌렀으니 값이 올라감
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TransButtonFocus(false); //윗 방향키를 눌렀으니 값이 내려감
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

    //버튼들이 모여있는 상위 오브젝트를 불러온 뒤, 자식 버튼들을 모두 불러와 배열화
    public void UpdateButtons(string arrayName)
    {
        //유니티는 람타 방식이 되지 않으므로 for문을 사용해서 직접 확인하고 있음. 이후 인덱스를 확인하고, 원하는 버튼리스트들을 소지 중인 오브젝트를 불러와 해당 오브젝트의 자식버튼들을 모두 가져옴
        int ButtonDummiesindex = -1;
        for (int i = 0; i < buttonDummies.Length; i++)
        {
            if (buttonDummies[i].name == arrayName)
            {
                ButtonDummiesindex = i;
                break;
            }
        }
        LoadedButtons = buttonDummies[ButtonDummiesindex].GetComponentsInChildren<Button>(); //버튼 내용물 삽입
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
        LoadedButtons[GetFocusingButtonIndex()].onClick.Invoke(); //이렇게 해도 문제 없음. 각 button들의 onClick부분을 삽입해주면 효율적으로 처리할 수 있음
    }
}
