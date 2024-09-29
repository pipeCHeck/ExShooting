using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerConcentrater : MonoBehaviour
{
    Player player;
    IEnumerator[] coroutines;
    //power : ���� ������ �Ŀ���. powerUp : ��â�� ���� �ö󰡴� �ʴ� �Ŀ���. maxPower : �Ŀ��� ���� �� �ִ� �ִ밪
    //���� �䱸 ��ȹ���� ���� powerUp �Ӽ��� �迭 ���·� ����� �� ����
    float power, powerUp, maxPower;
    float buffTime; //��ȹ�� �� 10�� �����Ǿ�����
    bool isConcentrating; //���� ��� ����
    bool isReadySkill; //���� ���� �������, ��ų �ߵ� �غ����� �� Ȯ���ϴ� �뵵 
    bool isPowerUp; // �Ŀ��� �ø� �� �ִ� �� Ȯ���ϴ� �뵵. �ַ� ��ų�� �� �� 5�� ���� ��Ÿ���� ���� ���� ���

    public void ConcentInit()
    {
        maxPower = 100;
        powerUp = 5; // �ӽð����� �̰� ���� ������ ����� ����
        isReadySkill = false; //��ų�� �غ� �ȵž� Ű�Է��̳� �Ŀ��� ���� �� ������ false 
        buffTime = 10f;
        //���� �迭�� ���̰� ����� ���� ����
        coroutines = new IEnumerator[2];
        coroutines[0] = PlalyerSkillBuff();
        isPowerUp = true;
    }

    public void ConcentrateControl(GameObject character)
    {
        if(player == null)
        {
            player = character.GetComponent<Player>();
        }

        //��â�� �ϱ� ���� ���� Ű. ���� ������ ��ȹ������ ��������̹Ƿ� �̷��� �ڵ�� ������ ��
        if (!isReadySkill && Input.GetKeyDown(KeyCode.LeftShift))
        {
            CheckConcentrating();
        }

        //���� ��ų ����
        if (isReadySkill && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("��ų �ߵ�");
            isReadySkill = false;
            SetPower(0); //��ų�� ������ �ʱ�ȭ
            StartCoroutine(ConcentraitCoolTime());
        }

    }

    //�ڷ�ƾ ���� �Լ��� ���� �ϳ��ۿ� ����, ��ȹ���� �߰��� �� ���� �ʾƼ� �پ缺�� �����ϰ� �ٷ� ������
    void CheckConcentrating()
    {
        //���ȭ �� ��
        if (isConcentrating)
        {
            //�ڷ�ƾ�� ����� ó������ �����Ϸ��� ��ž�� ���� ����� �ڷ�ƾ ����� �����ؾ���.
            isConcentrating = false;
            StopCoroutine(coroutines[1]);
            coroutines[1] = null;
            player.SetMoveSpeed(20f); //��â ȿ�� ����
        }
        else
        {
            //���������� �ٽ� �����ϴ� ����
            isConcentrating = true;
            coroutines[1] = ConcentraitPowerUp();
            StartCoroutine(coroutines[1]);
            player.SetMoveSpeed(7f); //��â ȿ�� ����
        }
    }


    //�Ŀ��� ��� ä�� �� 10�ʰ� �߻��ϴ� ȿ��
    public IEnumerator PlalyerSkillBuff()
    {
        //��ų�� �´� ȿ�� �ߵ� �ϴ� ��
        Debug.Log("��â ��ų �ߵ�! ������ ���� �����ؼ� �ƹ� �͵� ���Ѵ�.");
        yield return new WaitForSeconds(buffTime);
        // ���� ȿ���� �������Ƿ� ��ų ��� ���� �� ȿ�� ����
        isReadySkill = false;
    }

    public IEnumerator ConcentraitPowerUp()
    {
        //goto��..���� ���ƾ� �ϴ°� ������..���� �ذ�� ȿ���� ���ؼ���� �̿���� ��Ⱑ �ʿ�����
    ReConcentrait:
        yield return new WaitForSeconds(1f);

        if (power + powerUp > maxPower)
        {
            //100�� �����ϸ� ��Ǫ ui �� ��� ���鿡 ������ �� �� ����. ������ 100�����ϱ�
            SetPower(100);
            isReadySkill = true;
            //power���� 100�� ���������Ƿ� ����ȿ�� �� ��ų��� �ߵ�
            StartCoroutine(coroutines[0]);
            Debug.Log("10�ʰ� ���� �ߵ�! ��ų ��� ��");
        }
        else if (isConcentrating)
        {
            // ���� �Ŀ����� �ö󰡴� �Ŀ����� ���ؼ� �����ϴ� ���
            SetPower(GetPower() + powerUp);
            Debug.Log("Power : " + GetPower());
            //stopCoroutine�� ���� �ߴܵǱ⿡ ��� �Լ��� ����ص� ����
            goto ReConcentrait;
        }
    }

    IEnumerator ConcentraitCoolTime()
    {
        float concentraitCoolTime = 5f;
        isPowerUp = false;
        isConcentrating = false;
        yield return new WaitForSeconds(concentraitCoolTime);
        isPowerUp = true;
        CheckConcentrating(); //��ų�� ���� �� �� 5�� ���̿� ����Ʈ�� ���� �������� ���� ���� 
    }


    //getset
    public float GetPower()
    {
        return power;
    }

    public void SetPower(float value)
    {
        power = value;
    }
}
