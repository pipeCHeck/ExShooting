using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : Enemy
{
    public Attacker attack; //�����ϴ� ���� �⺻������ ����Ŀ ��ũ��Ʈ�� �ҷ��´�. ������ �� �ִ� ����� �־����� ����
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); //�±� �� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Init()
    {
        base.Init();
        attack = GetComponent<Attacker>(); // ����Ŀ ��ũ��Ʈ �ε�
    }
}
