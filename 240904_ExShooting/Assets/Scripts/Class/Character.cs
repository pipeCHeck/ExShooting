using UnityEngine;

public class Character : Object
{
    float hp, maxHp; //체력 관련 데이터
    public int damage; //피해량. 발사하여 피해를 줄 수도, 부딛쳐 피해를 줄 수 있음

    protected void InitHp()
    {
        hp = maxHp; //체력초기화이므로 현재 체력을 최대 체력으로 회복함
    }
    protected override void Init()
    {
        //void
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //getset
    public virtual void SetDamagedHp(float damageValue)
    {
        hp -= damageValue;
    }

    

    // 추후 회복하거나, 강제로 체력이 줄어들 수 있으므로 일방적인 데미지와 다른 개념으로 함수 생성
    public void SetTransHp(float transHpValue) 
    {
        hp = transHpValue;
    }

    // 추후 기획에 의해 공용으로 변경될 수 있음
    protected void SetMaxHp(float value)
    {
        maxHp = value;
    }

    public float GetMaxHp()
    {
        return maxHp;
    }

    public float GetHp()
    {
        return hp;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int value)
    {
        damage = value;
    }


}
