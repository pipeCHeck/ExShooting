using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    Player player;
    Attacker attacker;
    PlayerAttack playerAttack;

    Player player_;
    Attacker attacker_;

    public float shotCountBuffCooldown;
    public float moveSpeedBuffCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        attacker = GetComponent<Attacker>();
        playerAttack = GetComponent<PlayerAttack>();
        shotCountBuffCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShotCountBuff();
        MoveSpeedBuff();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Item":
                Debug.Log("������ ȹ��!");
                switch (collision.gameObject.GetComponent<ItemMovement>().GetTypeItem())
                {
                     // �ڼ��� �� ����Ÿ�Կ� ���� ������ �߰�
                    case "MagicBeamExp":
                        Debug.Log("���� ������ ��ȭ �� �߰�!");
                        playerAttack.LevelUpWeapon(WeaponType.MagicBeam);
                        break;
                    case "EnergyBulletExp":
                        Debug.Log("������ ź�� ��ȭ �� �߰�!");
                        playerAttack.LevelUpWeapon(WeaponType.EnergyBullet);
                        break;
                    case "HomingOrbExp":
                        Debug.Log("���� ������ ��ȭ �� �߰�!");
                        playerAttack.LevelUpWeapon(WeaponType.HomingOrb);
                        break;
                    case "AttackPowerUp":
                        Debug.Log("7�� �� ���ݷ� ����");
                        break;
                    case "Invincibility":
                        Debug.Log("7�� �� ���� ����");
                        break;
                    case "healthPack":
                        Debug.Log("ü�� �Ϻ� ȸ��");
                        break;
                    default:
                        Debug.Log("- ���� ó�� -");
                        break;
                }
                Destroy(collision.gameObject);
                break;
            case "ScoreItem":
                Destroy(collision.gameObject);
                break;
        }
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
