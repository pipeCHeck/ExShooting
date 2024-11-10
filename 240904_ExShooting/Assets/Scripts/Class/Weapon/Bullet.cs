
using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField]
    float moveMaxX, moveMaxY; //�Ѿ��� Ȱ������. ���� ������Ʈ �������ؿ� ���� Object Ŭ�������� ���� Ŭ������ ��ġ�� �̵��� �� ����
    float destroyTime; //�ڵ� ���� �ð�.

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Debug.Log(GetDamage().ToString() + "��? �Ѿ� �������� ���������?");
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

    

    //getset

    

    public void SetDestroyTime(float destroyTimeValue)
    {
        destroyTime = destroyTimeValue;
    }

    public float GetDestroyTime()
    {
        return destroyTime;
    }

}
