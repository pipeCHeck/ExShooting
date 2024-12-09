
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
        base.Init(); //void
        moveMaxX = 11f; //총알의 존재할 수 있는 공간 정의
        moveMaxY = 8f;
        SetDestroyTime(10f); //자동 삭제 시간을 10초로 정의
        AutoDestroyByTime();//예외적인 버그 방지를 위해 10초 뒤 자동 삭제. 추후 삭제될 수 있음
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
        HitCharacterByCollision(ref collision); // 총알 및 출동체의 태그에 따라 피격 여부를 정할 수 있음
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
