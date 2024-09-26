using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    public Item cardData; // 아이템 객체
    public CardManager manager; // 카드 관리자 오브젝트

    // 카드 데이터 전송 메서드
    public void CardDataTransfer()
    {
        CardInteraction cardInteraction = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardInteraction>();

        if (cardInteraction != null)
        {
            Debug.Log("아이템 데이터 전송");

            // 카드 데이터 전송
            cardInteraction.PickUpCard(cardData);
        }

    }

    // 카드 관리자 연결 메서드
    public void Initialize(CardManager manager)
    {
        this.manager = manager;
    }
}
