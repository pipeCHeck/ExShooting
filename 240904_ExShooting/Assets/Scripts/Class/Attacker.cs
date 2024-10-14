using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Attacker : Character
{
    public GameObject bullet;
    protected AttackManage attackManage;

    [SerializeField]
    protected Vector3[] InputShootPosition; // �� �����ϴ� Ŭ�������� �߻���ġ�� ������. �ϳ��� ���� �ְ� �������� �� ����
    protected Vector3[] shootPosition; // ������Ʈ�� ���� �������� �������� ������ �߻� ��ġ ����.

    float attackDelay; // �����ֱ�. �÷��̾��� ���ݼӵ��� �� �� �ְ�, �����ϴ� ������ �����ֱ�� ó���� �� ����
    float bulletSpeed; // �߻��ϴ� ��ü�� �䱸�ϴ� �Ѿ� �ӵ���


    //���� ����� ������ �ҷ��� ���� �׻� true�� �����̱� ����(���� ������, ��ų ������ �� ���� ������ ����ϹǷ�) �پ缺�� �ΰ� ������, ���� �ڵ� ȿ���� ���ؼ� ������ ����
    protected IEnumerator ActionDelay(string actionType)
    {
        attackManage.SetToggleState(actionType, false);
        yield return new WaitForSeconds(attackDelay);
        attackManage.SetToggleState(actionType, true);

    }




    // �ش� �ʱ�ȭ�� �ݵ�� ����Ŭ�������� �ݵ�� ȣ������� attackManage�� ����� �� ����.
    protected override void Init()
    {
        // ������Ʈ�� �����ϴ� ��ũ��Ʈ�� �ƴϴ��� ����Ƽ�� ���������� �ٸ� ������ ��ũ��Ʈ�� �ҷ��÷��� �ش� �ڵ�� �ҷ��;� ��
        attackManage = gameObject.AddComponent<AttackManage>();
        attackManage.Init();
    }

    protected void AttackReady()
    {
        if(InputShootPosition != null) // �߻���ġ�� �ε��ϴ� ����
        {
            shootPosition = new Vector3[InputShootPosition.Length];
            for (int i = 0; i < shootPosition.Length; i++)
            {
                // shootVector�� ���� ĳ������ ��ġ�� ���ϸ� �߻���ġ�� ����.
                shootPosition[i] = this.gameObject.transform.position + InputShootPosition[i]; 
            }
        }
        else
        {
            Debug.Log("shootVector �� �迭�� �������");
        }

        StartCoroutine(ActionDelay("attack")); //���� �߻��� ���̹Ƿ� ��߻��ϱ� ���� ���ð�.
    }

    //getset
    protected void SetAttackDelay(float value)
    {
        attackDelay = value;
    }

    protected float GetAttackDelay()
    {
        return attackDelay;
    }

    protected float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    protected void SetBulletSpeed(float value)
    {
        bulletSpeed = value;
    }

    


    void SetShootVector(int index, Vector3 value) // �������� �Լ��̳� Ȥ�� �� ���� ������ ����
    {
        InputShootPosition[index] = value;
    }
}