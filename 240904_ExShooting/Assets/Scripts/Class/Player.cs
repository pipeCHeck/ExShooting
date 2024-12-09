using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    float moveMaxX, moveMaxY; //�÷��̾ ȭ�� �� Ȱ���� �� �ִ� ���� ����
    //Attacker attack; //attack script must input in inspecter directly
    PlayerConcentrater concentrate; //���߸��. �÷��̾��� ��ų�� �ߵ��ϱ� ���� ��ũ��Ʈ

    // Start is called before the first frame update
    void Start()
    {
        Init(); //�÷��̾� ���� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl(); //�÷��̾� ���� �������� ������
    }

    protected override void Init()
    {
        // �÷��̾� ���߸��, ü�� ����, �̵��ӵ� �� �±� �� ������ ��
        base.Init(); //void
        //attack = gameObject.GetComponent<Attacker>();
        concentrate = gameObject.AddComponent<PlayerConcentrater>(); // ��ũ��Ʈ �߰�
        concentrate.ConcentInit();
        SetMaxHp(3); //��� ���̵� �������� �ʱ� ����
        InitHp();
        SetMoveSpeed(20f); //�⺻��43 (�׽�Ʈ �� ���������� ��� �پ������)
        SetTag("Player");

    }

    
    //�÷��̾ ���ظ� ���� �� �����
    public override void SetDamagedHp(float damageValue)
    {
        base.SetDamagedHp(damageValue); //���� ��ŭ ü�� ����
        //���⿡ ���� ���� ���� �߰���.
        if(GetHp() <= 0)
        {
            Debug.Log("���� ����");
            //gameManager. //todo
            GameManager.instance.GameOver();
        }
    }

    //�÷��̾��� �������� �Է�
    void PlayerControl()
    {
        PlayerMove(); //�÷��̾� �̵� Ű ���� �Լ�
        PlayerAttack(); //�÷��̾� ���� ���� �Լ�
        //concentrate.ConcentrateControl(this.gameObject); //���� �ٽ� ���߸�带 ���Ȱ�� �� Ȱ��ȭ�� ����
    }

    void PlayerMove() //�̵� �Ӹ� �ƴ϶� �ִ� �̵� ���� ����
    {
        //��, ��, ��, �Ϸ� ����Ű�� ���� �÷��̾ �̵���
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -moveMaxX)
        {
            ObjectMove(Vector3.left, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < moveMaxX)
        {
            ObjectMove(Vector3.right, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < moveMaxY)
        {
            ObjectMove(Vector3.up, GetMoveSpeed());
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -moveMaxY)
        {
            ObjectMove(Vector3.down, GetMoveSpeed());
        }

    }

    //�Ϲ����� ���� ���ݰ� ��â �ý����� ���� Ű�� ����
    void PlayerAttack() 
    {
        //Attack();
        ExplosionFild(); //���� Ű�� ����(C) ���� �Ѿ� ����

    }

    /*
    void Attack()
    {
        /*
        // GetIsReadyAttack�Լ��� ���� ������������ Ȯ�� �� �ߵ��� �ȴ�
        if (Input.GetKey(KeyCode.Z) && attack.GetToggleState("attack"))
        {
            attack.AttackReady(); //�׻� ������ �� �� �Լ��� ����ؾ� ��.

            //int bulletCount = attack.GetShootPositions().Length;
            int bulletCount = attack.GetShootCount();

            for (int i = 0; i < bulletCount; i++)
            {
                //�� ������Ʈ(ĳ���� Ŭ������)���� ���ϴ� ���� �ӵ����� ������ ��, �Ѿ��� �߻��� �� �ش� ���� �����Ͽ� �Ѿ��� �ӵ��� ����.
                //attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, attack.GetShootPosition(i), 0, attack.GetBulletSpeed());
                attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, transform.position + new Vector3(0.4f * (i - (bulletCount / 2)) + (bulletCount % 2 - 1) * -0.2f, 0.3f, 0), 0, attack.GetBulletSpeed()); // bullet ��ġ�� �����ϰ� bullet ���� ���� ��ġ ������
            }
        }

        if(Input.GetKey(KeyCode.X) && attack.GetToggleState("attack"))
        {
            attack.AttackReady();
            Vector3 instanceShootPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            attack.attackManage.ShootMisiile(attack.missile, this.gameObject, instanceShootPosition, attack.GetBulletSpeed());
        }
    }
        */


    
    
    /*
    void Attack()
    {
        // GetIsReadyAttack�Լ��� ���� ������������ Ȯ�� �� �ߵ��� �ȴ�
        if (Input.GetKey(KeyCode.Z) && attack.GetToggleState("attack"))
        {
            attack.AttackReady(); //�׻� ������ �� �� �Լ��� ����ؾ� ��.

            int bulletCount = attack.GetShootPositions().Length;

            for (int i = 0; i < attack.GetShootPositions().Length; i++)
            {
                //�� ������Ʈ(ĳ���� Ŭ������)���� ���ϴ� ���� �ӵ����� ������ ��, �Ѿ��� �߻��� �� �ش� ���� �����Ͽ� �Ѿ��� �ӵ��� ����.
                //attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, attack.GetShootPosition(i), 0, attack.GetBulletSpeed());
                attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, new Vector3(transform.position.x + 0.3f * (i - (i / 2)), 0.3f, 0), 0, attack.GetBulletSpeed());
            }
        }
    }
    */


    //��ź. ���� C Ű�� ���� �ߵ��� �� ����. ���� ���� ���� ��ũ��Ʈ�� ����Ǿ� ��ġ�� ������ ����
    void ExplosionFild()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GameObject[] enemyBullets;
            enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
            for(int i = 0; i < enemyBullets.Length; i++)
            {
                if (enemyBullets == null)
                {
                    Debug.Log("enemyBullet is not found");
                }
                else
                {
                    Debug.Log(enemyBullets[i].name);
                }
                Destroy(enemyBullets[i]);
            }
        }
    }   
}
