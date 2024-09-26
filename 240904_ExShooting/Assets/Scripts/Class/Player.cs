using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Attacker
{
    

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }

    protected override void Init()
    {
        base.Init(); // Road attackManage

        SetMaxHp(3); //��� ���̵� �������� �ʱ� ����
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //�⺻��43 (�׽�Ʈ �� ���������� ��� �پ������)
        SetTag("Player");
        SetAttackDelay(0.2f);
        SetBulletSpeed(50f);
    }


    //�÷��̾ ���� �����ϴ� �������� playerŬ������ �Է� ����. ���� �̵� �� ������ �����Ѵ�
    void PlayerControl()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            ObjectMove(Vector3.left, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ObjectMove(Vector3.right, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ObjectMove(Vector3.up, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ObjectMove(Vector3.down, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.Z) && GetIsReadyAttack()) // GetIsReadyAttack�Լ��� ���� ������������ Ȯ�� �� �ߵ��� �ȴ�
        {
            AttackReady(); //�׻� ������ �� �� �Լ��� ����ؾ� ��.
            for (int i = 0; i < shootPosition.Length; i++)
            {
                //�� ������Ʈ(ĳ���� Ŭ������)���� ���ϴ� ���� �ӵ����� ������ ��, �Ѿ��� �߻��� �� �ش� ���� �����Ͽ� �Ѿ��� �ӵ��� ����.
                attackManage.ShootStraightBullet(bullet, this.gameObject, shootPosition[i], 0, GetBulletSpeed());
            }
        }
    }

    
}
