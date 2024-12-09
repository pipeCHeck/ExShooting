
using UnityEngine;

public class Weapon : Object
{
    int damage; //����� �⺻������ �������� �����Ѵ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���� ���� ������ ���� ���� ó���ϱ� ���� �Լ�
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


    //���� ������Ʈ ȸ���� �� �� �ش� ����� �̿��ϸ� ��. �䱸�ϴ� ��ȹ���� ���� ���� Ŭ������ ������ �� ����
    public void SetRotationZ(float value)
    {
        float instanceRotationX = transform.rotation.eulerAngles.x;
        float instanceRotationY = transform.rotation.eulerAngles.y;
        transform.Rotate(instanceRotationX, instanceRotationY, value);
    }

    protected virtual void HitCharacterByCollision(ref Collider2D collision) //���� �� �߻��ϴ� ��� ���� ������ �±װ��� ����Ǵ� ���
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
