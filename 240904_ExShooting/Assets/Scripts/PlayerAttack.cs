using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { MagicBeam, EnergyBullet, HomingOrb }

//김진우
public class PlayerAttack : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.EnergyBullet;
    [SerializeField] Vector3 shootVec;
    [SerializeField] GameObject currentWeaponObject;
    public GameObject laser; //따로 레이저만 두는 이유는 현재 미사일, 총알의 형태와는 다른 구조의 공격방식이기 때문. 자세한 이야기는 추후 대면에 설명할 예정
    public List<PlayerAttackData> attackData = new List<PlayerAttackData>();
    AttackManage attack;

    float attackDelay; //공격속도
    float bulletSpeed; //총알의 속도
    float attackDamage; //각 무기 타입의 공격력을 저장하는 변수 

    private int laserLevel = 1;
    private int bulletLevel = 1;
    private int homingMissileLevel = 1;
    [SerializeField] int shootCount;


    public bool isTest; //박성준 테스트의 목적으로 추가

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
        // 무기 전환 (입력: LeftShift)
        SwitchWeapon();

        // 무기 발사 (입력: Z)
        ShootWeapon();

        // 무기 레벨업 (예: L 키로 레벨업)
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isTest) //박성준 이하동일. 현재는 테스트 예외처리를 통해 강화가 적용됨
            {
                TestLevelUpWeapon();
            }
            else
            {
                LevelUpCurrentWeapon();
            }
            WeaponStateLoad(currentWeapon);
        }
    }

    void Init() //박성준
    {
        attack = gameObject.AddComponent<AttackManage>();
        laser = Instantiate(laser);
        laser.GetComponentInChildren<Laser>().SetWeaponData(0, "Player", (int)attackDamage);
        laser.SetActive(false);
        isReadyAttack = true;
        WeaponStateLoad(currentWeapon);
    }

    // 무기 전환 메서드 (입력: LeftShift)
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

    // 무기 발사 메서드 (입력: Z)
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
        else if(isLaserKeyDown == true) //레이저만 다른 형태(온/오프형)의 공격이기 때문에 예외 처리하였음
        {
            isLaserKeyDown = false;
            isReadyAttack = true;

            laser.SetActive(false);
        }

    }

    //박성준 무기를 변경할 때마다 해당 무기를 변경하기 위해 무기 리스트에 찾는다
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

    //박성준 이후 해당 무기 타입의 레벨에 기반하여 데이터를 초기화한다. 무기를 변경하거나, 착용 중인 무기가 레벨업을 하게 되면 해당 함수를 사용하게 된다
    void WeaponDataInit(PlayerAttackData attackData, int levelValue)
    {
        currentWeaponObject = attackData.weapon;
        attackDelay = attackData.attackDelay[levelValue];
        bulletSpeed = attackData.shootSpeed[levelValue];
        attackDamage = attackData.attackDamage[levelValue];
        GetComponent<Character>().SetDamage((int)attackDamage);
        shootCount = attackData.shootVecCount;
    }

    //박성준 배열을 기준으로 가져오기 때문에 반환 시 -1을 진행
    int GetWeaponLevelArray(WeaponType weaponState)
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

        Debug.Log("예외 발생. 확인 요망");
        return -404;
    }

    void LevelUpCurrentWeapon()
    {
        switch (currentWeapon)
        {
            case WeaponType.MagicBeam:
                laserLevel++;
                Debug.Log("마력 광선 레벨 업! 현재 레벨: " + laserLevel);
                break;
            case WeaponType.EnergyBullet:
                bulletLevel++;
                Debug.Log("에너지 탄 레벨 업! 현재 레벨: " + bulletLevel);
                break;
            case WeaponType.HomingOrb:
                homingMissileLevel++;
                Debug.Log("추적 오브 레벨 업! 현재 레벨: " + homingMissileLevel);
                break;
        }
    }

    //박성준 테스트 목적으로 한번에 모든 무기들을 강화하는 효과
    void TestLevelUpWeapon()
    {
        laserLevel++;
        bulletLevel++;
        homingMissileLevel++;
        Debug.Log("모든 무기 강화! 현재 테스트모드.");
    }

    Vector3 GetShootVector()
    {
        return shootVec + transform.position; // 플레이어의 위치와 발사하려는 위치를 불러옴
    }

    void FireLaser()
    {
        if(isLaserKeyDown == false)
        {
            laser.SetActive(true);
            laser.GetComponentInChildren<Laser>().SetWeaponData(bulletSpeed, "PlayerBullet", (int)attackDamage);
            Debug.Log(laser.GetComponentInChildren<Laser>().GetDamage());
            isLaserKeyDown = true;
            laser.GetComponentInChildren<Laser>().attackDelay = attackDelay;
        }
        laser.transform.position = GetShootVector();
        Debug.Log("마력 광선 발사 / 레벨: " + laserLevel);
        // 레벨에 따른 레이저 발사 방식
    }

    void FireBullet()
    {
        Vector3 instanceShootVec = GetShootVector();
        for (int i = 0; i < shootCount; i++)
        {
            //각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
            attack.ShootStraightBullet(currentWeaponObject, this.gameObject, new Vector3(instanceShootVec.x + 0.1f, instanceShootVec.y + (i - (shootCount - 1) / 2f) / 3f, 0), -90, bulletSpeed);
        }
        Debug.Log("에너지 탄 발사 / 레벨: " + bulletLevel);
        // 레벨에 따른 탄환 발사 방식
    }

    void FireHomingMissile()
    {
        Vector3 instanceShootVec = GetShootVector();
        attack.ShootMisiile(currentWeaponObject, this.gameObject, instanceShootVec, bulletSpeed);

        Debug.Log("추적 오브 발사 / 레벨: " + homingMissileLevel);
        // 레벨에 따른 유도 미사일 발사 방식
    }

    //현재 설계된 구조는 불러온 값은 항상 true인 구조이기 때문(어택 딜레이, 스킬 딜레이 등 여러 목적에 사용하므로) 다양성을 두고 있으나, 추후 코드 효율에 대해서 논의할 예정
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
                Debug.Log("문자열을 잘못 입력했습니다.");
                return false;
        }
    }

    //박성준 각 플레이어의 능력 활성화 여부를 관리하기 위한 함수
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
                Debug.Log("문자열을 잘못 입력했습니다.");
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
}
