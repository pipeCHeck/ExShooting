using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemB : ItemObject
{
    PlayerBuff buff;

    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌 오브젝트 태그 확인
        switch (other.tag)
        {
            case "Player": // 플레이어인 경우
                ItemEffect(other.GetComponent<PlayerBuff>()); // 아이템 효과
                ItemDataTransfer(other.gameObject); // 아이템 데이터 전송
                break;
        }
    }

    // 아이템 효과 메서드
    void ItemEffect(PlayerBuff playerBuff)
    {
        //playerBuff.SetShotCountBuffCooldown(10);
        playerBuff.SetCooldown(1, 10f);
        Debug.Log("일반 공격 4줄");
    }
}