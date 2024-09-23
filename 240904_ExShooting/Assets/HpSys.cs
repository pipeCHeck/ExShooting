using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSys : MonoBehaviour
{
    public int hpMax;   //�ִ� hp
    int hp;             //���� hp

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        DeadCheck();
    }

    void DeadCheck()
    {
        if (hp <= 0)
        {
            GameObject.FindGameObjectWithTag("DeadEffectsCtrl").GetComponent<EffectsCtrl>().CreateEffect(transform.position);
            gameObject.SetActive(false);
        }
    }

    public void SetHp(int num, bool isMinus)
    {
        if (isMinus) hp -= num;
        else hp = num;
    }
}
