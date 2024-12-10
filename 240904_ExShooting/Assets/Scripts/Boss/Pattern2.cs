using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    public GameObject prefabA; // ������ ������
    public int spawnCount = 3; // ������ ������ ����

    // Inspector���� �Է¹��� ����
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 10f;

    public float minDistanceFromPlayer = 3f; // �÷��̾���� �ּ� �Ÿ�
    private GameObject player; // �÷��̾� ������Ʈ

    void Start()
    {
        // �±׷� �÷��̾� ������Ʈ ã��
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        if (player == null)
        {
            Debug.LogError("�÷��̾� ������Ʈ�� ����");
            return;
        }

        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition;
            int maxAttempts = 10; // �ִ� �õ� Ƚ��
            int attempts = 0;

            do
            {
                // ���� �ȿ��� ������ ��ġ ����
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                spawnPosition = new Vector3(randomX, randomY, 0f);

                attempts++;

                // �ִ� �õ� Ƚ���� �ʰ��ϸ� ���� Ż��
                if (attempts >= maxAttempts)
                {
                    break;
                }

            } while (Vector3.Distance(player.transform.position, spawnPosition) < minDistanceFromPlayer);

            // ������ ����
            Instantiate(prefabA, spawnPosition, Quaternion.identity);
        }
    }
}
