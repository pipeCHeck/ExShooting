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

        SetMaxHp(3); //노멀 난이도 기준으로 초기 설정
        SetTransHp(GetMaxHp());
        SetMoveSpeed(20f); //기본값43 (테스트 중 불편함으로 잠시 줄어놓았음)
        SetTag("Player");
        SetAttackDelay(0.2f);
        SetBulletSpeed(50f);
    }


    //플레이어가 직접 조작하는 독단적인 player클래스의 입력 모음. 현재 이동 및 공격이 존재한다
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
        if (Input.GetKey(KeyCode.Z) && GetIsReadyAttack()) // GetIsReadyAttack함수로 공격 딜레이조건을 확인 후 발동이 된다
        {
            AttackReady(); //항상 공격할 때 이 함수를 사용해야 함.
            for (int i = 0; i < shootPosition.Length; i++)
            {
                //각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
                attackManage.ShootStraightBullet(bullet, this.gameObject, shootPosition[i], 0, GetBulletSpeed());
            }
        }
    }

    
}
