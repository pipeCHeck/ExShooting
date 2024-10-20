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
        scoreTextes = new Text[DataManager.instance.scoreList.Count];
        
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
