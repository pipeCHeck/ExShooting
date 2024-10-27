using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//현재 데이터 저장 및 관리에 대한 임시적일 수 있는 스크립트 
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<UI_PlayerDataInfo> scoreList = new List<UI_PlayerDataInfo>();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetPlayData(string initialName, int scoreData)
    {
        GameObject instanceObject = new GameObject("PlayerDataInfo"); // 새로운 GameObject 생성
        UI_PlayerDataInfo instanceList = instanceObject.AddComponent<UI_PlayerDataInfo>(); // 컴포넌트 추가
        instanceList.SetPlayerData(initialName, scoreData); // 필드를 설정하는 메서드 호출
        DontDestroyOnLoad(instanceObject);


        scoreList.Add(instanceList);
    }

}
