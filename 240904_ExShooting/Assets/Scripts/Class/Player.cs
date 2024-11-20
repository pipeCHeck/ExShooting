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
        concentrate = gameObject.AddComponent<PlayerConcentrater>(); // 스크립트 추가
        concentrate.ConcentInit();
        SetMaxHp(3); //노멀 난이도 기준으로 초기 설정
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //기본값43 (테스트 중 불편함으로 잠시 줄어놓았음)
        SetTag("Player");

    }

    

    public override void SetDamagedHp(float damageValue)
    {
        base.SetDamagedHp(damageValue);
        //여기에 게임 오버 조건 추가함.
        if(GetHp() <= 0)
        {
            Debug.Log("게임 오버");
            //gameManager. //todo
        }
    }

    //플레이어의 여러가지 입력
    void PlayerControl()
    {
        PlayerMove();
        PlayerAttack();
        //concentrate.ConcentrateControl(this.gameObject); //추후 다시 집중모드를 재부활할 때 활성화할 예정
    }

    void PlayerMove() //이동 뿐만 아니라 최대 이동 범위 설정
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

    //일반적인 슈팅 공격과 영창 시스템의 공격 키들 모음
    void PlayerAttack() 
    {
        //Attack();
        ExplosionFild();

    }

    /*
    void Attack()
    {
        /*
        // GetIsReadyAttack함수로 공격 딜레이조건을 확인 후 발동이 된다
        if (Input.GetKey(KeyCode.Z) && attack.GetToggleState("attack"))
        {
            attack.AttackReady(); //항상 공격할 때 이 함수를 사용해야 함.

            //int bulletCount = attack.GetShootPositions().Length;
            int bulletCount = attack.GetShootCount();

            for (int i = 0; i < bulletCount; i++)
            {
                //각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
                //attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, attack.GetShootPosition(i), 0, attack.GetBulletSpeed());
                attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, transform.position + new Vector3(0.4f * (i - (bulletCount / 2)) + (bulletCount % 2 - 1) * -0.2f, 0.3f, 0), 0, attack.GetBulletSpeed()); // bullet 위치값 무시하고 bullet 수에 따라 위치 고정함
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
        // GetIsReadyAttack함수로 공격 딜레이조건을 확인 후 발동이 된다
        if (Input.GetKey(KeyCode.Z) && attack.GetToggleState("attack"))
        {
            attack.AttackReady(); //항상 공격할 때 이 함수를 사용해야 함.

            int bulletCount = attack.GetShootPositions().Length;

            for (int i = 0; i < attack.GetShootPositions().Length; i++)
            {
                //각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
                //attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, attack.GetShootPosition(i), 0, attack.GetBulletSpeed());
                attack.attackManage.ShootStraightBullet(attack.bullet, this.gameObject, new Vector3(transform.position.x + 0.3f * (i - (i / 2)), 0.3f, 0), 0, attack.GetBulletSpeed());
            }
        }
    }
    */


    //폭탄. 현재 C 키를 통해 발동할 수 있음. 추후 공격 관련 스크립트가 변경되어 위치가 변동될 예정
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
