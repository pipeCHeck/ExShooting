using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_Bullet : MonoBehaviour
{
    public float lifetime = 5f; // �Ѿ��� ���� �ð�

    void Start()
    {
        // ������ ���� �ð� �� �Ѿ� ����
        Destroy(gameObject, lifetime);
    }
}