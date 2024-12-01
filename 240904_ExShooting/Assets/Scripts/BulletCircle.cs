using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircle : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 불렛 프리팹
    public int bulletCount = 24; // 생성할 불렛 개수
    public float radius = 5f; // 원의 반지름
    //public float rotationSpeed = 30f; // 회전 속도 (도/초)

    private GameObject[] bullets;

    void Start()
    {
        // 불렛 생성 및 초기 위치 설정
        bullets = new GameObject[bulletCount];
        for (int i = 0; i < bulletCount - 6; i++)
        {
            // 각도를 라디안 값으로 변환
            float angle = i * Mathf.PI * 2f / bulletCount;
            Vector3 spawnPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            // 불렛 생성
            bullets[i] = Instantiate(bulletPrefab, transform.position + spawnPos, Quaternion.identity);
            bullets[i].transform.parent = this.transform; // 부모를 설정하여 함께 이동
        }
    }

    void Update()
    {
        // 원형 회전
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
