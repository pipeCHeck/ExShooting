using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public List<Item> itemList = new List<Item>(); // �������� ������ ����Ʈ

    // ������ �߰� �޼���
    public void AddItem(Item newItem)
    {
        // �̹� �ִ� �������̶�� ������ ����
        foreach (Item item in itemList)
        {
            if (item.itemName == newItem.itemName)
            {
                item.quantity += newItem.quantity;
                Debug.Log(newItem.itemName + " ���� ����. ���� ����: " + item.quantity);
                return;
            }
        }

        // ���� �������̶�� ���� �߰�
        itemList.Add(newItem);
        Debug.Log(newItem.itemName + " - �κ��丮�� �߰���");
    }

    // ������ ���� �޼���
    public void RemoveItem(string itemName)
    {
        foreach (Item item in itemList)
        {
            if (item.itemName == itemName)
            {
                itemList.Remove(item);
                Debug.Log(itemName + " - �κ��丮�� ���ŵ�");
                return;
            }
        }
        Debug.Log(itemName + " - �κ��丮�� �������� ����");
    }

    // �κ��丮 ���� ��� �޼���
    public void ShowInventory()
    {
        Debug.Log("�κ��丮 ���:");
        foreach (Item item in itemList)
        {
            Debug.Log(item.itemName + " (����: " + item.quantity + ")");
        }
    }
}