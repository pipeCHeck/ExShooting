using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ItemMovement : ItemObject
{
    public string typeItem; // �������� ���� ����
    public float moveSpeed; // ������ �̵� �ӵ�

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
