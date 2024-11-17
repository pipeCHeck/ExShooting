using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class ItemMovement : ItemObject
{
    public string typeItem; // �������� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        SetMoveSpeed(10f);
        Destroy(gameObject, 10f); // �ڼ��� �÷��̾ �������Ϸ��� �������� ������ �ð��� �����Ӱ� �ַ��� �ǵ��� 5�ʿ��� ������
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.left, moveSpeed); //�ڼ��� �̷��� ������� ó���� �� ����. ���� ������Ʈ�� �׷� �� �������� Ȯ���� ����� �����۵� �����̱� ����
    }

    public string GetTypeItem()
    {
        return typeItem;
    }
}
