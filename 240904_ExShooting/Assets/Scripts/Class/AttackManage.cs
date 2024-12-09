using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManage : MonoBehaviour
{


    // 일반적인 슈팅으로 방향 초기값을 그대로 나아가는 특징이 있음. 해당 함수가 요구하는 파라미터들이 추후 변경될 수 있음.
    public void ShootStraightBullet(GameObject bullet, GameObject orderCharacter, Vector3 shootPosition, float rotationZ, float bulletSpeed) 
    {
        //총알을 인스턴스화하여 해당 총알의 기본 옵션을 설정. 발사 각도, 총알의 능력치를 설정(투사 속도, 격발자, 데미지)
        Weapon instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Weapon>();
        instanceBullet.SetRotationZ(rotationZ);
        instanceBullet.SetWeaponData(bulletSpeed, InitTag(orderCharacter), orderCharacter.GetComponent<Character>().GetDamage());
    }

    //해당 대상의 위치를 받아내어 발사하는 방식
    public void ShootTargetBullet(GameObject bullet, GameObject orderCharacter, string targetCharacter, Vector3 shootPosition, float bulletSpeed) 
    {
        //해당 목표 타깃을 불러와 대상 위치를 향해 발사
        GameObject target = GameObject.FindWithTag(targetCharacter);
        if(target != null)
        {
            //총알 인스턴스화
            Weapon instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Weapon>();
            //수업때 했던 해당 방향으로 타겟하기. 대상 윌치로 각도를 지정하여 발사하는 공식
            float angle = Mathf.Atan2(target.transform.position.y - orderCharacter.transform.position.y, target.transform.position.x - orderCharacter.transform.position.x) * Mathf.Rad2Deg; 
            instanceBullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            //총알의 능력치 설정(이하 동일)
            instanceBullet.SetWeaponData(bulletSpeed, InitTag(orderCharacter), orderCharacter.GetComponent<Character>().GetDamage());
        }
        else
        {
            Debug.Log("Target not found");
        }

    }

    // 스킬 형태의 미사일 발사. 현재는 사용하지 않음
    public void ShootMisiile(GameObject missile, GameObject orderCharacter, Vector3 shootVec, int shootCount, float bulletSpeed, float shootDelay)
    {
        //StartCoroutine(MissileShooting(missile, orderCharacter, shootVec, shootCount, bulletSpeed, shootDelay));
        Debug.Log("this funtion is not yet");
    }

    public void ShootMisiile(GameObject missile, GameObject orderCharacter, Vector3 shootVec, float bulletSpeed)
    {
        //미사일 인스턴스화 및 미사일 능력치 설정(이하동일)
        //Weapon instanceBullet = Instantiate(missile, shootVec, transform.rotation).GetComponent<Weapon>();
        Weapon instanceBullet = Instantiate(missile, shootVec, Quaternion.Euler(0, 0, -90f)).GetComponent<Weapon>();
        instanceBullet.SetWeaponData(bulletSpeed, InitTag(orderCharacter), orderCharacter.GetComponent<Character>().GetDamage());
    }


    // 만약 스킬성으로 제한된 미사일을 발사한다면 이러한 형태일 것
    IEnumerator MissileShooting(GameObject missile, GameObject orderCharacter, Vector3 shootVec, int shootCount, float bulletSpeed, float shootDelay)
    {
        for(int i = 0; i < shootCount; i++)
        {
            //설정된 개수만큼 플레이어에 미사일을 발사한다. 각각 이동속도, 태그값, 피해량을 정의하며, 발사 주기까지도 설정할 수 있음
            Bullet instanceBullet = Instantiate(missile, shootVec, transform.rotation).GetComponent<Bullet>();
            instanceBullet.SetMoveSpeed(bulletSpeed);
            instanceBullet.SetTag(InitTag(orderCharacter));
            instanceBullet.SetDamage(orderCharacter.GetComponent<Character>().GetDamage());
            yield return new WaitForSeconds(shootDelay);
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
    


}