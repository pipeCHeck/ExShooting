using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemE : ItemObject
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌 오브젝트 태그 확인
        switch (other.tag)
        {
            case "Player": // 플레이어인 경우
                ItemEffect(); // 아이템 효과
                ItemDataTransfer(other.gameObject); // 아이템 데이터 전송
                break;
        }
    }

    // 아이템 효과 메서드
    void ItemEffect()
    {
        Debug.Log("빛나는 보석 효과가 적용되었습니다.");
    }
}