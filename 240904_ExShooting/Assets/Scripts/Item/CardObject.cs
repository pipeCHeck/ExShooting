using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    public Item cardData; // ������ ��ü
    public CardManager manager; // ī�� ������ ������Ʈ

    // ī�� ������ ���� �޼���
    public void CardDataTransfer()
    {
        CardInteraction cardInteraction = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardInteraction>();

        if (cardInteraction != null)
        {
            Debug.Log("������ ������ ����");

            // ī�� ������ ����
            cardInteraction.PickUpCard(cardData);
        }

    }

    // ī�� ������ ���� �޼���
    public void Initialize(CardManager manager)
    {
        this.manager = manager;
    }
}
