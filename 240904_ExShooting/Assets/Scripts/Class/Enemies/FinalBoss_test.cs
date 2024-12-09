
using UnityEngine;

public class FinalBoss_test : FinalBoss
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); //보그 기초 설정을 그대로 물려받음. 대표적으로 체력을 설정받음
        Init();
    }



    // Update is called once per frame
    void Update()
    {

    }

    

    protected override void Init()
    {
        //테스트용 최종보스는 50의 체력을 소지한다
        SetMaxHp(50);
        InitHp();
        Debug.Log(GetTag());
    }
}
