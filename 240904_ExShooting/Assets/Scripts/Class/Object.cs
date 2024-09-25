using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Object : MonoBehaviour
{
    
    float moveSpeed; //������ Ŭ���� �߰��� �� ��ġ�� ���� �� �� ����

    //��� �����Ʈ�� �⺻���� ������. �� �������� ���� �ӵ��� �̵��Ѵ�.
    protected void ObjectMove(Vector3 moveVec, float moveSpeed)
    {
        transform.Translate(moveVec * moveSpeed * Time.deltaTime * 0.5f);
    }


    //getset
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void SetTag(string value)
    {
        transform.tag = value;
    }

    public string GetTag()
    {
        return transform.tag;
    }
}
