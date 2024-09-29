using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Attacker
{
    PlayerConcentrater concentrate;

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
        concentrate = gameObject.AddComponent<PlayerConcentrater>(); // ��ũ��Ʈ �߰�
        concentrate.ConcentInit();
        SetMaxHp(3); //��� ���̵� �������� �ʱ� ����
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //�⺻��43 (�׽�Ʈ �� ���������� ��� �پ������)
        SetTag("Player");
        SetAttackDelay(0.05f);
        SetBulletSpeed(50f);
    }


    //�÷��̾��� �������� �Է� ����
    void PlayerControl()
    {
        PlayerMove();
        PlayerAttack();
        concentrate.ConcentrateControl(this.gameObject);
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
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

    }

    //�Ϲ����� ���� ���ݰ� ��â �ý����� ���� Ű�� ����
    void PlayerAttack() 
    {
        // GetIsReadyAttack�Լ��� ���� ������������ Ȯ�� �� �ߵ��� �ȴ�
        if (Input.GetKey(KeyCode.Z) && GetIsReadyAttack()) 
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
