using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    float moveMaxX, moveMaxY;
    //Attacker attack; //attack script must input in inspecter directly
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
        base.Init();
        //attack = gameObject.GetComponent<Attacker>();
        concentrate = gameObject.AddComponent<PlayerConcentrater>(); // ��ũ��Ʈ �߰�
        concentrate.ConcentInit();
        SetMaxHp(3); //��� ���̵� �������� �ʱ� ����
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //�⺻��43 (�׽�Ʈ �� ���������� ��� �پ������)
        SetTag("Player");
        //attack.SetAttackDelay(0.05f);
        //attack.SetBulletSpeed(50f);
    }

    

    public override void SetDamagedHp(float damageValue)
    {
        base.SetDamagedHp(damageValue);
    }

    protected override void DeathEvent()
    {
        base.DeathEvent();
        gameManager.SetPlayerLifeCount(gameManager.GetPlayerLifeCount() - 1);

    }

    //�÷��̾��� �������� �Է�
    void PlayerControl()
    {
        PlayerMove();
        PlayerAttack();
        concentrate.ConcentrateControl(this.gameObject);
    }

    void PlayerMove() //�̵� �Ӹ� �ƴ϶� �ִ� �̵� ���� ����
    {
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
        Attack();
        ExplosionFild();

    }

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
        */


    }

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


    //��ź. ���� C Ű�� ���� �ߵ��� �� ����
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
