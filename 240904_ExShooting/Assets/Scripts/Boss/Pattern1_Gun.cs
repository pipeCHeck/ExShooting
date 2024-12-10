using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_Gun : MonoBehaviour
{
    public float startX; // 시작 X 위치
    public float endX;   // 종료 X 위치
    public float fixedY; // 고정된 Y 위치
    public float moveSpeed = 5f; // 이동 속도

    public GameObject prefabToSpawn; // 생성할 프리팹
    public float spawnInterval = 0.8f; // 프리팹 생성 간격 (초)

    private bool isMoving = true; // 이동 상태 확인

    void Start()
    {
        // 시작 위치 설정
        transform.position = new Vector3(startX, fixedY, transform.position.z);

        // 일정 간격으로 프리팹 생성 시작
        InvokeRepeating(nameof(SpawnPrefab), 0f, spawnInterval);
    }

    void Update()
    {
        if (!isMoving) return;

        // 종료 위치에 도달하면 오브젝트 삭제
        if (Mathf.Abs(transform.position.x - endX) < 0.1f)
        {
            CancelInvoke(nameof(SpawnPrefab)); // 프리팹 생성 중단
            Destroy(gameObject); // 오브젝트 삭제
            return;
        }

        // 종료 위치로 이동
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(endX, fixedY, transform.position.z), step);
    }

    void SpawnPrefab()
    {
        // 현재 위치에 프리팹 생성
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}