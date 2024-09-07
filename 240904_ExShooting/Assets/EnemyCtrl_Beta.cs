using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl_Beta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Debug.Log(transform.rotation);
        }
    }
}
