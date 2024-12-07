using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum WeaponType { MagicBeam, EnergyBullet, HomingOrb }

//김진우
public class PlayerAttack : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.EnergyBullet;
    public WeaponType weaponTypeData;
    [SerializeField] Vector3 shootVec;
    [SerializeField] GameObject currentWeaponObject;
    public GameObject laser; //따로 레이저만 두는 이유는 현재 미사일, 총알의 형태와는 다른 구조의 공격방식이기 때문. 자세한 이야기는 추후 대면에 설명할 예정
    public List<PlayerAttackData> attackData = new List<PlayerAttackData>();
    AttackManage attack;

    float attackDelay; //공격속도
    float bulletSpeed; //총알의 속도
    float attackDamage; //각 무기 타입의 공격력을 저장하는 변수 
    float energyBulletAttackrange; //일반총알을 동시에 발사할 때 설정하는 각도값
    float laserScaleValue = 1f; //레이저 무기 레벨업에 따른 크기 계산을 위한 변수값


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
                LevelUpWeapon(currentWeapon);
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
        energyBulletAttackrange = 15f;
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

        Debug.Log("예외 발생. 확인 요망");
        return -404;
    }

    // 박성준 현재 무기 레벨업 방식은 테스트에 의해 현재 무기 레벨업이나 모든 무기 레벨업, 혹은 아이템에 의한 레벨업이기 때문에 함수이름을 변경함
    public void LevelUpWeapon(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.MagicBeam:
                if(laserLevel < 5)
                {
                    laserLevel++;
                    Debug.Log("마력 광선 레벨 업! 현재 레벨: " + laserLevel);
                }
                break;
            case WeaponType.EnergyBullet:
                if (bulletLevel < 5)
                {
                    bulletLevel++;
                    Debug.Log("에너지 탄 레벨 업! 현재 레벨: " + bulletLevel);
                }
                break;
            case WeaponType.HomingOrb:
                if(homingMissileLevel < 5)
                {
                    homingMissileLevel++;
                    Debug.Log("추적 오브 레벨 업! 현재 레벨: " + homingMissileLevel);
                }
                break;
        }
        if(type == currentWeapon) //무기 레벨업 아이템 습득 시 발생한 예외처리. 사용 중인 무기가 레벨업된 무기와 같은 타입이면 실시간으로 강화되게 함
        {
            WeaponStateLoad(type);
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

        // 레벨에 따른 레이저 발사 방식
        laser.transform.localScale = new Vector3(laserScaleValue + laserLevel / 2, 1 + laserLevel / 4, 0); //레벨에 따라 레이저 크기 변경

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
        Debug.Log("마력 광선 발사 / 레벨: " + laserLevel);
    }

    void FireBullet()
    {
        
        Vector3 instanceShootVec = GetShootVector();
        float angleBase = bulletLevel > 1 ? energyBulletAttackrange * 2f / (bulletLevel - 1) : 0f; // 총알의 각도 사전 계산값. 레벨에 따라 총알의 개수에 따른 요구 각도를 정함. (bulletLevel - 1)부분에 NaN현상이 발생하였고, 이를 대응하기 위해 나누는 값이 0에 대한 부분을 예외 처리하여 처리하는 모습
        float angle = 0; //각도를 결정하는 최종변수값
        for (int i = 0; i < bulletLevel; i++)
        {
            // 실제 적용되는 각도를 균등하게 분배
            if (bulletLevel == 1)
            {
                //레벨이 1이라면 전방으로 곧게 이동하기 위한 예외처리
                angle = angleBase * i - 90f;
            }
            else
            {
                angle = angleBase * i - 90f - energyBulletAttackrange;
            }

            // 각 오브젝트(캐릭터 클래스들)들이 원하는 총의 속도값을 소지한 후, 총알을 발사할 때 해당 값을 전송하여 총알의 속도를 정함.
            // instanceShootVec.y + ((bulletLevel - 1) / 2) => 발사 위치 수정
            attack.ShootStraightBullet(currentWeaponObject, this.gameObject, new Vector3(instanceShootVec.x + 0.1f, instanceShootVec.y, 0), angle, bulletSpeed);
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

    public float GetPlayerDamage()
    {
        return attackDamage;
    }

}
