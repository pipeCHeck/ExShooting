using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    public Coroutine laserCoroutine;
    bool isCanAttack = true;
    public float attackDelay;
    float attackDelayTimer;

    private void Start()
    {
    }
    private void Update()
    {
        attackDelayTimer += Time.deltaTime;
        if(attackDelayTimer >= attackDelay)
        {
            isCanAttack = true;
            attackDelayTimer = 0;
        }
        else
        {
            isCanAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitCharacterByCollision(ref collision);
    }

    protected override void HitCharacterByCollision(ref Collider2D collision)
    {
        //적이 플레이어 총알충돌
        if (collision.transform.tag == "Enemy" && this.GetTag() == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Enemy>().SetDamagedHp(GetDamage());
        }
        //플레이어가 적의 총알충돌
        if (collision.transform.tag == "Player" && this.GetTag() == "EnemyBullet")
        {
            collision.gameObject.GetComponent<Player>().SetDamagedHp(GetDamage());
        }
    }

    //레이저에서 다루는 attackDelay는 레이저 활성화 동안의 틱 주기로 사용함
    public IEnumerator LaserAttack(float attackDelay)
    {
        ReAttack:

        isCanAttack = false;
        yield return new WaitForSeconds(attackDelay);
        isCanAttack = true;
        Debug.Log("코루틴 실행중");
        goto ReAttack; //결국 레이저는 반복적으로 공격하기 때문
    }
}
