
using UnityEngine;

public class Bullet : Object
{
    [SerializeField]
    float moveMaxX, moveMaxY; //총알의 활동범위. 추후 오브젝트 삭제기준에 의해 Object 클래스같은 상위 클래스로 위치가 이동할 수 있음
    int damage;
    float destroyTime; //자동 삭제 시간.
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed()); // 해당 함수를 상속받았으므로 반드시 사용해야함
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

    //보통 오브젝트 회전을 할 때 해당 기능을 이용하면 됨. 요구하는 기획서에 의해 상위 클래스로 이전할 수 있음
    public void SetRotationZ(float value) 
    {
        transform.Rotate(new Vector3(0,0,value));
    }

    //일정 시간이 지나서 삭제되는 유형. 현재는 총알 형태가 이러한 형태를 요구하기 때문에 독단적으로 존재
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

    public void SetDestroyTime(float destroyTimeValue)
    {
        destroyTime = destroyTimeValue;
    }

    public float GetDestroyTime()
    {
        return destroyTime;
    }

}
