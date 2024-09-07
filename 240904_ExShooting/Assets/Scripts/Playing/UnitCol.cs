using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCol : MonoBehaviour
{
    public HpSys unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(int damage)
    {
        unit.SetHp(damage, true);
    }
}
