using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3_Bullet : MonoBehaviour
{
    private Vector3 targetPosition; // 이동할 목표 위치
    private float moveSpeed = 5f;   // 이동 속도

    public void Initialize(Vector3 target, float speed)
    {
        // 목표 위치와 속도를 설정
        targetPosition = target;
        moveSpeed = speed;
    }

    void Start()
    {
        StartCoroutine(MoveToTarget()); // 이동 시작
    }

    IEnumerator MoveToTarget()
    {
        // 오브젝트가 목표 위치에 도달할 때까지 반복 (거리를 측정함)
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // 목표 위치까지 정해진 속도로 이동함
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }

        // 정확한 위치로 설정 (오차 보정)
        transform.position = targetPosition;

        // 이동 완료 후 삭제
        Destroy(gameObject);
    }
}
