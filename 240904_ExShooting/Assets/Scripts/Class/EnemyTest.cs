using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : Attacker // 발표를 위한 보여주기식 클래스. 삭제할 예정이며 아래 코드들을 기반으로 기획서와 함께 분석하여 Enemy클래스 설계에 대해 이바지할 예정
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
        SetTag("Enemy"); // Enemy의 경우 해당 코드는 추후 생성스크립트 제작할 때 생성과 동시에 태그설정할 예정. 그러므로 각 Enemy스크립트에 이 코드는 넣지 않을 예정
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

    // 이동 메서드 (짜피 버릴거라니 잠깐 씀)
    void Move()
    {
        ObjectMove(Vector3.down, GetMoveSpeed());
    }
}
