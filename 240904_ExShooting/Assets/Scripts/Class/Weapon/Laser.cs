using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    //������ �ڷ�ƾ�� �����ϵ��� ����. ���� �����̿� ���װ� ������ �ʰ� �ϱ� ����
    public Coroutine laserCoroutine;
    //���� ��������. isReadyAttack�� �����.
    bool isCanAttack = true;
    public float attackDelay; //�����ֱ�
    float attackDelayTimer; // �����ֱ⸦ üũ�ϱ� ���� Ÿ�̸�. �ڷ�ƾ ����� ���� �ʰ� ����

    private void Start()
    {
    }
    private void Update()
    {
        //�������� Ȱ��ȭ �Ǵ� ���� �ֱ����� �������� �ֱ� ���� Ÿ�̸Ӹ� ���� ������ ���ظ� �� �� �ִ� ������ ������
        attackDelayTimer += Time.deltaTime;
        if(attackDelayTimer >= attackDelay)
        {
            //���� �ð��� ������ �� Ȱ��ȭ
            isCanAttack = true;
            attackDelayTimer = 0;
        }
        else
        {
            //���� �ð��� ���� �ʾҴٸ� ��Ȱ��ȭ
            isCanAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitCharacterByCollision(ref collision); //�������� �浹�� ������Ʈ�� ��ũ�� ���Ͽ� �浹 �̺�Ʈ �߻���
    }

    protected override void HitCharacterByCollision(ref Collider2D collision) //ĳ���Ϳ� �浹�� �߻�
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
        //���ݰ����� ��Ȱ��ȭ �� ���� �ð� ���� �� ���� ���� �ο�
        isCanAttack = false;
        yield return new WaitForSeconds(attackDelay);
        isCanAttack = true;
        Debug.Log("�ڷ�ƾ ������");
        goto ReAttack; //�ᱹ �������� �ݺ������� �����ϱ� ����
    }
}
