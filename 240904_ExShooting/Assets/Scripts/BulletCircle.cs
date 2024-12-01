using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircle : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ �ҷ� ������
    public int bulletCount = 24; // ������ �ҷ� ����
    public float radius = 5f; // ���� ������
    //public float rotationSpeed = 30f; // ȸ�� �ӵ� (��/��)

    private GameObject[] bullets;

    void Start()
    {
        // �ҷ� ���� �� �ʱ� ��ġ ����
        bullets = new GameObject[bulletCount];
        for (int i = 0; i < bulletCount - 6; i++)
        {
            // ������ ���� ������ ��ȯ
            float angle = i * Mathf.PI * 2f / bulletCount;
            Vector3 spawnPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            // �ҷ� ����
            bullets[i] = Instantiate(bulletPrefab, transform.position + spawnPos, Quaternion.identity);
            bullets[i].transform.parent = this.transform; // �θ� �����Ͽ� �Բ� �̵�
        }
    }

    void Update()
    {
        // ���� ȸ��
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
