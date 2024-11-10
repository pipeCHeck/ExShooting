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

    //보통 오브젝트 회전을 할 때 해당 기능을 이용하면 됨. 요구하는 기획서에 의해 상위 클래스로 이전할 수 있음
    public void SetRotationZ(float value)
    {
        transform.Rotate(new Vector3(0, 0, value));
    }

    protected virtual void HitCharacterByCollision(ref Collider2D collision)
    {
        //적이 플레이어 총알충돌
        if (collision.transform.tag == "Enemy" && this.GetTag() == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Enemy>().SetDamagedHp(damage);
            Destroy(this.gameObject);
        }
        //플레이어가 적의 총알충돌
        if (collision.transform.tag == "Player" && this.GetTag() == "EnemyBullet")
        {
            collision.gameObject.GetComponent<Player>().SetDamagedHp(damage);
            Debug.Log("Player에게 피해를 줌 : " + damage.ToString());
            Destroy(this.gameObject);
        }
    }

}
