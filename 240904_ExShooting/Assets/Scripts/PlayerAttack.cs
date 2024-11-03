using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { MagicBeam, EnergyBullet, HomingOrb }

public class PlayerAttack : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.EnergyBullet;

    private int laserLevel = 1;
    private int bulletLevel = 1;
    private int homingMissileLevel = 1;

    void Update()
    {
        // ���� ��ȯ (�Է�: LeftShift)
        SwitchWeapon();

        // ���� �߻� (�Է�: Z)
        ShootWeapon();

        // ���� ������ (��: L Ű�� ������)
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelUpCurrentWeapon();
        }
    }

    // ���� ��ȯ �޼��� (�Է�: LeftShift)
    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (currentWeapon)
            {
                case WeaponType.MagicBeam:
                    currentWeapon = WeaponType.EnergyBullet;
                    break;
                case WeaponType.EnergyBullet:
                    currentWeapon = WeaponType.HomingOrb;
                    break;
                case WeaponType.HomingOrb:
                    currentWeapon = WeaponType.MagicBeam;
                    break;
            }
        }
    }

    // ���� �߻� �޼��� (�Է�: Z)
    void ShootWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (currentWeapon)
            {
                case WeaponType.MagicBeam:
                    FireLaser();
                    break;
                case WeaponType.EnergyBullet:
                    FireBullet();
                    break;
                case WeaponType.HomingOrb:
                    FireHomingMissile();
                    break;
            }
        }
    }

    void LevelUpCurrentWeapon()
    {
        switch (currentWeapon)
        {
            case WeaponType.MagicBeam:
                laserLevel++;
                Debug.Log("���� ���� ���� ��! ���� ����: " + laserLevel);
                break;
            case WeaponType.EnergyBullet:
                bulletLevel++;
                Debug.Log("������ ź ���� ��! ���� ����: " + bulletLevel);
                break;
            case WeaponType.HomingOrb:
                homingMissileLevel++;
                Debug.Log("���� ���� ���� ��! ���� ����: " + homingMissileLevel);
                break;
        }
    }

    void FireLaser()
    {
        Debug.Log("���� ���� �߻� / ����: " + laserLevel);
        // ������ ���� ������ �߻� ���
    }

    void FireBullet()
    {
        Debug.Log("������ ź �߻� / ����: " + bulletLevel);
        // ������ ���� źȯ �߻� ���
    }

    void FireHomingMissile()
    {
        Debug.Log("���� ���� �߻� / ����: " + homingMissileLevel);
        // ������ ���� ���� �̻��� �߻� ���
    }
}
