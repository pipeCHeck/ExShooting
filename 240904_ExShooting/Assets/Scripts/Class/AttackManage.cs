using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManage : MonoBehaviour
{
    //총알 공격, 스킬, 폭탄 주기
    bool isReadyAttack, isReadySkill, isReadyExplosion; //반드시 init 함수 내용에 true로 할 것


    public void Init()
    {
        isReadyAttack = true;
        isReadySkill = true;
        isReadyExplosion = true;
    }

    // 일반적인 슈팅으로 방향 초기값을 그대로 나아가는 특징이 있음. 해당 함수가 요구하는 파라미터들이 추후 변경될 수 있음.
    public void ShootStraightBullet(GameObject bullet, GameObject OrderCharacter, Vector3 shootPosition, float rotationZ, float bulletSpeed) 
    {
        Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
        instanceBullet.SetMoveSpeed(bulletSpeed);
        instanceBullet.SetRotationZ(rotationZ);
        instanceBullet.SetTag(InitTag(OrderCharacter));
        instanceBullet.SetDamage(OrderCharacter.GetComponent<Character>().GetDamage());
    }

    //해당 대상의 위치를 받아내어 발사하는 방식
    public void ShootTargetBullet(GameObject bullet, GameObject OrderCharacter, string targetCharacter, Vector3 shootPosition, float bulletSpeed) 
    {
        GameObject target = GameObject.FindWithTag(targetCharacter);
        if(target != null)
        {
            Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
            //수업때 했던 해당 방향으로 타겟하기
            float angle = Mathf.Atan2(target.transform.position.y - OrderCharacter.transform.position.y, target.transform.position.x - OrderCharacter.transform.position.x) * Mathf.Rad2Deg; 
            instanceBullet.SetMoveSpeed(bulletSpeed);
            instanceBullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            instanceBullet.SetTag(InitTag(OrderCharacter));
            instanceBullet.SetDamage(OrderCharacter.GetComponent<Character>().GetDamage());

        }
        else
        {
            Debug.Log("Target not found");
        }

    }

    //플레이어의 총알인지, 적의 총알인지 필터하는 기능으로 시전자의 태그를 확인하여 결정함
    string InitTag(GameObject character)
    {
        if (character.transform.tag == "Player")
        {
            return "PlayerBullet";
        }
        else //보통 총알을 소환하면 Enemy 태그인 클래스이나, 추후 기획서가 추가되어 변동이 생길 시 예외가 생길 수 있음
        {
            return "EnemyBullet";
        }
    }

    public void TransBoolData(ref bool data)
    {
        if (data)
        {
            data = false;
        }
        else
        {
            data = true;
        }
    }

    public bool GetIsReadyAttack()
    {
        return isReadyAttack;
    }

    //해당 코드로 다시 수정했는데, bool 타입의 상태 부분에서 추후에 많이 안생길 것 같다는 판단 하에 이러한 과정을 삽입하였음. 좋고 효율적인 아이디어가 있을 경우 반드시 언급해줄 것
    public void SetToggleState(string stateName, bool state)
    {
        switch (stateName)
        {
            //해당 알고리즘이 그나마 낫다고 판단하다면 이러한 문자 형태는 어떠한 지, 혹은 이러한 경우에 어떤 식으로 이름을 적는 지 언급해줄 것
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
}