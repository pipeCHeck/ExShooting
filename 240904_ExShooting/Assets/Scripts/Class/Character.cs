using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{
    float hp, maxHp;
    public int damage;

    protected void InitHp()
    {
        hp = maxHp;
    }
    virtual protected void Init() { }

    //getset
    public void SetDamnagedHp(float damageValue)
    {
        hp -= damageValue;
        if(GetHp() <= 0)
        {
            Destroy(this.gameObject);
        }
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
