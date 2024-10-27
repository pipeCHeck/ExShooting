using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    Player player;
    Attacker attacker;

    Player player_;
    Attacker attacker_;

    public float shotCountBuffCooldown;
    public float moveSpeedBuffCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        attacker = GetComponent<Attacker>();

        shotCountBuffCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShotCountBuff();
        MoveSpeedBuff();
    }

    private void ShotCountBuff()
    {
        if (shotCountBuffCooldown > 0)
        {
            shotCountBuffCooldown -= Time.deltaTime;
            attacker.SetShootCount(4);
        }
        else
        {
            shotCountBuffCooldown = 0;
            attacker.SetShootCount(2);
        }
    }

    private void MoveSpeedBuff()
    {
        if (moveSpeedBuffCooldown > 0)
        {
            moveSpeedBuffCooldown -= Time.deltaTime;
            //attacker.SetShootCount(4);
            player.SetMoveSpeed(30f);
        }
        else
        {
            moveSpeedBuffCooldown = 0;
            //attacker.SetShootCount(2);
            player.SetMoveSpeed(20f);
        }
    }

    public void SetCooldown(int type, float cooldown)
    {
        switch (type)
        {
            case 0:
                if (shotCountBuffCooldown < cooldown) shotCountBuffCooldown = cooldown;
                break;
            case 1:
                if (moveSpeedBuffCooldown < cooldown) moveSpeedBuffCooldown = cooldown;
                break;
            case 2:
                if (shotCountBuffCooldown < cooldown) shotCountBuffCooldown = cooldown;
                break;
            case 3:
                if (shotCountBuffCooldown < cooldown) shotCountBuffCooldown = cooldown;
                break;
        }
    }
}
