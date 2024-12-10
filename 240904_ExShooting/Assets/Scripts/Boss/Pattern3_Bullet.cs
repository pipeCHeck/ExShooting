using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3_Bullet : MonoBehaviour
{
    private Vector3 targetPosition; // �̵��� ��ǥ ��ġ
    private float moveSpeed = 5f;   // �̵� �ӵ�

    public void Initialize(Vector3 target, float speed)
    {
        // ��ǥ ��ġ�� �ӵ��� ����
        targetPosition = target;
        moveSpeed = speed;
    }

    void Start()
    {
        StartCoroutine(MoveToTarget()); // �̵� ����
    }

    IEnumerator MoveToTarget()
    {
        // ������Ʈ�� ��ǥ ��ġ�� ������ ������ �ݺ� (�Ÿ��� ������)
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // ��ǥ ��ġ���� ������ �ӵ��� �̵���
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // ���� �����ӱ��� ���
        }

        // ��Ȯ�� ��ġ�� ���� (���� ����)
        transform.position = targetPosition;

        // �̵� �Ϸ� �� ����
        Destroy(gameObject);
    }
}
