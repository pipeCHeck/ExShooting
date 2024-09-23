using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object
{
    
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        if(this.GetTag() == "Untagged")
        {
            Debug.Log("InitTag함수 미실행.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed());
    }

    public void SetRotationZ(float value) //요구하는 기획서에 의해 상위 클래스로 이전할 수 있음
    {
        transform.Rotate(new Vector3(0,0,value));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy" && this.GetTag() == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Character>().SetDamnagedHp(damage);
            Destroy(this.gameObject);
        }
        if (collision.transform.tag == "Player" && this.GetTag() == "EnemyBullet")
        {
            collision.gameObject.GetComponent<Character>().SetDamnagedHp(damage);
            Destroy(this.gameObject);

        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    int GetDamage()
    {
        return damage;
    }
}
