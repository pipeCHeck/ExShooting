using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item itemData; // 아이템 객체

    // 아이템 데이터 전송 메서드
    public void ItemDataTransfer(GameObject obj)
    {
        ItemInteraction playerItemInteraction = obj.GetComponent<ItemInteraction>();

        if (playerItemInteraction != null)
        {
            playerItemInteraction.PickUpItem(itemData);
            Destroy(gameObject);
        }

    }
}