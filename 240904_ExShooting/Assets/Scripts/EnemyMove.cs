using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyAttack // ��ǥ�� ���� �����ֱ�� Ŭ����. ������ �����̸� �Ʒ� �ڵ���� ������� ��ȹ���� �Բ� �м��Ͽ� EnemyŬ���� ���迡 ���� �̹����� ����
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
        Attack(); // �Ѿ��� �߻��ϴ� ����Ÿ���̹Ƿ�.. 
        Move(); // �ܼ� �̵�
        EnemyAutoRemove(); // ���� �Ÿ���(����� �Ʒ�) �̵��Ͽ� ȭ���� ��� �� �ڵ� ���� 
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
        SetMoveSpeed(2.5f);
        SetTag("Enemy"); // Enemy�� ��� �ش� �ڵ�� ���� ������ũ��Ʈ ������ �� ������ ���ÿ� �±׼����� ����. �׷��Ƿ� �� Enemy��ũ��Ʈ�� �� �ڵ�� ���� ���� ����
        attack.SetAttackDelay(2f);
        attack.SetBulletSpeed(10f);
        SetDamage(2);
    }

    void Attack()
    {
        if (attack != null)
        {
            if (attack.GetToggleState("attack"))
            {
                attack.AttackReady();
                for (int i = 0; i < attack.GetShootPositions().Length; i++)
                {
                    attack.attackManage.ShootTargetBullet(attack.bullet, this.gameObject, "Player", attack.GetShootPosition(i), attack.GetBulletSpeed());
                }
            }
        }
        else
        {
            Debug.Log(gameObject.name.ToString() + " is not have attackManage script");
        }
    }

    // �̵� �޼��� (¥�� �����Ŷ�� ��� ��)

    virtual protected void Move()
    {

    }
}
