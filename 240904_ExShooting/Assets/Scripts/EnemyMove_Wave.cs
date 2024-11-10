using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_Wave : EnemyMove
{
    public float verticalSpeed = 2f; // 위아래로 이동하는 속도
    public float minY = -3f;       // Y축 최소 위치
    public float maxY = 3f;        // Y축 최대 위치

    private bool movingUp = true;  // 위로 이동 중인지 여부

    protected override void Move()
    {
        base.Move();        
        // 좌측으로 일정한 속도로 이동
        transform.Translate(Vector2.left * GetMoveSpeed() * Time.deltaTime);

        // Y축 상하 이동
        Vector3 position = transform.position;

        if (movingUp)
        {
            position.y += verticalSpeed * Time.deltaTime;
            if (position.y >= maxY)
            {
                position.y = maxY;
                movingUp = false; // 방향 전환
            }
        }
        else
        {
            position.y -= verticalSpeed * Time.deltaTime;
            if (position.y <= minY)
            {
                position.y = minY;
                movingUp = true; // 방향 전환
            }
        }

        // 변경된 위치를 적용
        transform.position = position;
    }
}