using UnityEngine;

public class ItemObject : Object //박성준 기존에 클래스 설계한 Object 클래스를 상속받고 추후 
{
    public Item itemData; // 아이템 객체

    // 아이템 데이터 전송 메서드
    public void ItemDataTransfer(GameObject obj)
    {
        ItemInteraction playerItemInteraction = obj.GetComponent<ItemInteraction>();

        if (playerItemInteraction != null)
        {
            playerItemInteraction.PickUpItem(itemData);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌 오브젝트 태그 확인
        switch (other.tag)
        {
            case "Player": // 플레이어인 경우
                ItemDataTransfer(other.gameObject); // 아이템 데이터 전송
                break;
        }
    }
}