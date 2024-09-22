using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManage : MonoBehaviour
{

    public void ShootStraightBullet(GameObject bullet, GameObject OrderCharacter, Vector3 shootPosition, float rotationZ, float bulletSpeed) // �Ϲ����� �������� ���� �ʱⰪ�� �״�� ���ư��� Ư¡�� ����. �ش� �Լ��� �䱸�ϴ� �Ķ���͵��� ���� ����� �� ����.
    {
        Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
        instanceBullet.SetMoveSpeed(bulletSpeed);
        instanceBullet.SetRotationZ(rotationZ);
        instanceBullet.SetTag(InitTag(OrderCharacter));
        instanceBullet.SetDamage(OrderCharacter.GetComponent<Character>().GetDamage());
    }

    public void ShootTargetBullet(GameObject bullet, GameObject OrderCharacter, string targetCharacter, Vector3 shootPosition, float bulletSpeed) //�ش� ����� ��ġ�� �޾Ƴ��� �߻��ϴ� ���
    {
        GameObject target = GameObject.FindWithTag(targetCharacter);
        if(target != null)
        {
            Bullet instanceBullet = Instantiate(bullet, shootPosition, transform.rotation).GetComponent<Bullet>();
            float angle = Mathf.Atan2(target.transform.position.y - OrderCharacter.transform.position.y, target.transform.position.x - OrderCharacter.transform.position.x) * Mathf.Rad2Deg; //������ �ߴ� �ش� �������� Ÿ���ϱ�
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

    string InitTag(GameObject character) //�÷��̾��� �Ѿ�����, ���� �Ѿ����� �����ϴ� ������� �������� �±׸� Ȯ���Ͽ� ������
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

}