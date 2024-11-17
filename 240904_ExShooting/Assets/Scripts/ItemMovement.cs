using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ItemMovement : ItemObject
{
    public string typeItem; // 아이템의 종류 기입

    // Start is called before the first frame update
    void Start()
    {
        SetMoveSpeed(10f);
        Destroy(gameObject, 10f); // 박성준 플레이어가 레벨업하려는 아이템을 선택할 시간을 여유롭게 주려는 의도로 5초에서 변경함
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.left, moveSpeed); //박성준 이러한 방식으로 처리할 수 있음. 오든 오브젝트가 그럴 순 없겠지만 확실한 사실은 아이템도 움직이기 떄문
    }

    public string GetTypeItem()
    {
        return typeItem;
    }
}
