using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectManager : MonoBehaviour
{
    //enum을 통해 해당 스크립트가 상황에 따른 처리를 관리함. 메인화면, 게임화면, 데이터화면이 존재함
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
        Init(); //씬 시작 시 초기데이터 정의
        
    }

    void Update()
    {
        KeyManager(); //현재는 사용하지 않으나 버튼을 선택하기 위해 방향키를 눌러 원하는 버튼의 옵션을 포커싱할 수 있음
    }

    void Init()
    {

        focusingButtonIndex = 0; //배열을 사용하므로 초기값은 0으로 정의
        sceneName = SceneManager.GetActiveScene().name; // 현재 씬 이름을 불러와 씬에 따라 처리를 다르게함


        //씬마다 적용해야 하는 타이밍이나 특징이 다르기 때문에 작업함. 메인화면은 
        switch (sceneState)
        {
            case SceneState.MainScene: //메인화면의 경우 첫 시작 시 바로 적용해야 하므로, 버튼의 정보를 바로 불러와 맨 위의 버튼이 포커스되게 처리함
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
        //버튼이 하나라도 있어야만 실행이 가능
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
                ActionButton(); //해당 버튼을 상호작용하고 싶다면 Z키를 눌러 실행
            }
            if (Input.GetKeyDown(KeyCode.X) && sceneName == "GameModeScene")
            {
                SceneManager.LoadScene("MainScene"); //X키를 눌러 뒤로가기할 수 있음
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
        //키를 눌러 포커스되는 버튼이 바뀔 때마다 이전의 버튼 색을 복구하고, 버튼의 배열순서를 편집하여 현재 포커스되는 버튼을 파악할 수 있음.
        LoadedButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = Vector4.zero;

        if(isValueUp)
        {
            //맨 아래 버튼에서 아래 키를 누를 시 맨 위로 이동
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
            //맨 위 버튼에서 윗 키를 누를 시 맨 아래로 이동
            if (focusingButtonIndex == 0)
            {
                focusingButtonIndex = LoadedButtons.Length - 1;
            }
            else
            {
                SetFocusButtonIndex(--focusingButtonIndex);
            }
        }
        ButtonFocus(); //변경이 되었으니 해당 번호의 버튼을 포커스처리
    }

    public void ButtonFocus()
    {
        //버튼이 포커스되면 버튼색을 변경하여 시각적으로 보여줌
        Color colorValue = new Vector4(0, 0, 1f, 0.3f);
        LoadedButtons[GetFocusingButtonIndex()].GetComponent<Image>().color = colorValue;
    }

    void ActionButton()
    {
        LoadedButtons[GetFocusingButtonIndex()].onClick.Invoke(); //이렇게 해도 문제 없음. 각 button들의 onClick부분을 삽입해주면 효율적으로 처리할 수 있음
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
