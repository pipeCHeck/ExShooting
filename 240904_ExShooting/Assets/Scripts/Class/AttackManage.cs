using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManage : MonoBehaviour
{


    // �Ϲ����� �������� ���� �ʱⰪ�� �״�� ���ư��� Ư¡�� ����. �ش� �Լ��� �䱸�ϴ� �Ķ���͵��� ���� ����� �� ����.
    public void ShootStraightBullet(GameObject bullet, GameObject orderCharacter, Vector3 shootPosition, float rotationZ, float bulletSpeed) 
    {
        Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
        instanceBullet.SetMoveSpeed(bulletSpeed);
        instanceBullet.SetRotationZ(rotationZ);
        instanceBullet.SetTag(InitTag(orderCharacter));
        instanceBullet.SetDamage(orderCharacter.GetComponent<Character>().GetDamage());
    }

    //�ش� ����� ��ġ�� �޾Ƴ��� �߻��ϴ� ���
    public void ShootTargetBullet(GameObject bullet, GameObject orderCharacter, string targetCharacter, Vector3 shootPosition, float bulletSpeed) 
    {
        GameObject target = GameObject.FindWithTag(targetCharacter);
        if(target != null)
        {
            Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
            //������ �ߴ� �ش� �������� Ÿ���ϱ�
            float angle = Mathf.Atan2(target.transform.position.y - orderCharacter.transform.position.y, target.transform.position.x - orderCharacter.transform.position.x) * Mathf.Rad2Deg; 
            instanceBullet.SetMoveSpeed(bulletSpeed);
            instanceBullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            instanceBullet.SetTag(InitTag(orderCharacter));
            instanceBullet.SetDamage(orderCharacter.GetComponent<Character>().GetDamage());
        }
        else
        {
            Debug.Log("Target not found");
        }

    }

    // ��ų ������ �̻��� �߻�
    public void ShootMisiile(GameObject missile, GameObject orderCharacter, Vector3 shootVec, int shootCount, float bulletSpeed, float shootDelay)
    {
        //StartCoroutine(MissileShooting(missile, orderCharacter, shootVec, shootCount, bulletSpeed, shootDelay));
        Debug.Log("this funtion is not yet");
    }

    public void ShootMisiile(GameObject missile, GameObject orderCharacter, Vector3 shootVec, float bulletSpeed)
    {
        Bullet instanceBullet = Instantiate(missile, shootVec, transform.rotation).GetComponent<Bullet>();
        instanceBullet.SetMoveSpeed(bulletSpeed);
        instanceBullet.SetTag(InitTag(orderCharacter));
        instanceBullet.SetDamage(orderCharacter.GetComponent<Character>().GetDamage());
    }


     // ���� ��ų������ ���ѵ� �̻����� �߻��Ѵٸ� �̷��� ������ ��
    IEnumerator MissileShooting(GameObject missile, GameObject orderCharacter, Vector3 shootVec, int shootCount, float bulletSpeed, float shootDelay)
    {
        for(int i = 0; i < shootCount; i++)
        {
            Bullet instanceBullet = Instantiate(missile, shootVec, transform.rotation).GetComponent<Bullet>();
            instanceBullet.SetMoveSpeed(bulletSpeed);
            instanceBullet.SetTag(InitTag(orderCharacter));
            instanceBullet.SetDamage(orderCharacter.GetComponent<Character>().GetDamage());
            yield return new WaitForSeconds(shootDelay);
        }
    }
    

    //�÷��̾��� �Ѿ�����, ���� �Ѿ����� �����ϴ� ������� �������� �±׸� Ȯ���Ͽ� ������
    string InitTag(GameObject character)
    {
        if (character.transform.tag == "Player")
        {
            return "PlayerBullet";
        }
        else //���� �Ѿ��� ��ȯ�ϸ� Enemy �±��� Ŭ�����̳�, ���� ��ȹ���� �߰��Ǿ� ������ ���� �� ���ܰ� ���� �� ����
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