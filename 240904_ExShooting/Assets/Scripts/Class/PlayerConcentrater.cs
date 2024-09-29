using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerConcentrater : MonoBehaviour
{
    Player player;
    IEnumerator[] coroutines;
    //power : 현재 누적된 파워값. powerUp : 영창에 의해 올라가는 초당 파워값. maxPower : 파워를 쌓을 수 있는 최대값
    //또한 요구 기획서에 의해 powerUp 속성은 배열 형태로 변경될 수 있음
    float power, powerUp, maxPower;
    float buffTime; //기획서 상 10초 고정되어있음
    bool isConcentrating; //집중 모드 유무
    bool isReadySkill; //현재 집중 모드인지, 스킬 발동 준비중인 지 확인하는 용도 
    bool isPowerUp; // 파워를 올릴 수 있는 지 확인하는 용도. 주로 스킬을 쓴 뒤 5초 동안 쿨타임을 쓰기 위해 사용

    public void ConcentInit()
    {
        maxPower = 100;
        powerUp = 5; // 임시값으로 이것 역시 구조가 변경될 예정
        isReadySkill = false; //스킬이 준비가 안돼야 키입력이나 파워를 쌓을 수 있으니 false 
        buffTime = 10f;
        //추후 배열의 길이가 길어질 수도 있음
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

        //영창을 하기 위한 조건 키. 현재 수정된 기획서에는 토글형식이므로 이러한 코드로 변형이 됨
        if (!isReadySkill && Input.GetKeyDown(KeyCode.LeftShift))
        {
            CheckConcentrating();
        }

        //영찰 스킬 발현
        if (isReadySkill && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("스킬 발동");
            isReadySkill = false;
            SetPower(0); //스킬을 썼으니 초기화
            StartCoroutine(ConcentraitCoolTime());
        }

    }

    //코루틴 관련 함수는 현재 하나밖에 없고, 기획서상 추가될 것 같진 않아서 다양성을 배제하고 바로 제작함
    void CheckConcentrating()
    {
        //토글화 한 것
        if (isConcentrating)
        {
            //코루틴을 제대로 처음부터 시작하려면 스탑한 이후 내장된 코루틴 밸류를 삭제해야함.
            isConcentrating = false;
            StopCoroutine(coroutines[1]);
            coroutines[1] = null;
            player.SetMoveSpeed(20f); //영창 효과 해제
        }
        else
        {
            //삭제했으니 다시 삽입하는 과정
            isConcentrating = true;
            coroutines[1] = ConcentraitPowerUp();
            StartCoroutine(coroutines[1]);
            player.SetMoveSpeed(7f); //영창 효과 적용
        }
    }


    //파워를 모두 채울 시 10초간 발생하는 효과
    public IEnumerator PlalyerSkillBuff()
    {
        //스킬에 맞는 효과 발동 하는 곳
        Debug.Log("영창 스킬 발동! 하지만 나는 정직해서 아무 것도 안한다.");
        yield return new WaitForSeconds(buffTime);
        // 버프 효과가 끝났으므로 스킬 사용 권한 및 효과 해제
        isReadySkill = false;
    }

    public IEnumerator ConcentraitPowerUp()
    {
        //goto문..쓰지 말아야 하는건 맞지만..버그 해결과 효율을 위해서라면 미움받을 용기가 필요하지
    ReConcentrait:
        yield return new WaitForSeconds(1f);

        if (power + powerUp > maxPower)
        {
            //100을 오버하면 추푸 ui 및 기능 측면에 오류가 날 수 있음. 강제로 100조정하기
            SetPower(100);
            isReadySkill = true;
            //power값이 100에 도달했으므로 버프효과 및 스킬대기 발동
            StartCoroutine(coroutines[0]);
            Debug.Log("10초간 버프 발동! 스킬 대기 중");
        }
        else if (isConcentrating)
        {
            // 현재 파워값과 올라가는 파워값을 더해서 적용하는 방식
            SetPower(GetPower() + powerUp);
            Debug.Log("Power : " + GetPower());
            //stopCoroutine에 의해 중단되기에 재귀 함수로 사용해도 무방
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
        CheckConcentrating(); //스킬을 쓰고 난 뒤 5초 사이에 쉬프트를 눌러 해제했을 수도 있음 
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
