using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum WeaponType { MagicBeam, EnergyBullet, HomingOrb }

//������
public class PlayerAttack : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.EnergyBullet;
    public WeaponType weaponTypeData;
    [SerializeField] Vector3 shootVec;
    [SerializeField] GameObject currentWeaponObject;
    public GameObject laser; //���� �������� �δ� ������ ���� �̻���, �Ѿ��� ���¿ʹ� �ٸ� ������ ���ݹ���̱� ����. �ڼ��� �̾߱�� ���� ��鿡 ������ ����
    public List<PlayerAttackData> attackData = new List<PlayerAttackData>();
    AttackManage attack;

    float attackDelay; //���ݼӵ�
    float bulletSpeed; //�Ѿ��� �ӵ�
    float attackDamage; //�� ���� Ÿ���� ���ݷ��� �����ϴ� ���� 
    float energyBulletAttackrange; //�Ϲ��Ѿ��� ���ÿ� �߻��� �� �����ϴ� ������
    float laserScaleValue = 1f; //������ ���� �������� ���� ũ�� ����� ���� ������


    private int laserLevel = 1;
    private int bulletLevel = 1;
    private int homingMissileLevel = 1;
    [SerializeField] int shootCount;


    public bool isTest; //�ڼ��� �׽�Ʈ�� �������� �߰�

    public bool isReadyAttack;
    public bool isReadySkill;
    public bool isReadyExplosion;
    bool isLaserKeyDown;

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
                LevelUpWeapon(currentWeapon);
            }
            WeaponStateLoad(currentWeapon);
        }
    }

    void Init() //�ڼ���
    {
        attack = gameObject.AddComponent<AttackManage>();
        laser = Instantiate(laser);
        laser.GetComponentInChildren<Laser>().SetWeaponData(0, "Player", (int)attackDamage);
        laser.SetActive(false);
        isReadyAttack = true;
        energyBulletAttackrange = 15f;
        WeaponStateLoad(currentWeapon);
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
            WeaponStateLoad(currentWeapon);
            Debug.Log(currentWeapon);
            Debug.Log(attackDelay);
        }
    }

    // ���� �߻� �޼��� (�Է�: Z)
    void ShootWeapon()
    {
        if (Input.GetKey(KeyCode.Z) && isReadyAttack == true)
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
            if(currentWeapon != WeaponType.MagicBeam)
            {
                StartCoroutine(ActionDelay("attack", GetAttackDelay()));
                isReadyAttack = false;
            }
        }
        else if(isLaserKeyDown == true) //�������� �ٸ� ����(��/������)�� �����̱� ������ ���� ó���Ͽ���
        {
            isLaserKeyDown = false;
            isReadyAttack = true;

            laser.SetActive(false);
        }

    }

    //�ڼ��� ���⸦ ������ ������ �ش� ���⸦ �����ϱ� ���� ���� ����Ʈ�� ã�´�
    void WeaponStateLoad(WeaponType weaponName) 
    {
        foreach(PlayerAttackData instanceData in attackData)
        {
            if(instanceData.weaponName == weaponName.ToString())
            {
                WeaponDataInit(instanceData, GetWeaponLevelArray(weaponName));
                return;
            }
        }
    }

    //�ڼ��� ���� �ش� ���� Ÿ���� ������ ����Ͽ� �����͸� �ʱ�ȭ�Ѵ�. ���⸦ �����ϰų�, ���� ���� ���Ⱑ �������� �ϰ� �Ǹ� �ش� �Լ��� ����ϰ� �ȴ�
    void WeaponDataInit(PlayerAttackData attackData, int levelValue)
    {
        currentWeaponObject = attackData.weapon;
        attackDelay = attackData.attackDelay[levelValue];
        bulletSpeed = attackData.shootSpeed[levelValue];
        attackDamage = attackData.attackDamage[levelValue];
        GetComponent<Character>().SetDamage((int)attackDamage);
        shootCount = attackData.shootVecCount;
    }

    //�ڼ��� �迭�� �������� �������� ������ ��ȯ �� -1�� ����
    public int GetWeaponLevelArray(WeaponType weaponState)
    {
        switch (weaponState)
        {
            case WeaponType.MagicBeam:
                return laserLevel - 1;
            case WeaponType.EnergyBullet:
                return bulletLevel - 1;
            case WeaponType.HomingOrb:
                return homingMissileLevel - 1;
        }

        Debug.Log("���� �߻�. Ȯ�� ���");
        return -404;
    }

    // �ڼ��� ���� ���� ������ ����� �׽�Ʈ�� ���� ���� ���� �������̳� ��� ���� ������, Ȥ�� �����ۿ� ���� �������̱� ������ �Լ��̸��� ������
    public void LevelUpWeapon(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.MagicBeam:
                if(laserLevel < 5)
                {
                    laserLevel++;
                    Debug.Log("���� ���� ���� ��! ���� ����: " + laserLevel);
                }
                break;
            case WeaponType.EnergyBullet:
                if (bulletLevel < 5)
                {
                    bulletLevel++;
                    Debug.Log("������ ź ���� ��! ���� ����: " + bulletLevel);
                }
                break;
            case WeaponType.HomingOrb:
                if(homingMissileLevel < 5)
                {
                    homingMissileLevel++;
                    Debug.Log("���� ���� ���� ��! ���� ����: " + homingMissileLevel);
                }
                break;
        }
        if(type == currentWeapon) //���� ������ ������ ���� �� �߻��� ����ó��. ��� ���� ���Ⱑ �������� ����� ���� Ÿ���̸� �ǽð����� ��ȭ�ǰ� ��
        {
            WeaponStateLoad(type);
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

    Vector3 GetShootVector()
    {
        return shootVec + transform.position; // �÷��̾��� ��ġ�� �߻��Ϸ��� ��ġ�� �ҷ���
    }


    void FireLaser()
    {

        // ������ ���� ������ �߻� ���
        laser.transform.localScale = new Vector3(laserScaleValue + laserLevel / 2, 1 + laserLevel / 4, 0); //������ ���� ������ ũ�� ����

        if (isLaserKeyDown == false)
        {
            laser.SetActive(true);
            WeaponStateLoad(currentWeapon);
            laser.GetComponentInChildren<Laser>().SetWeaponData(bulletSpeed, "PlayerBullet", (int)attackDamage);
            Debug.Log(laser.GetComponentInChildren<Laser>().GetDamage());
            isLaserKeyDown = true;
            laser.GetComponentInChildren<Laser>().attackDelay = attackDelay;
        }
        laser.transform.position = GetShootVector();
        Debug.Log("���� ���� �߻� / ����: " + laserLevel);
    }

    void FireBullet()
    {
        
        Vector3 instanceShootVec = GetShootVector();
        float angleBase = bulletLevel > 1 ? energyBulletAttackrange * 2f / (bulletLevel - 1) : 0f; // �Ѿ��� ���� ���� ��갪. ������ ���� �Ѿ��� ������ ���� �䱸 ������ ����. (bulletLevel - 1)�κп� NaN������ �߻��Ͽ���, �̸� �����ϱ� ���� ������ ���� 0�� ���� �κ��� ���� ó���Ͽ� ó���ϴ� ���
        float angle = 0; //������ �����ϴ� ����������
        for (int i = 0; i < bulletLevel; i++)
        {
            // ���� ����Ǵ� ������ �յ��ϰ� �й�
            if (bulletLevel == 1)
            {
                //������ 1�̶�� �������� ��� �̵��ϱ� ���� ����ó��
                angle = angleBase * i - 90f;
            }
            else
            {
                angle = angleBase * i - 90f - energyBulletAttackrange;
            }

            // �� ������Ʈ(ĳ���� Ŭ������)���� ���ϴ� ���� �ӵ����� ������ ��, �Ѿ��� �߻��� �� �ش� ���� �����Ͽ� �Ѿ��� �ӵ��� ����.
            // instanceShootVec.y + ((bulletLevel - 1) / 2) => �߻� ��ġ ����
            attack.ShootStraightBullet(currentWeaponObject, this.gameObject, new Vector3(instanceShootVec.x + 0.1f, instanceShootVec.y, 0), angle, bulletSpeed);
        }
        Debug.Log("������ ź �߻� / ����: " + bulletLevel);
        // ������ ���� źȯ �߻� ���
    }

    void FireHomingMissile()
    {
        Vector3 instanceShootVec = GetShootVector();
        attack.ShootMisiile(currentWeaponObject, this.gameObject, instanceShootVec, bulletSpeed);

        Debug.Log("���� ���� �߻� / ����: " + homingMissileLevel);
        // ������ ���� ���� �̻��� �߻� ���
    }

    //���� ����� ������ �ҷ��� ���� �׻� true�� �����̱� ����(���� ������, ��ų ������ �� ���� ������ ����ϹǷ�) �پ缺�� �ΰ� ������, ���� �ڵ� ȿ���� ���ؼ� ������ ����
    protected IEnumerator ActionDelay(string actionType, float delayTypeValue)
    {
        SetToggleState(actionType, false);
        yield return new WaitForSeconds(delayTypeValue);
        SetToggleState(actionType, true);
    }

    //attack, skill, removeBullet
    public bool GetToggleState(string stateName)
    {
        switch (stateName)
        {
            case "attack":
                return isReadyAttack;
            case "skill":
                return isReadyAttack;
            case "removeBullet":
                return isReadyExplosion;
            default:
                Debug.Log("���ڿ��� �߸� �Է��߽��ϴ�.");
                return false;
        }
    }

    //�ڼ��� �� �÷��̾��� �ɷ� Ȱ��ȭ ���θ� �����ϱ� ���� �Լ�
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

    public void SetAttackDelay(float delayValue)
    {
        attackDelay = delayValue;
    }

    public float GetAttackDelay()
    {
        return attackDelay;
    }

    public void SetShootCount(int shootCount)
    {
        this.shootCount = shootCount;
    }

    public int GetShootCount()
    {
        return shootCount;
    }

    public float GetPlayerDamage()
    {
        return attackDamage;
    }

}
