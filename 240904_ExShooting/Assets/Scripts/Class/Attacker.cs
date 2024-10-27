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
    Vector3[] InputShootPosition; // 각 공격하는 클래스들의 발사위치가 존재함. 하나일 수도 있고 여러곳일 수 있음
    Vector3[] shootPosition; // 오브젝트의 로컬 포지션을 기준으로 설정한 발사 위치 정의.

    [SerializeField]
    int shootCount; // 한 번의 공격에 사용할 Bullet 갯수 (김진우)

    float attackDelay; // 공격주기. 플레이어의 공격속도가 될 수 있고, 공격하는 몬스터의 공격주기로 처리할 수 있음
    float bulletSpeed; // 발사하는 주체가 요구하는 총알 속도값

    //총알 공격, 스킬, 폭탄 주기
    bool isReadyAttack, isReadySkill, isReadyExplosion;


    //현재 설계된 구조는 불러온 값은 항상 true인 구조이기 때문(어택 딜레이, 스킬 딜레이 등 여러 목적에 사용하므로) 다양성을 두고 있으나, 추후 코드 효율에 대해서 논의할 예정
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

    // 해당 초기화는 반드시 하위클래스들이 반드시 호출해줘야 attackManage를 사용할 수 있음.
    public void Init()
    {
        // 오브젝트에 존재하는 스크립트가 아니더라도 유니티는 형식적으로 다른 순수의 스크립트를 불러올려면 해당 코드로 불러와야 됨
        attackManage = gameObject.AddComponent<AttackManage>();
        isReadyAttack = true;
        isReadySkill = true;
        isReadyExplosion = true;
    }

    public void AttackReady()
    {
        if(InputShootPosition != null) // 발사위치를 로드하는 과정
        {
            shootPosition = new Vector3[InputShootPosition.Length];
            for (int i = 0; i < shootPosition.Length; i++)
            {
                // shootVector의 값과 캐릭터의 위치를 더하면 발사위치로 계산됨.
                shootPosition[i] = this.gameObject.transform.position + InputShootPosition[i]; 
            }
        }
        else
        {
            Debug.Log("shootVector 내 배열이 비어있음");
        }
        StartCoroutine(ActionDelay("attack")); //총을 발사할 것이므로 재발사하기 위한 대기시간.
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
                Debug.Log("문자열을 잘못 입력했습니다.");
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
                isReadyAttack = state; //수정 필요
                break;
            case "removeBullet":
                isReadyExplosion = state;
                break;
            default:
                Debug.Log("문자열을 잘못 입력했습니다.");
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

    public void SetShootVector(int index, Vector3 value) // 형식적인 함수이나 혹시 쓸 수도 있으니 보류
    {
        InputShootPosition[index] = value;
    }
}