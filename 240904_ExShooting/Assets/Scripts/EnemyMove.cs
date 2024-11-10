using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyAttack // 발표를 위한 보여주기식 클래스. 삭제할 예정이며 아래 코드들을 기반으로 기획서와 함께 분석하여 Enemy클래스 설계에 대해 이바지할 예정
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
        Attack(); // 총알을 발사하는 공격타입이므로.. 
        Move(); // 단순 이동
        EnemyAutoRemove(); // 일정 거리로(현재는 아래) 이동하여 화면을 벗어날 시 자동 삭제 
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
        SetTag("Enemy"); // Enemy의 경우 해당 코드는 추후 생성스크립트 제작할 때 생성과 동시에 태그설정할 예정. 그러므로 각 Enemy스크립트에 이 코드는 넣지 않을 예정
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

    // 이동 메서드 (짜피 버릴거라니 잠깐 씀)

    virtual protected void Move()
    {

    }
}
