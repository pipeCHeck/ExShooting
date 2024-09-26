using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SparklingGem : ItemObject
{

    // ������ �浹 ó��
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("������Ʈ�� �浹�߽��ϴ�.");

        // �浹�� ��ü�� �÷��̾����� Ȯ��
        if (other.CompareTag("Player"))
        {
            // ������ ȿ�� ����
            ItemEffect();
            // ������ ������ ����
            ItemDataTransfer(other.gameObject);
        }
    }

    // ���� ������ ȿ��
    void ItemEffect()
    {
        Debug.Log("������ ���� ȿ���� ����Ǿ����ϴ�.");
    }
}
