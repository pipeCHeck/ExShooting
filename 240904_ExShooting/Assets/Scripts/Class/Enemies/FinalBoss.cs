
using UnityEngine;

public class FinalBoss : Boss
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetMaxHp(1);
        InitHp();
        Init();
    }

    private void OnDestroy()
    {
        GameManager.instance.GameClear();
        Debug.Log("�Ҹ��� �ߵ�");
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Init()
    {

    }


}
