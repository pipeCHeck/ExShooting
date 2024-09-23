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

    public void SetDamnagedHp(float damageValue)
    {
        hp -= damageValue;
        if(GetHp() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetTransHp(float transHpValue) // ���� ȸ���ϰų�, ������ ü���� �پ�� �� �����Ƿ� �Ϲ����� �������� �ٸ� �������� �Լ� ����
    {
        hp = transHpValue;
    }

    protected void SetMaxHp(float value) // ���� ��ȹ�� ���� �������� ����� �� ����
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

    virtual protected void Init()   {   }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

}
