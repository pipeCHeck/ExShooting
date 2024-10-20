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
        concentrate = gameObject.AddComponent<PlayerConcentrater>(); // 스크립트 추가
        concentrate.ConcentInit();
        SetMaxHp(3); //노멀 난이도 기준으로 초기 설정
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //기본값43 (테스트 중 불편함으로 잠시 줄어놓았음)
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

    //플레이어의 여러가지 입력
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

    //일반적인 슈팅 공격과 영창 시스템의 공격 키들 모음
    void PlayerAttack() 
    {
        ShootBullet();
        ExplosionFild();

    }

    void ShootBullet()
    {
        // GetIsReadyAttack함수로 공격 딜레이조건을 확인 후 발동이 된다
        if (Input.GetKey(KeyCode.Z) && attack.GetToggleState("attack"))
        {
            attack.AttackReady(); //항상 공격할 때 이 함수를 사용해야 함.
            for (int i = 0; i < attack.GetShootPositions().Length; i++)
            {
                //각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
                attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, attack.GetShootPosition(i), 0, attack.GetBulletSpeed());
            }
        }
    }

    //폭탄 
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
