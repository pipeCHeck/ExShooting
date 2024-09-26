using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
    public Inventory playerInventory; // �÷��̾� �κ��丮 //public �� �ִ��� �ؾ���� Ȯ�� ���

    void Update()
    {
        // �κ��丮 ���� ���
        if (Input.GetKeyDown(KeyCode.U))
        {
            playerInventory.ShowInventory();
        }
    }

    // �������� �ݴ� �޼���
    public void PickUpCard(Item card)
    {
        playerInventory.AddItem(card);
        //Debug.Log(card.cardName + " - �κ��丮 �߰�");

    }
}