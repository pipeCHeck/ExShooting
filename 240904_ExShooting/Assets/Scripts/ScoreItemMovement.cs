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
    bool isFollowPlayer = false; // �÷��̾ ����ٴ��� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Jump(); // Ƣ������� ����
        SwitchMode(); // �÷��̾� ���� ��� Ȱ��ȭ
    }

    void Update()
    {
        FollowPlayer(); // �÷��̾� ����
    }

    // ó�� Ƣ������� ���� �޼���
    void Jump()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // ������ Ƣ����� ���� ���� ����
        //Debug.Log(randomDirection);
        rb.AddForce(randomDirection, ForceMode2D.Impulse); // ������ Ƣ�����
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
                gameObject.transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
