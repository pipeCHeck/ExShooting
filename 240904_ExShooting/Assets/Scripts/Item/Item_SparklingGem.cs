using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SparklingGem : ItemObject
{

    // 아이템 충돌 처리
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("오브젝트와 충돌했습니다.");

        // 충돌한 객체가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            // 아이템 효과 적용
            ItemEffect();
            // 아이템 데이터 전송
            ItemDataTransfer(other.gameObject);
        }
    }

    // 각자 아이템 효과
    void ItemEffect()
    {
        Debug.Log("빛나는 보석 효과가 적용되었습니다.");
    }
}
