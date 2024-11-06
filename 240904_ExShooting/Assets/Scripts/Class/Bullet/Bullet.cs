
using UnityEngine;

public class Bullet : Object
{
    [SerializeField]
    float moveMaxX, moveMaxY; //�Ѿ��� Ȱ������. ���� ������Ʈ �������ؿ� ���� Object Ŭ�������� ���� Ŭ������ ��ġ�� �̵��� �� ����
    int damage;
    float destroyTime; //�ڵ� ���� �ð�.
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed()); // �ش� �Լ��� ��ӹ޾����Ƿ� �ݵ�� ����ؾ���
        CheckAciveRange();
    }

    protected override void Init()
    {
        base.Init();
        moveMaxX = 11f;
        moveMaxY = 8f;
        SetDestroyTime(10f);
        AutoDestroyByTime();
    }


    void CheckAciveRange()
    {
        if(Mathf.Abs(transform.position.x) > moveMaxX || Mathf.Abs(transform.position.y) > moveMaxY)
        {
            Destroy(this.gameObject);
        }
    }

    //���� ������Ʈ ȸ���� �� �� �ش� ����� �̿��ϸ� ��. �䱸�ϴ� ��ȹ���� ���� ���� Ŭ������ ������ �� ����
    public void SetRotationZ(float value) 
    {
        transform.Rotate(new Vector3(0,0,value));
    }

    //���� �ð��� ������ �����Ǵ� ����. ����� �Ѿ� ���°� �̷��� ���¸� �䱸�ϱ� ������ ���������� ����
    void AutoDestroyByTime()
    {
        if (GetDestroyTime() != 0)
        {
            Destroy(gameObject, GetDestroyTime());
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitCharacterByCollision(ref collision);
    }

    protected void HitCharacterByCollision(ref Collider2D collision)
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

    public void SetDestroyTime(float destroyTimeValue)
    {
        destroyTime = destroyTimeValue;
    }

    public float GetDestroyTime()
    {
        return destroyTime;
    }

}
