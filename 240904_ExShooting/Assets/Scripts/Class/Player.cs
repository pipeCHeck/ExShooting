using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    Attacker attack; //attack script must input in inspecter directly
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
        attack = gameObject.GetComponent<Attacker>();
        concentrate = gameObject.AddComponent<PlayerConcentrater>(); // ��ũ��Ʈ �߰�
        concentrate.ConcentInit();
        SetMaxHp(3); //��� ���̵� �������� �ʱ� ����
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //�⺻��43 (�׽�Ʈ �� ���������� ��� �پ������)
        SetTag("Player");
        attack.SetAttackDelay(0.05f);
        attack.SetBulletSpeed(50f);
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
        ShootBullet();
        ExplosionFild();

    }

    void ShootBullet()
    {
        // GetIsReadyAttack�Լ��� ���� ������������ Ȯ�� �� �ߵ��� �ȴ�
        if (Input.GetKey(KeyCode.Z) && attack.GetToggleState("attack"))
        {
            attack.AttackReady(); //�׻� ������ �� �� �Լ��� ����ؾ� ��.
            for (int i = 0; i < attack.GetShootPositions().Length; i++)
            {
                //�� ������Ʈ(ĳ���� Ŭ������)���� ���ϴ� ���� �ӵ����� ������ ��, �Ѿ��� �߻��� �� �ش� ���� �����Ͽ� �Ѿ��� �ӵ��� ����.
                attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, attack.GetShootPosition(i), 0, attack.GetBulletSpeed());
            }
        }
    }

    //��ź 
    void ExplosionFild()
    {
        if(Input.GetKeyDown(KeyCode.X))
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
