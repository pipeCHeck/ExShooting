using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_Bullet : MonoBehaviour
{
    public float moveSpeed; // �̵� �ӵ�
    public float lifetime = 5f; // �Ѿ��� ���� �ð�

    void Start()
    {
        // ������ ���� �ð� �� �Ѿ� ����
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // �Ʒ��� �̵�
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
