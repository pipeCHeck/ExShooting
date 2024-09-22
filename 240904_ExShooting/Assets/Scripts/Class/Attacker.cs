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
    bool isReadyAttack = true;

    protected IEnumerator AttackDelay()
    {
        if (attackManage == null) {Debug.Log("attackManage���Ҵ�. Init�Լ��� ��ӹ��� �� �������ּ���.");} // ���� �Ǽ��� ������ �ľ��ϱ� ���� �۾�. ���� �Ǽ��ϱ� ���� ������ �ؼ����� ���ߴٸ� �������� ���� �� �ֱ� ����
        if (attackDelay == 0) { Debug.Log("attackDelay has not init"); }

        isReadyAttack = false;
        yield return new WaitForSeconds(GetAttackDelay());
        isReadyAttack = true;
    }

    protected override void Init() // �ش� �ʱ�ȭ�� �ݵ�� ����Ŭ�������� �ݵ�� ȣ������� attackManage�� ����� �� ����.
    {
        attackManage = gameObject.AddComponent<AttackManage>(); // ������Ʈ�� �����ϴ� ��ũ��Ʈ�� �ƴϴ��� ����Ƽ�� ���������� �ٸ� ������ ��ũ��Ʈ�� �ҷ��÷��� �ش� �ڵ�� �ҷ��;� ��
    }

    protected void AttackReady()
    {
        if(InputShootPosition != null) // �߻���ġ�� �ε��ϴ� ����
        {
            shootPosition = new Vector3[InputShootPosition.Length];
            for (int i = 0; i < shootPosition.Length; i++)
            {
                shootPosition[i] = this.gameObject.transform.position + InputShootPosition[i]; // shootVector�� ���� ĳ������ ��ġ�� ���ϸ� �߻���ġ�� ����.
            }
        }
        else
        {
            Debug.Log("shootVector �� �迭�� �������");
        }

        StartCoroutine(AttackDelay()); //���� �߻��� ���̹Ƿ� ��߻��ϱ� ���� ���ð�.
    }

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

    protected bool GetIsReadyAttack()
    {
        return isReadyAttack;
    }


    void SetShootVector(int index, Vector3 value) // �������� �Լ��̳� Ȥ�� �� ���� ������ ����
    {
        InputShootPosition[index] = value;
    }
}