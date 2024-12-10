using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_FakeBoss : MonoBehaviour
{
    public GameObject bulletPrefab; // �߻��� �Ѿ� ������
    public float fireRate = 1f; // �Ѿ� �߻� ���� (��)
    public float bulletSpeed = 5f; // �Ѿ� �ӵ�
    public int maxBullets = 15; // �ִ� �߻��� �Ѿ� ��

    private GameObject player; // �÷��̾� ������Ʈ
    private float fireCooldown = 0f; // �߻� ��� �ð�
    private int bulletsFired = 0; // �߻��� �Ѿ� ��

    void Start()
    {
        // �±װ� "Player"�� ������Ʈ�� ã��
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("�÷��̾� ������Ʈ ����");
        }
    }

    void Update()
    {
        if (player == null || bulletsFired >= maxBullets) Destroy(gameObject); // �߻� ����

        // �÷��̾ �ٶ�
        LookAtPlayer();

        // �Ѿ� �߻�
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            ShootAtPlayer();
            fireCooldown = fireRate; // �߻� ��� �ð� �ʱ�ȭ
        }
    }

    void LookAtPlayer()
    {
        // ȸ�� ���� ���
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // ���� ȸ��
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ShootAtPlayer()
    {
        // �Ѿ� ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // �Ѿ˿� �ӵ� ����
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * bulletSpeed; // �Ѿ� �߻�
        }

        // �߻��� �Ѿ� �� ����
        bulletsFired++;
    }
}
