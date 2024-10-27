using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Attacker : MonoBehaviour
{

    public GameObject bullet;
    public AttackManage attackManage;

    [SerializeField]
    Vector3[] InputShootPosition; // �� �����ϴ� Ŭ�������� �߻���ġ�� ������. �ϳ��� ���� �ְ� �������� �� ����
    Vector3[] shootPosition; // ������Ʈ�� ���� �������� �������� ������ �߻� ��ġ ����.

    [SerializeField]
    int shootCount; // �� ���� ���ݿ� ����� Bullet ���� (������)

    float attackDelay; // �����ֱ�. �÷��̾��� ���ݼӵ��� �� �� �ְ�, �����ϴ� ������ �����ֱ�� ó���� �� ����
    float bulletSpeed; // �߻��ϴ� ��ü�� �䱸�ϴ� �Ѿ� �ӵ���

    //�Ѿ� ����, ��ų, ��ź �ֱ�
    bool isReadyAttack, isReadySkill, isReadyExplosion;


    //���� ����� ������ �ҷ��� ���� �׻� true�� �����̱� ����(���� ������, ��ų ������ �� ���� ������ ����ϹǷ�) �پ缺�� �ΰ� ������, ���� �ڵ� ȿ���� ���ؼ� ������ ����
    protected IEnumerator ActionDelay(string actionType)
    {
        SetToggleState(actionType, false);
        yield return new WaitForSeconds(attackDelay);
        SetToggleState(actionType, true);

    }
    private void Start()
    {
        Init();
    }

    // �ش� �ʱ�ȭ�� �ݵ�� ����Ŭ�������� �ݵ�� ȣ������� attackManage�� ����� �� ����.
    public void Init()
    {
        // ������Ʈ�� �����ϴ� ��ũ��Ʈ�� �ƴϴ��� ����Ƽ�� ���������� �ٸ� ������ ��ũ��Ʈ�� �ҷ��÷��� �ش� �ڵ�� �ҷ��;� ��
        attackManage = gameObject.AddComponent<AttackManage>();
        isReadyAttack = true;
        isReadySkill = true;
        isReadyExplosion = true;
    }

    public void AttackReady()
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

    //attack, skill, removeBullet
    public bool GetToggleState(string stateName)
    {
        switch (stateName)
        {
            case "attack":
                return isReadyAttack;
            case "skill":
                return isReadyAttack;
            case "removeBullet":
                return isReadyExplosion;
            default:
                Debug.Log("���ڿ��� �߸� �Է��߽��ϴ�.");
                return false;
        }
    }

    public void SetToggleState(string stateName, bool state)
    {
        switch (stateName)
        {
            case "attack":
                isReadyAttack = state;
                break;
            case "skill":
                isReadyAttack = state; //���� �ʿ�
                break;
            case "removeBullet":
                isReadyExplosion = state;
                break;
            default:
                Debug.Log("���ڿ��� �߸� �Է��߽��ϴ�.");
                break;
        }
    }

    //getset
    public void SetAttackDelay(float value)
    {
        attackDelay = value;
    }

    public float GetAttackDelay()
    {
        return attackDelay;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public void SetBulletSpeed(float value)
    {
        bulletSpeed = value;
    }

    public Vector3[] GetShootPositions()
    {
        return shootPosition;
    }

    public Vector3 GetShootPosition(int arrayIndex)
    {
        return shootPosition[arrayIndex];
    }

    public void SetShootCount(int shootCount)
    {
        this.shootCount = shootCount;
    }

    public int GetShootCount()
    {
        return shootCount;
    }

    public void SetShootVector(int index, Vector3 value) // �������� �Լ��̳� Ȥ�� �� ���� ������ ����
    {
        InputShootPosition[index] = value;
    }
}