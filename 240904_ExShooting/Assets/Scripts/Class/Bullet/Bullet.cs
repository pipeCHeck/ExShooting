using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object
{
    
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed()); // 해당 함수를 상속받았으므로 반드시 사용해야함
    }

    protected override void Init()
    {
        base.Init();
        Destroy(gameObject, 2f);

    }

    //보통 오브젝트 회전을 할 때 해당 기능을 이용하면 됨. 요구하는 기획서에 의해 상위 클래스로 이전할 수 있음
    public void SetRotationZ(float value) 
    {
        transform.Rotate(new Vector3(0,0,value));
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitCharacterByCollision(ref collision);
    }

    protected void HitCharacterByCollision(ref Collider2D collision)
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
            Destroy(this.gameObject);
        }
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
}
