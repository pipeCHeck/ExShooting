
using UnityEngine;

public class FinalBoss_test : FinalBoss
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); //���� ���� ������ �״�� ��������. ��ǥ������ ü���� ��������
        Init();
    }



    // Update is called once per frame
    void Update()
    {

    }

    

    protected override void Init()
    {
        //�׽�Ʈ�� ���������� 50�� ü���� �����Ѵ�
        SetMaxHp(50);
        InitHp();
        Debug.Log(GetTag());
    }
}
