using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item itemData; // ������ ��ü

    // ������ ������ ���� �޼���
    public void ItemDataTransfer(GameObject obj)
    {
        ItemInteraction playerItemInteraction = obj.GetComponent<ItemInteraction>();

        if (playerItemInteraction != null)
        {
            Debug.Log("������ �����Ͱ� ���۵Ǿ����ϴ�.");

            // ������ ������ ����
            playerItemInteraction.PickUpItem(itemData);
            // ������ ������Ʈ ����
            Destroy(gameObject);
        }

    }
}