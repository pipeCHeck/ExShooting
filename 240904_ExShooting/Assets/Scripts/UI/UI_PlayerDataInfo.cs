using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerDataInfo : MonoBehaviour
{
    //��ȹ�� �󿡴� �̴ϼ� ������ ��� ���� ������ �� ����
    public string initial;
    public int score;


    //�Ʒ� �ּ����� ��� ���� ������ ������ �����͵��� �̸� ���⸸ ����
    //public string Date;
    //public int stageValue;

    /*
    public int playCount;
    public float playTotalTime;
    public int clearCount;
    */


    public void SetPlayerData(string initialData, int score)
    {
        initial = initialData;
        this.score = score;
    }
}
