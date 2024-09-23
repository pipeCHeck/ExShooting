using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl_00 : MonoBehaviour
{
    public GameObject bullet;   //�갡 ����� bullet
    public int attackBulletNum; //�ѹ� ���ݿ� � �� ����

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
