using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public float moveSpeed;
    public float followSpeed;
    int attackDelay = 3, adNum;
    int reloadingTime = 1, rtNum ,bulletNum = 20, bNum;

    // Start is called before the first frame update
    void Start()
    {
        adNum = 0; 
        rtNum = 0;
        bNum = bulletNum;
    }

    // Update is called once per frame
    void Update()
    {
        //Move_();
        //Move_2();
        Move_3();
    }

    private void FixedUpdate()
    {
        Attack();
        Reloading();
    }

    void Reloading()
    {
        if (rtNum == 0)
        {
            if (bNum < bulletNum && !Input.GetMouseButton(0))
            {
                bNum++;
                rtNum = reloadingTime;
            }
        }
        else
        {
            rtNum--;
        }

              
    }

    void Attack()
    {
        if (adNum == 0)
        {
            if (Input.GetMouseButton(0) && bNum > 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                adNum = attackDelay;
                bNum--;
            }
        }
        else
        {
            adNum--;
        }
    }

    void Move_()
    {
        float h, v;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        target.transform.position += new Vector3(h, v, 0) * moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * followSpeed);
    }

    void Move_2()
    {
        Vector3 point;
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        target.transform.position = point;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * followSpeed);
    }

    void Move_3()
    {
        float h, v;
        Vector3 point, dir;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        target.transform.position += new Vector3(h, v, 0) * moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * followSpeed);
        
        dir = point - transform.position;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f, Vector3.forward);
    }

    public float GetBulletNum()
    {
        return bNum;
    }

    public float GetBulletMaxNum()
    {
        return bulletNum;
    }
}
