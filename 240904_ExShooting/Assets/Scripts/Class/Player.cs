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
        SetMoveSpeed(43f);
        SetTag("Player");
        SetAttackDelay(0.2f);
        SetBulletSpeed(50f);
    }

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
        if (Input.GetKey(KeyCode.Z) && GetIsReadyAttack())
        {
            AttackReady(); //�׻� ������ �� �� �Լ��� ����ؾ� ��.
            for (int i = 0; i < shootPosition.Length; i++)
            {
                attackManage.ShootStraightBullet(bullet, this.gameObject, shootPosition[i], 0, GetBulletSpeed()); //�� ������Ʈ(ĳ���� Ŭ������)���� ���ϴ� ���� �ӵ����� ������ ��, �Ѿ��� �߻��� �� �ش� ���� �����Ͽ� �Ѿ��� �ӵ��� ����.
            }
        }
    }

    
}
