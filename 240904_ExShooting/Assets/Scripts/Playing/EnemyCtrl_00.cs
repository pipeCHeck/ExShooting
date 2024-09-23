using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl_00 : MonoBehaviour
{
    public GameObject bullet;   //얘가 사용할 bullet
    public int attackBulletNum; //한번 공격에 몇개 쏠 건지

    private void Start()
    {
        StartCoroutine(AttackAttackAttack());   
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Attack());
        }
        */
    }

    IEnumerator AttackAttackAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        for (int i = 0; i < attackBulletNum; i++)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
