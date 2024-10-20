using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Character : Object
{
    protected GameManager gameManager;
    float hp, maxHp;
    public int damage;

    protected void InitHp()
    {
        hp = maxHp;
    }
    protected override void Init()
    { 
        //void
    }

    //getset
    public virtual void SetDamagedHp(float damageValue)
    {
        hp -= damageValue;
        
    }

    protected virtual void DeathEvent()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
