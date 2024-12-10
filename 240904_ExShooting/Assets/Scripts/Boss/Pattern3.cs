using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3 : MonoBehaviour
{
    public GameObject pattern; // 생성할 패턴 프리팹
    Transform playerTransform; // 플레이어의 Transform
    GameObject player; // 플레이어 오브젝트

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        StartCoroutine(SpawnPrefabAtPlayer());
    }

    IEnumerator SpawnPrefabAtPlayer()
    {
        int spawnCount = 0;

        while (spawnCount < 3) // 3번 반복
        {
            // 플레이어 위치에 패턴 프리팹 생성
            playerTransform = player.transform;
            Instantiate(pattern, playerTransform.position, Quaternion.identity);
            spawnCount++;

            // 1초 대기
            yield return new WaitForSeconds(1f);
        }
    }
}