using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManage : MonoBehaviour
{




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


}