
using UnityEngine;

public class Weapon : Object
{
    int damage; //무기는 기본적으로 데미지가 존재한다

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //무기 정보 저장을 보기 쉽게 처리하기 위한 함수
    public void SetWeaponData(float moveSpeedValue, string tagString, int damageValue)
    {
        SetMoveSpeed(moveSpeedValue);
        SetTag(tagString);
        SetDamage(damageValue);
    }


    //getset
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }


    //보통 오브젝트 회전을 할 때 해당 기능을 이용하면 됨. 요구하는 기획서에 의해 상위 클래스로 이전할 수 있음
    public void SetRotationZ(float value)
    {
        float instanceRotationX = transform.rotation.eulerAngles.x;
        float instanceRotationY = transform.rotation.eulerAngles.y;
        transform.Rotate(instanceRotationX, instanceRotationY, value);
    }

    protected virtual void HitCharacterByCollision(ref Collider2D collision) //무기 내 발사하는 대상에 따라 무기의 태그값이 변경되는 기능
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
