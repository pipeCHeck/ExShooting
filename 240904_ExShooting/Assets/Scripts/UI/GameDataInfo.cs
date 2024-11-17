using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataInfo : MonoBehaviour
{
    public Text[] gameTexts; //무기 레벨, 데미지, 공속 순으로 되어 있음
    PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTexts[0].text = ((playerAttack.GetWeaponLevelArray(WeaponType.EnergyBullet) + 1).ToString()) + " / " +
            ((playerAttack.GetWeaponLevelArray(WeaponType.HomingOrb)+1).ToString()) + " / " +
            (playerAttack.GetWeaponLevelArray(WeaponType.MagicBeam)+1).ToString();
        gameTexts[1].text = playerAttack.GetPlayerDamage().ToString();
        gameTexts[2].text = playerAttack.GetAttackDelay().ToString();
    }
}
