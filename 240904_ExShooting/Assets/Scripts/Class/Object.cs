using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Object : MonoBehaviour
{
    
    float moveSpeed; //아이템 클래스 추가될 시 위치가 변동 될 수 있음

    protected void ObjectMove(Vector3 moveVec, float moveSpeed)
    {
        transform.Translate(moveVec * moveSpeed * Time.deltaTime * 0.5f);
    }

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
