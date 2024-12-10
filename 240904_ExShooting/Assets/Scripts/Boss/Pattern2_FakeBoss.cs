using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_FakeBoss : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 총알 프리팹
    public float fireRate = 1f; // 총알 발사 간격 (초)
    public float bulletSpeed = 5f; // 총알 속도
    public int maxBullets = 15; // 최대 발사할 총알 수

    private GameObject player; // 플레이어 오브젝트
    private float fireCooldown = 0f; // 발사 대기 시간
    private int bulletsFired = 0; // 발사한 총알 수

    void Start()
    {
        // 태그가 "Player"인 오브젝트를 찾음
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("플레이어 오브젝트 없음");
        }
    }

    void Update()
    {
        if (player == null || bulletsFired >= maxBullets) Destroy(gameObject); // 발사 제한

        // 플레이어를 바라봄
        LookAtPlayer();

        // 총알 발사
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            ShootAtPlayer();
            fireCooldown = fireRate; // 발사 대기 시간 초기화
        }
    }

    void LookAtPlayer()
    {
        // 회전 방향 계산
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // 실제 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ShootAtPlayer()
    {
        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // 총알에 속도 적용
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * bulletSpeed; // 총알 발사
        }

        // 발사한 총알 수 증가
        bulletsFired++;
    }
}
