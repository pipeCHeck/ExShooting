using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
    public Inventory playerInventory; // 플레이어 인벤토리 //public 왜 있는지 잊어버림 확인 요망

    void Update()
    {
        // 인벤토리 내용 출력
        if (Input.GetKeyDown(KeyCode.U))
        {
            playerInventory.ShowInventory();
        }
    }

    // 아이템을 줍는 메서드
    public void PickUpCard(Item card)
    {
        playerInventory.AddItem(card);
        //Debug.Log(card.cardName + " - 인벤토리 추가");

    }
}