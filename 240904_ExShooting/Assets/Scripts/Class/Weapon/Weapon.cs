using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Object
{
    int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetWeaponData(float moveSpeedValue, string tagString, int damageValue)
    {
        SetMoveSpeed(moveSpeedValue);
        SetTag(tagString);
        SetDamage(damageValue);
    }

    //���� ������Ʈ ȸ���� �� �� �ش� ����� �̿��ϸ� ��. �䱸�ϴ� ��ȹ���� ���� ���� Ŭ������ ������ �� ����
    public void SetRotationZ(float value)
    {
        transform.Rotate(new Vector3(0, 0, value));
    }

    protected virtual void HitCharacterByCollision(ref Collider2D collision)
    {
        //���� �÷��̾� �Ѿ��浹
        if (collision.transform.tag == "Enemy" && this.GetTag() == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Enemy>().SetDamagedHp(damage);
            Destroy(this.gameObject);
        }
        //�÷��̾ ���� �Ѿ��浹
        if (collision.transform.tag == "Player" && this.GetTag() == "EnemyBullet")
        {
            collision.gameObject.GetComponent<Player>().SetDamagedHp(damage);
            Debug.Log("Player���� ���ظ� �� : " + damage.ToString());
            Destroy(this.gameObject);
        }
    }

}
