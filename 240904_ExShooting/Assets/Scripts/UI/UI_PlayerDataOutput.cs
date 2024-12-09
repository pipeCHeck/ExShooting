using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerDataOutput : MonoBehaviour
{
    public Text[] scoreTextes;

    void Start()
    {
        ShowDataList();
    }

    void ShowDataList()
    {
        //데이터매니저에 존재하는 점수 리스트를 기반으로 배열의 길이 정의
        scoreTextes = new Text[DataManager.instance.scoreList.Count];
        
        //이후 리스트가 비어있지 않으면 각각 해당 랭크텍스트를 찾아 실제 데이터를 출력하도록 한다
        if (DataManager.instance.scoreList != null)
        {
            for(int i = 0; i <scoreTextes.Length; i++)
            {
                scoreTextes[i] = GameObject.Find("TextRank" + i.ToString()).GetComponent<Text>();
            }
            for(int i = 0; i < scoreTextes.Length; i++)
            {
                Debug.Log(DataManager.instance.scoreList[0]);

                scoreTextes[i].text = DataManager.instance.scoreList[i].score.ToString();
            }
        }
    }
}
