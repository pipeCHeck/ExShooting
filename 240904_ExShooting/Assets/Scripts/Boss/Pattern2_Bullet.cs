using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_Bullet : MonoBehaviour
{
    public float lifetime = 5f; // 총알의 생존 시간

    void Start()
    {
        // 지정된 생존 시간 후 총알 제거
        Destroy(gameObject, lifetime);
    }
}