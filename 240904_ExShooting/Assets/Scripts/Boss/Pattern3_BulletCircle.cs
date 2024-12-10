using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3_BulletCircle : MonoBehaviour
{
    //public float rotationSpeed = 30f; // ȸ�� �ӵ� (��/��)
    public GameObject bulletPrefab; // ������ �ҷ� ������
    public int bulletCount = 24; // ������ �ҷ� ����
    public float radius = 5f; // ���� ������

    private GameObject[] bullets;

    void Start()
    {
        // ������ ȸ�� ���� ����
        float randomRotation = Random.Range(0f, 360f);

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
            bullets[i].GetComponent<Pattern3_Bullet>().Initialize(transform.position, 2f);
        }

        // �θ� ������Ʈ�� ������ ������ ȸ��
        transform.Rotate(0, 0, randomRotation);
    }


    void Update()
    {
        // ���� ȸ��
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
