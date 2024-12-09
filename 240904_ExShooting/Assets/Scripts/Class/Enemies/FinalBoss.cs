
using UnityEngine;

public class FinalBoss : Boss
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //최종보스의 기초 능력치 설정. 현재는 체력밖에 없다
        base.Start();
        SetMaxHp(1);
        InitHp();
        Init();
    }

    private void OnDestroy()
    {
        //최종보스 사망 시 게임클리어 창 활성화
        GameManager.instance.GameClear();
        Debug.Log("소멸자 발동");
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Init()
    {

    }


}
