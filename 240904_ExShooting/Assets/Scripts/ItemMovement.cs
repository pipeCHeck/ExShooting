using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ItemMovement : ItemObject
{
    public string typeItem; // 아이템의 종류 기입
    public float moveSpeed; // 코인의 이동 속도

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
    }

    public string GetTypeItem()
    {
        return typeItem;
    }
}
