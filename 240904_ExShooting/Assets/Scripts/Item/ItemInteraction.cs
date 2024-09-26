using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Inventory playerInventory; // 플레이어 인벤토리

    void Update()
    {
        // 인벤토리 내용 출력
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerInventory.ShowInventory();
        }
    }

    // 아이템을 줍는 메서드
    public void PickUpItem(Item item)
    {
        playerInventory.AddItem(item);
        //Debug.Log(item.itemName + " - 인벤토리 추가");

    }
}