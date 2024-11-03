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
            playerItemInteraction.PickUpItem(itemData);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �浹 ������Ʈ �±� Ȯ��
        switch (other.tag)
        {
            case "Player": // �÷��̾��� ���
                ItemDataTransfer(other.gameObject); // ������ ������ ����
                break;
        }
    }
}