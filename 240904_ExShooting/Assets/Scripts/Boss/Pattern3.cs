using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3 : MonoBehaviour
{
    public GameObject pattern; // ������ ���� ������
    Transform playerTransform; // �÷��̾��� Transform
    GameObject player; // �÷��̾� ������Ʈ

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        StartCoroutine(SpawnPrefabAtPlayer());
    }

    IEnumerator SpawnPrefabAtPlayer()
    {
        int spawnCount = 0;

        while (spawnCount < 3) // 3�� �ݺ�
        {
            // �÷��̾� ��ġ�� ���� ������ ����
            playerTransform = player.transform;
            Instantiate(pattern, playerTransform.position, Quaternion.identity);
            spawnCount++;

            // 1�� ���
            yield return new WaitForSeconds(1f);
        }
    }
}