
using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField]
    float moveMaxX, moveMaxY; //총알의 활동범위. 추후 오브젝트 삭제기준에 의해 Object 클래스같은 상위 클래스로 위치가 이동할 수 있음
    float destroyTime; //자동 삭제 시간.

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Debug.Log(GetDamage().ToString() + "뭐? 총알 데이지가 이정도라고?");
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
