using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : Attacker // ��ǥ�� ���� �����ֱ�� Ŭ����. ������ �����̸� �Ʒ� �ڵ���� ������� ��ȹ���� �Բ� �м��Ͽ� EnemyŬ���� ���迡 ���� �̹����� ����
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {   
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Move();
    }

    protected override void Init()
    {
        base.Init();
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("Player is not found");
        }
        SetMaxHp(10);
        SetTransHp(GetMaxHp());
        SetMoveSpeed(5f);
        SetTag("Enemy"); // Enemy�� ��� �ش� �ڵ�� ���� ������ũ��Ʈ ������ �� ������ ���ÿ� �±׼����� ����. �׷��Ƿ� �� Enemy��ũ��Ʈ�� �� �ڵ�� ���� ���� ����
        SetAttackDelay(2f);
        SetBulletSpeed(5f);
    }

    void Attack()
    {
        if(GetIsReadyAttack())
        {
            AttackReady();
            for (int i = 0; i < shootPosition.Length; i++)
            {
                attackManage.ShootTargetBullet(bullet, this.gameObject, "Player", shootPosition[i], GetBulletSpeed());
            }
        }
    }

    // �̵� �޼��� (¥�� �����Ŷ�� ��� ��)
    void Move()
    {
        ObjectMove(Vector3.down, GetMoveSpeed());
    }
}
