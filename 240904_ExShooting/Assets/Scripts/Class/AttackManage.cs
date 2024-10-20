using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManage : MonoBehaviour
{




    // �Ϲ����� �������� ���� �ʱⰪ�� �״�� ���ư��� Ư¡�� ����. �ش� �Լ��� �䱸�ϴ� �Ķ���͵��� ���� ����� �� ����.
    public void ShootStraightBullet(GameObject bullet, GameObject OrderCharacter, Vector3 shootPosition, float rotationZ, float bulletSpeed) 
    {
        Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
        instanceBullet.SetMoveSpeed(bulletSpeed);
        instanceBullet.SetRotationZ(rotationZ);
        instanceBullet.SetTag(InitTag(OrderCharacter));
        instanceBullet.SetDamage(OrderCharacter.GetComponent<Character>().GetDamage());
    }

    //�ش� ����� ��ġ�� �޾Ƴ��� �߻��ϴ� ���
    public void ShootTargetBullet(GameObject bullet, GameObject OrderCharacter, string targetCharacter, Vector3 shootPosition, float bulletSpeed) 
    {
        GameObject target = GameObject.FindWithTag(targetCharacter);
        if(target != null)
        {
            Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
            //������ �ߴ� �ش� �������� Ÿ���ϱ�
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