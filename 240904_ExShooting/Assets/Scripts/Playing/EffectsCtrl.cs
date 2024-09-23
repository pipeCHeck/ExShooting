using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCtrl : MonoBehaviour
{
    public GameObject effect;   //»ý¼ºÇÒ ÀÌÆåÆ®
    public int effectsNum;      //ÀÌÆåÆ® »ý¼º °¹¼ö

    int useNum;

    // Start is called before the first frame update
    void Start()
    {
        useNum = 0;

        for (int i = 0; i < effectsNum; i++)
        {
            Instantiate(effect, transform.position, Quaternion.identity).transform.parent = transform;
            transform.GetChild(i).GetComponent<Effects>().SetNum(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEffect(Vector3 pos)
    {
        Effects ef;
        ef = transform.GetChild(useNum).GetComponent<Effects>();

        ef.SetPos(pos);
        ef.CreateEffect();

        if (useNum == effectsNum) useNum = 0;
        else useNum++;
    }
}
