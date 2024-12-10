using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : MonoBehaviour
{
    public GameObject[] pattern;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in pattern)
        {
            Instantiate(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
