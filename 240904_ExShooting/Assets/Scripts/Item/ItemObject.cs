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

    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌 오브젝트 태그 확인
        switch (other.tag)
        {
            case "Player": // 플레이어인 경우
                ItemDataTransfer(other.gameObject); // 아이템 데이터 전송
                break;
        }
    }
}