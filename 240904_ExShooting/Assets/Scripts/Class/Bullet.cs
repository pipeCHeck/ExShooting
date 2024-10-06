using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object
{
    
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    protected override void Init()
    {
        base.Init();
        Destroy(gameObject, 5f);
        if (this.GetTag() == "Untagged")
        {
            Debug.Log("InitTag�Լ� �̽���.");
        }
    }

    //���� ������Ʈ ȸ���� �� �� �ش� ����� �̿��ϸ� ��. �䱸�ϴ� ��ȹ���� ���� ���� Ŭ������ ������ �� ����
    public void SetRotationZ(float value) 
    {
        transform.Rotate(new Vector3(0,0,value));
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �÷��̾� �Ѿ��浹
        if(collision.transform.tag == "Enemy" && this.GetTag() == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Character>().SetDamnagedHp(damage);
            Destroy(this.gameObject);
        }
        //�÷��̾ ���� �Ѿ��浹
        if (collision.transform.tag == "Player" && this.GetTag() == "EnemyBullet")
        {
            collision.gameObject.GetComponent<Character>().SetDamnagedHp(damage);
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
