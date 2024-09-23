using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintBulletNum : MonoBehaviour
{
    PlayerCtrl playerCtrl;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        PrintBulletNum_();
    }

    void PrintBulletNum_()
    {
        float size = playerCtrl.GetBulletNum() / playerCtrl.GetBulletMaxNum();
        transform.localScale = new Vector3(size, 1, 1);
    }
}
