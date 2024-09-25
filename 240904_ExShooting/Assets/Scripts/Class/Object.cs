using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Object : MonoBehaviour
{
    
    float moveSpeed; //아이템 클래스 추가될 시 위치가 변동 될 수 있음

    //모든 모브젝트의 기본적인 움직임. 한 방향으로 일정 속도로 이동한다.
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
