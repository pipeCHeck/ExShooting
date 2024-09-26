using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Heal : CardObject
{
    void OnMouseDown()
    {
        Debug.Log("카드 클릭");
        // 카드 효과 적용
        CardEffect();
        // 카드 데이터 전송
        CardDataTransfer();
        // 카드 선택했다고 관리자에게 알림 
        manager.OnCardClicked();
    }

    // 각자 아이템 효과
    void CardEffect()
    {
        Debug.Log("회복 카드 적용");
    }
}
