using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Barrier : CardObject
{
    void OnMouseDown()
    {
        Debug.Log("ī�� Ŭ��");
        // ī�� ȿ�� ����
        CardEffect();
        // ī�� ������ ����
        CardDataTransfer();
        // ī�� �����ߴٰ� �����ڿ��� �˸� 
        manager.OnCardClicked();
    }

    // ���� ������ ȿ��
    void CardEffect()
    {
        Debug.Log("�� ī�� ����");
    }
}
