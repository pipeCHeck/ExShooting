using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemE : ItemObject
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // �浹 ������Ʈ �±� Ȯ��
        switch (other.tag)
        {
            case "Player": // �÷��̾��� ���
                ItemEffect(); // ������ ȿ��
                ItemDataTransfer(other.gameObject); // ������ ������ ����
                break;
        }
    }

    // ������ ȿ�� �޼���
    void ItemEffect()
    {
        Debug.Log("������ ���� ȿ���� ����Ǿ����ϴ�.");
    }
}