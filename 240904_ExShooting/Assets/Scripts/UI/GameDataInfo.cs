using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataInfo : MonoBehaviour
{
    public Text[] gameTexts; //���� ����, ������, ���� ������ �Ǿ� ����
    PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        //�÷��̾��� ���ݽ�ũ��Ʈ�� �ҷ��´�
        playerAttack = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� ����ȭ�鿡 ���� �Ϲ��Ѿ�/�̻���/�������� ����, ������, ���ݼӵ��� ����Ѵ�
        gameTexts[0].text = ((playerAttack.GetWeaponLevelArray(WeaponType.EnergyBullet) + 1).ToString()) + " / " +
            ((playerAttack.GetWeaponLevelArray(WeaponType.HomingOrb)+1).ToString()) + " / " +
            (playerAttack.GetWeaponLevelArray(WeaponType.MagicBeam)+1).ToString();
        gameTexts[1].text = playerAttack.GetPlayerDamage().ToString();
        gameTexts[2].text = playerAttack.GetAttackDelay().ToString();
    }
}
