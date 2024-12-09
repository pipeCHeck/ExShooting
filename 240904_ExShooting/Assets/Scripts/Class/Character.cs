using UnityEngine;

public class Character : Object
{
    float hp, maxHp; //ü�� ���� ������
    public int damage; //���ط�. �߻��Ͽ� ���ظ� �� ����, �ε��� ���ظ� �� �� ����

    protected void InitHp()
    {
        hp = maxHp; //ü���ʱ�ȭ�̹Ƿ� ���� ü���� �ִ� ü������ ȸ����
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
