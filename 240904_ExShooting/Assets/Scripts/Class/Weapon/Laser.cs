using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    //레이저 코루틴을 저장하도록 정의. 공격 딜레이에 버그가 생기지 않게 하기 위함
    public Coroutine laserCoroutine;
    //공격 가능유무. isReadyAttack과 흡사함.
    bool isCanAttack = true;
    public float attackDelay; //공격주기
    float attackDelayTimer; // 공격주기를 체크하기 위한 타이머. 코루틴 사용을 하지 않고 있음

    private void Start()
    {
    }
    private void Update()
    {
        //레이저가 활성화 되는 동안 주기적인 데미지를 주기 위해 타이머를 돌려 적에게 피해를 줄 수 있는 권한을 관리함
        attackDelayTimer += Time.deltaTime;
        if(attackDelayTimer >= attackDelay)
        {
            //일정 시간이 지났을 시 활성화
            isCanAttack = true;
            attackDelayTimer = 0;
        }
        else
        {
            //아직 시간이 되지 않았다면 비활성화
            isCanAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitCharacterByCollision(ref collision); //레이저와 충돌된 오브젝트의 태크를 비교하여 충돌 이벤트 발생함
    }

    protected override void HitCharacterByCollision(ref Collider2D collision) //캐릭터와 충돌시 발생
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
        //공격가능을 비활성화 후 일정 시간 지난 뒤 공격 권한 부여
        isCanAttack = false;
        yield return new WaitForSeconds(attackDelay);
        isCanAttack = true;
        Debug.Log("코루틴 실행중");
        goto ReAttack; //결국 레이저는 반복적으로 공격하기 때문
    }
}
