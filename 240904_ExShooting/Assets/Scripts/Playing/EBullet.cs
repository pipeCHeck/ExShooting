using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public float speed = 10;
    public bool isPlayerTeam;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null)
        {
            if (isPlayerTeam)
            {
                switch (collision.tag)
                {
                    case "EnemyCol":
                        collision.GetComponent<UnitCol>().AddDamage(damage);
                        Destroy(gameObject);
                        break;
                }
            }
            else
            {
                switch (collision.tag)
                {
                    case "PlayerCol":
                        collision.GetComponent<UnitCol>().AddDamage(damage);
                        Destroy(gameObject);
                        break;
                }
            }
        }
    }

    void CreateBullet(float speed)
    {
        this.speed = speed;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
