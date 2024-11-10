using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemMovement : MonoBehaviour
{
    public float jumpPower; // 코인이 튀어오르는 힘
    public float switchTime; // 코인의 이동 방식이 바뀌는 시간..?? (1단계-퐁튀어오름, 2단계-플레이어에게옴)
    public float moveSpeed; // 코인의 이동 속도

    Rigidbody2D rb;
    GameObject player;
    Vector2 randomDirection;
    bool isFollowPlayer = false; // 플레이어를 따라다닐지 여부

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        randomDirection = Random.insideUnitCircle.normalized * Random.Range(1f, 1.5f); // 옆으로 튀어오를 방향 랜덤 설정
        randomDirection = new Vector2(randomDirection.x + transform.position.x, randomDirection.y + transform.position.y);
        SwitchMode(); // 플레이어 추적 모드 활성화
    }

    void Update()
    {
        Jump();
        FollowPlayer(); // 플레이어 추적
    }

    // 처음 튀어오르는 점프 메서드
    void Jump()
    {
        if (!isFollowPlayer)
        {
            transform.position = Vector2.Lerp(transform.position, randomDirection, Time.deltaTime * 3f);
        }
    }

    // 플레이어 추적 모드 활성화 메서드
    void SwitchMode()
    {
        StartCoroutine(SwitchModeCoroutine());
    }

    // 플레이어 추적 모드 활성화 코루틴
    IEnumerator SwitchModeCoroutine()
    {
        yield return new WaitForSeconds(switchTime);
        rb.velocity = Vector3.zero;
        isFollowPlayer = true; // 플레이어 추적 시작
    }

    // 플레이어 추적 메서드 (isFollowPlayer 변수로 활성화)
    void FollowPlayer()
    {
        // 플레이어가 존재하는가?
        if (player != null)
        {
            // 플레이어를 쫒는지 여부
            if (isFollowPlayer)
            {
                // 플레이어 추적 (보간 적용)
                //gameObject.transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                Vector3 direction = (player.transform.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime / (Vector3.Distance(player.transform.position, transform.position) + 3f);

            }
        }
    }
}
