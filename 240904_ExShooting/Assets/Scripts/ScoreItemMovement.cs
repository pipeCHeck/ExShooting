using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemMovement : MonoBehaviour
{
    public float jumpPower; // ������ Ƣ������� ��
    public float switchTime; // ������ �̵� ����� �ٲ�� �ð�..?? (1�ܰ�-��Ƣ�����, 2�ܰ�-�÷��̾�Կ�)
    public float moveSpeed; // ������ �̵� �ӵ�

    Rigidbody2D rb;
    GameObject player;
    Vector2 randomDirection;
    bool isFollowPlayer = false; // �÷��̾ ����ٴ��� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        randomDirection = Random.insideUnitCircle.normalized * Random.Range(1f, 1.5f); // ������ Ƣ����� ���� ���� ����
        randomDirection = new Vector2(randomDirection.x + transform.position.x, randomDirection.y + transform.position.y);
        SwitchMode(); // �÷��̾� ���� ��� Ȱ��ȭ
    }

    void Update()
    {
        Jump();
        FollowPlayer(); // �÷��̾� ����
    }

    // ó�� Ƣ������� ���� �޼���
    void Jump()
    {
        if (!isFollowPlayer)
        {
            transform.position = Vector2.Lerp(transform.position, randomDirection, Time.deltaTime * 3f);
        }
    }

    // �÷��̾� ���� ��� Ȱ��ȭ �޼���
    void SwitchMode()
    {
        StartCoroutine(SwitchModeCoroutine());
    }

    // �÷��̾� ���� ��� Ȱ��ȭ �ڷ�ƾ
    IEnumerator SwitchModeCoroutine()
    {
        yield return new WaitForSeconds(switchTime);
        rb.velocity = Vector3.zero;
        isFollowPlayer = true; // �÷��̾� ���� ����
    }

    // �÷��̾� ���� �޼��� (isFollowPlayer ������ Ȱ��ȭ)
    void FollowPlayer()
    {
        // �÷��̾ �����ϴ°�?
        if (player != null)
        {
            // �÷��̾ �i���� ����
            if (isFollowPlayer)
            {
                // �÷��̾� ���� (���� ����)
                //gameObject.transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                Vector3 direction = (player.transform.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime / (Vector3.Distance(player.transform.position, transform.position) + 3f);

            }
        }
    }
}
