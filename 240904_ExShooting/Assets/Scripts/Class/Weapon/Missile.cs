using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : Bullet
{
    GameObject targetObject;
    Vector3[] targetObjectsVec;
    Vector3 tununingDir;
    float rotationSpeed = 1f; //�̻����� ȸ���� �� �ִ� �ִ� ����. �̻����� Ư�� ������Ʈ�� �߰��ϴ� �ð��� ����� ���� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        TunningObject();
    }

    //���� ������Ʈ�� Ž���ϴ� ����
    void TargetSearching()
    {
        //����� ������Ʈ�� �˾Ƴ��� ���� �Ӽ� �ʱⰪ�� ũ�� �־� �ܰŸ��� �����ϱ� ����
        float targetObjectDistance = 200f;

        //�����ϴ� �� ������Ʈ Ž��
        GameObject[] instanceObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //Ÿ�ٵ��� ������ ũ�� ����
        targetObjectsVec = new Vector3[instanceObjects.Length];
        float targetDistance = 0;
        //������ ��ġ�� ����. ����� ������Ʈ�� ã�ƾ� �ϱ� ����
        for (int i = 0; i < targetObjectsVec.Length; i++)
        {
            targetObjectsVec[i] = instanceObjects[i].GetComponent<Character>().transform.position;
            targetDistance = (targetObjectsVec[i] - this.transform.position).magnitude;
            //�Ѿ˰� ���� �Ÿ� �� �� ������Ʈ �� �Ÿ� ����. ���� ȭ�� ���� ���� ����� ���� ���� �������� Ž��
            if (targetObjectDistance > targetDistance &&
                Mathf.Abs(targetObjectsVec[i].x) <= 11 &&
                Mathf.Abs(targetObjectsVec[i].y) <= 5)
            {
                targetObjectDistance = targetDistance;
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
            //�ٸ� ������ ����ź1. 
            Vector2 direction2D = (Vector2)(targetObject.transform.position - transform.position).normalized;
            transform.up = Vector2.Lerp(transform.up, direction2D, 0.1f);
            */



            // ��ǥ ���� ���� ���
            Vector3 directionToTarget = (targetObject.transform.position - transform.position).normalized;

            // ���� ���͸� ����� �� 2D������ up�� �������� ��
            Vector3 currentForward = transform.up; 

            
            // ȸ�� ���� ���
            float angle = Vector3.SignedAngle(currentForward, directionToTarget, Vector3.forward);

            // ȸ�� ����
            if (angle != 0)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, angle * GetRotationSpeed() * Time.deltaTime);
                transform.rotation = rotation * transform.rotation;
                // ȸ������ ���ϴ� ������ ������ ������ ������ �����ϸ� ����ź ���� ���� ������ �Ǹ�, ���� �ָ� ������Ʈ�� ������ ���ϰ� �����ϴµ��� ������ ���δ�.
                // �̷� ���� �ѹ� Ÿ���� ���� ������Ʈ�� ������ ����� ���� ȸ�� �Ѱ谪�� �÷� �ᱹ �����ϰ� ����
                SetRotationSpeed(GetRotationSpeed() + 1.5f);
            }

            Debug.Log(GetMoveSpeed());
        }
        else //targetResearching
        {
            TargetSearching();
            //�� ȸ������ ���ϴ� ������ ���ؼ� Ÿ���� ����� ��Ž���ϰų� ���� Ž���� �� �� �ʱ�ȭ�� �ؾ��Ѵ� 
            SetRotationSpeed(0.5f);
        }
    }

    protected override void Init()
    {
        base.Init();

        //�̻����� ���� ������ �����̱�
        SetMoveSpeed(15f);
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
