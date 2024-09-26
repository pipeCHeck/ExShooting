using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Inventory playerInventory; // �÷��̾� �κ��丮

    void Update()
    {
        // �κ��丮 ���� ���
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerInventory.ShowInventory();
        }
    }

    // �������� �ݴ� �޼���
    public void PickUpItem(Item item)
    {
        playerInventory.AddItem(item);
        //Debug.Log(item.itemName + " - �κ��丮 �߰�");

    }
}