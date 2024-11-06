using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { MagicBeam, EnergyBullet, HomingOrb }

public class PlayerAttack : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.EnergyBullet;
    public List<PlayerAttackData> attackData = new List<PlayerAttackData>();
    AttackManage attack;
    float attackDelay;
    private int laserLevel = 1;
    private int bulletLevel = 1;
    private int homingMissileLevel = 1;

    public bool isTest; //�ڼ��� �׽�Ʈ�� �������� �߰�

    public bool isReadyAttack;
    public bool isReadySkill;
    public bool isReadyExplosion;

    void Start()
    {
        Init();
    }

    void Update()
    {
        // ���� ��ȯ (�Է�: LeftShift)
        SwitchWeapon();

        // ���� �߻� (�Է�: Z)
        ShootWeapon();

        // ���� ������ (��: L Ű�� ������)
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isTest) //�ڼ��� ���ϵ���. ����� �׽�Ʈ ����ó���� ���� ��ȭ�� �����
            {
                TestLevelUpWeapon();
            }
            else
            {
                LevelUpCurrentWeapon();
            }
        }
    }

    void Init() //�ڼ���
    {
        attack = gameObject.AddComponent<AttackManage>();
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
        if (Input.GetKey(KeyCode.Z))
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

    //�ڼ��� �׽�Ʈ �������� �ѹ��� ��� ������� ��ȭ�ϴ� ȿ��
    void TestLevelUpWeapon()
    {
        laserLevel++;
        bulletLevel++;
        homingMissileLevel++;
        Debug.Log("��� ���� ��ȭ! ���� �׽�Ʈ���.");
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

    IEnumerator ActionDelay(string actionType)
    {
        SetToggleState(actionType, false);
        yield return new WaitForSeconds(attackDelay);
        SetToggleState(actionType, true);

    }

    public void SetToggleState(string stateName, bool state)
    {
        switch (stateName)
        {
            case "attack":
                isReadyAttack = state;
                break;
            case "skill":
                isReadyAttack = state;
                break;
            case "removeBullet":
                isReadyExplosion = state;
                break;
            default:
                Debug.Log("���ڿ��� �߸� �Է��߽��ϴ�.");
                break;
        }
    }
}
