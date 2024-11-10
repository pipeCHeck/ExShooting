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
        //���� �÷��̾� �Ѿ��浹
        if (collision.transform.tag == "Enemy" && this.GetTag() == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Enemy>().SetDamagedHp(GetDamage());
        }
        //�÷��̾ ���� �Ѿ��浹
        if (collision.transform.tag == "Player" && this.GetTag() == "EnemyBullet")
        {
            collision.gameObject.GetComponent<Player>().SetDamagedHp(GetDamage());
        }
    }

    //���������� �ٷ�� attackDelay�� ������ Ȱ��ȭ ������ ƽ �ֱ�� �����
    public IEnumerator LaserAttack(float attackDelay)
    {
        ReAttack:

        isCanAttack = false;
        yield return new WaitForSeconds(attackDelay);
        isCanAttack = true;
        Debug.Log("�ڷ�ƾ ������");
        goto ReAttack; //�ᱹ �������� �ݺ������� �����ϱ� ����
    }
}
