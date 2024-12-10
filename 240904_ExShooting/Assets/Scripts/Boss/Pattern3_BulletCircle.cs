using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3_BulletCircle : MonoBehaviour
{
    //public float rotationSpeed = 30f; // 회전 속도 (도/초)
    public GameObject bulletPrefab; // 생성할 불렛 프리팹
    public int bulletCount = 24; // 생성할 불렛 개수
    public float radius = 5f; // 원의 반지름

    private GameObject[] bullets;

    void Start()
    {
        // 랜덤한 회전 각도 생성
        float randomRotation = Random.Range(0f, 360f);

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
            bullets[i].GetComponent<Pattern3_Bullet>().Initialize(transform.position, 2f);
        }

        // 부모 오브젝트를 랜덤한 각도로 회전
        transform.Rotate(0, 0, randomRotation);
    }


    void Update()
    {
        // 원형 회전
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
