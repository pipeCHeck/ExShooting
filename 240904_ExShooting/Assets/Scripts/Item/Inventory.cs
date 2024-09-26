using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public List<Item> itemList = new List<Item>(); // 아이템을 저장할 리스트

    // 아이템 추가 메서드
    public void AddItem(Item newItem)
    {
        // 이미 있는 아이템이라면 수량만 증가
        foreach (Item item in itemList)
        {
            if (item.itemName == newItem.itemName)
            {
                item.quantity += newItem.quantity;
                Debug.Log(newItem.itemName + " 수량 증가. 현재 수량: " + item.quantity);
                return;
            }
        }

        // 없는 아이템이라면 새로 추가
        itemList.Add(newItem);
        Debug.Log(newItem.itemName + " - 인벤토리에 추가됨");
    }

    // 아이템 제거 메서드
    public void RemoveItem(string itemName)
    {
        foreach (Item item in itemList)
        {
            if (item.itemName == itemName)
            {
                itemList.Remove(item);
                Debug.Log(itemName + " - 인벤토리에 제거됨");
                return;
            }
        }
        Debug.Log(itemName + " - 인벤토리에 존재하지 않음");
    }

    // 인벤토리 내용 출력 메서드
    public void ShowInventory()
    {
        Debug.Log("인벤토리 목록:");
        foreach (Item item in itemList)
        {
            Debug.Log(item.itemName + " (수량: " + item.quantity + ")");
        }
    }
}