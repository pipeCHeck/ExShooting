using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public int num; //이펙트 개체 번호

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetNum(int num)
    {
        this.num = num;
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void CreateEffect()
    {
        gameObject.SetActive (true);   
        StartCoroutine(CreateAndDead());
    }

    IEnumerator CreateAndDead()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
