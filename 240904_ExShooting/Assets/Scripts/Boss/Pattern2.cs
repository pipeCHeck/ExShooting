using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    public GameObject prefabA; // 생성할 프리팹
    public int spawnCount = 3; // 생성할 프리팹 개수

    // Inspector에서 입력받을 범위
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 10f;

    public float minDistanceFromPlayer = 3f; // 플레이어와의 최소 거리
    private GameObject player; // 플레이어 오브젝트

    void Start()
    {
        // 태그로 플레이어 오브젝트 찾기
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        if (player == null)
        {
            Debug.LogError("플레이어 오브젝트가 없음");
            return;
        }

        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition;
            int maxAttempts = 10; // 최대 시도 횟수
            int attempts = 0;

            do
            {
                // 범위 안에서 랜덤한 위치 생성
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                spawnPosition = new Vector3(randomX, randomY, 0f);

                attempts++;

                // 최대 시도 횟수를 초과하면 루프 탈출
                if (attempts >= maxAttempts)
                {
                    break;
                }

            } while (Vector3.Distance(player.transform.position, spawnPosition) < minDistanceFromPlayer);

            // 프리팹 생성
            Instantiate(prefabA, spawnPosition, Quaternion.identity);
        }
    }
}
