using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    GameObject targetObject;
    Vector3[] targetObjectsVec;
    Vector3 tununingDir;
    float rotationSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed());
        TunningObject();
    }

    //���� ������Ʈ�� Ž���ϴ� ����
    void TargetSearching()
    {
        //����� ������Ʈ�� �˾Ƴ��� ���� �Ӽ� �ʱⰪ�� ũ�� �־� �ܰŸ��� �����ϱ� ����
        float targetObjectDistance = 100f;

        //�����ϴ� �� ������Ʈ Ž��
        GameObject[] instanceObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //Ÿ�ٵ��� ������ ũ�� ����
        targetObjectsVec = new Vector3[instanceObjects.Length];

        //������ ��ġ�� ����. ����� ������Ʈ�� ã�ƾ� �ϱ� ����
        for (int i = 0; i < targetObjectsVec.Length; i++)
        {
            targetObjectsVec[i] = instanceObjects[i].GetComponent<Enemy>().transform.position;

            //�Ÿ� �� �� ������Ʈ �� �Ÿ� ����. ���� �÷��̾� ������ ������Ʈ�� Ž���ϴ� ������ ����
            if (targetObjectDistance > targetObjectsVec[i].magnitude)
            {
                targetObjectDistance = targetObjectsVec[i].magnitude;
                targetObject = instanceObjects[i];
            }
        }
    }

    //missile�� ��� ����ź�̹Ƿ� ȸ���Ѵ�
    void TunningObject()
    {
        //�ش� ��ǥ���� ���� ���� ȸ���ϴ� ���. ���� Ÿ���� ������� ��� ��Ž���� �Ѵ�
        if (targetObject != null)
        {
            /*
            Vector2 direction2D = (Vector2)(targetObject.transform.position - transform.position).normalized;
            transform.up = Vector2.Lerp(transform.up, direction2D, 0.1f);
            */

            Vector2 direction = (targetObject.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // ���� ���ϱ�
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Z�� ȸ���� ����


            Quaternion rotateValue = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);

            transform.rotation = rotateValue;
        }
        else //targetResearching
        {
            TargetSearching();
        }
    }

    protected override void Init()
    {
        base.Init();

        // �ݹ��� Ȯ���� ȸ���ϴ� ���� ��ü�� ������
        if (Random.Range(0, 2) == 1)
        {
            rotationSpeed *= -1;
        }
        //�̻����� ���� ������ �����̱�
        SetMoveSpeed(GetMoveSpeed() - 7f);
        //�������ڸ��� Ÿ�� ����
        TargetSearching();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HitCharacterByCollision(ref other);
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }

    public void SetRotationSpeed(float rotateValue)
    {
        rotationSpeed = rotateValue;
    }
}
