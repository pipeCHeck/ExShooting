using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_Wave : EnemyMove
{
    public float verticalSpeed = 2f; // ���Ʒ��� �̵��ϴ� �ӵ�
    public float minY = -3f;       // Y�� �ּ� ��ġ
    public float maxY = 3f;        // Y�� �ִ� ��ġ

    private bool movingUp = true;  // ���� �̵� ������ ����

    protected override void Move()
    {
        base.Move();        
        // �������� ������ �ӵ��� �̵�
        transform.Translate(Vector2.left * GetMoveSpeed() * Time.deltaTime);

        // Y�� ���� �̵�
        Vector3 position = transform.position;

        if (movingUp)
        {
            position.y += verticalSpeed * Time.deltaTime;
            if (position.y >= maxY)
            {
                position.y = maxY;
                movingUp = false; // ���� ��ȯ
            }
        }
        else
        {
            position.y -= verticalSpeed * Time.deltaTime;
            if (position.y <= minY)
            {
                position.y = minY;
                movingUp = true; // ���� ��ȯ
            }
        }

        // ����� ��ġ�� ����
        transform.position = position;
    }
}