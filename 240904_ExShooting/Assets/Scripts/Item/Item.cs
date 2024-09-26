using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName; // �������� �̸�
    public string itemDescription; // ������ ����
    public Sprite itemIcon; // ������ ������
    public int quantity; // ������ ����

    //public void ItemEffect();

    // ������
    public Item(string name, string description, Sprite icon, int quantity)
    {
        this.itemName = name;
        this.itemDescription = description;
        this.itemIcon = icon;
        this.quantity = quantity;
    }
}
