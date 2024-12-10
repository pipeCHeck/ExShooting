using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_Bullet : MonoBehaviour
{
    public float moveSpeed; // 이동 속도
    public float lifetime = 5f; // 총알의 생존 시간

    void Start()
    {
        // 지정된 생존 시간 후 총알 제거
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // 아래로 이동
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
