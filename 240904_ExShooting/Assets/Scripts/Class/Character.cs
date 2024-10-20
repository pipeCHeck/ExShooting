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

    // ���� ȸ���ϰų�, ������ ü���� �پ�� �� �����Ƿ� �Ϲ����� �������� �ٸ� �������� �Լ� ����
    public void SetTransHp(float transHpValue) 
    {
        hp = transHpValue;
    }

    // ���� ��ȹ�� ���� �������� ����� �� ����
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
