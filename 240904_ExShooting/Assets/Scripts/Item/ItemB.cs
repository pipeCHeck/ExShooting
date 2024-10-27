using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemB : ItemObject
{
    PlayerBuff buff;

    void OnTriggerEnter2D(Collider2D other)
    {
        // �浹 ������Ʈ �±� Ȯ��
        switch (other.tag)
        {
            case "Player": // �÷��̾��� ���
                ItemEffect(other.GetComponent<PlayerBuff>()); // ������ ȿ��
                ItemDataTransfer(other.gameObject); // ������ ������ ����
                break;
        }
    }

    // ������ ȿ�� �޼���
    void ItemEffect(PlayerBuff playerBuff)
    {
        //playerBuff.SetShotCountBuffCooldown(10);
        playerBuff.SetCooldown(1, 10f);
        Debug.Log("�Ϲ� ���� 4��");
    }
}