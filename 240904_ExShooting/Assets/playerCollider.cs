using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            switch (collision.tag) {
                case "EnemyBullet":

                    break;
                }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
