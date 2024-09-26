using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName; // 아이템의 이름
    public string itemDescription; // 아이템 설명
    public Sprite itemIcon; // 아이템 아이콘
    public int quantity; // 아이템 수량

    //public void ItemEffect();

    // 생성자
    public Item(string name, string description, Sprite icon, int quantity)
    {
        this.itemName = name;
        this.itemDescription = description;
        this.itemIcon = icon;
        this.quantity = quantity;
    }
}
