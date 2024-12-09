using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerDataInfo : MonoBehaviour
{
    //기획서 상에는 이니셜 개념이 없어서 추후 삭제될 수 있음
    public string initial;
    public int score;


    //아래 주석들의 경우 추후 개발할 예정의 데이터들을 미리 적기만 했음
    //public string Date;
    //public int stageValue;

    /*
    public int playCount;
    public float playTotalTime;
    public int clearCount;
    */

    //플레이어데이터를 저장하려는 틀. 현재 작업한 것은 플레이어 이름과 스코어가 있다.
    public void SetPlayerData(string initialData, int score)
    {
        initial = initialData;
        this.score = score;
    }
}
