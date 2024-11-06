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

    public bool isTest; //박성준 테스트의 목적으로 추가

    public bool isReadyAttack;
    public bool isReadySkill;
    public bool isReadyExplosion;

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
        }
    }

    void Init() //박성준
    {
        attack = gameObject.AddComponent<AttackManage>();
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
        }
    }

    // 무기 발사 메서드 (입력: Z)
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

    void FireLaser()
    {
        Debug.Log("마력 광선 발사 / 레벨: " + laserLevel);
        // 레벨에 따른 레이저 발사 방식
    }

    void FireBullet()
    {
        
        Debug.Log("에너지 탄 발사 / 레벨: " + bulletLevel);
        // 레벨에 따른 탄환 발사 방식
    }

    void FireHomingMissile()
    {
        Debug.Log("추적 오브 발사 / 레벨: " + homingMissileLevel);
        // 레벨에 따른 유도 미사일 발사 방식
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
                Debug.Log("문자열을 잘못 입력했습니다.");
                break;
        }
    }
}
