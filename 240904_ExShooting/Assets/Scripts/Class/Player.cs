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
            AttackReady(); //항상 공격할 때 이 함수를 사용해야 함.
            for (int i = 0; i < shootPosition.Length; i++)
            {
                attackManage.ShootStraightBullet(bullet, this.gameObject, shootPosition[i], 0, GetBulletSpeed()); //각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
            }
        }
    }

    
}
