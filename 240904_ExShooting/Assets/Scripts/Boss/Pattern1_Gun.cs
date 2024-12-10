using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_Gun : MonoBehaviour
{
    public float startX; // ���� X ��ġ
    public float endX;   // ���� X ��ġ
    public float fixedY; // ������ Y ��ġ
    public float moveSpeed = 5f; // �̵� �ӵ�

    public GameObject prefabToSpawn; // ������ ������
    public float spawnInterval = 0.8f; // ������ ���� ���� (��)

    private bool isMoving = true; // �̵� ���� Ȯ��

    void Start()
    {
        // ���� ��ġ ����
        transform.position = new Vector3(startX, fixedY, transform.position.z);

        // ���� �������� ������ ���� ����
        InvokeRepeating(nameof(SpawnPrefab), 0f, spawnInterval);
    }

    void Update()
    {
        if (!isMoving) return;

        // ���� ��ġ�� �����ϸ� ������Ʈ ����
        if (Mathf.Abs(transform.position.x - endX) < 0.1f)
        {
            CancelInvoke(nameof(SpawnPrefab)); // ������ ���� �ߴ�
            Destroy(gameObject); // ������Ʈ ����
            return;
        }

        // ���� ��ġ�� �̵�
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(endX, fixedY, transform.position.z), step);
    }

    void SpawnPrefab()
    {
        // ���� ��ġ�� ������ ����
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}