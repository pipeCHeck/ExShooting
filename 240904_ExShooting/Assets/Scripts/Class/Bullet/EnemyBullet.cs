using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    //이러한 방식으로 두 속성을 정의한 근거는, 플레이어가 y를 기준으로
    //총알을 한참 뒤에 지나갔다 다시 뒤로 거쳐서 그레이즈를 시도하려는 경우도 있을 수 있음

    [SerializeField]
    public float grazeRadius; //총알의 중심을 기준으로 계산하는 그레이즈 유효 거리. x값만 비교해서 결정한자
    public float grazeAllowValue; //두 오브젝트의 y 값을 탐지하려는 그레이즈 판정 범위
    public float powerUpValue;

    bool isGrazeOn; // 그레이즈 성공 여부. 버그로 여러번 탐지되는 것을 방지한다.
    //bool isPassedPosition; // 위 주석의 코멘트에 의해 y값이 이미 지나갔으면 그레이즈는 더이상 처리되지 않게 한다

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed()); // 해당 함수를 상속받았으므로 반드시 사용해야함
        CheckGraze(); //테스트용으로 위치가 추후 변경될 수 있음
    }

    protected override void Init()
    {
        base.Init();

    }

    void CheckGraze() // Player 데이터를 기반으로 탐지한다. 그러나 추후 플레이어가 체력 0이 되어 목숨이 내려갈 때 문제 생길 수 있음
    {

        GameObject player;
        player = GameObject.Find("Player");
        if(CheckGraze(player))
        {
            PlayerConcentrater concent = player.GetComponent<PlayerConcentrater>();
            if(concent.GetIsPowerUp())
            {
                concent.SetPower(powerUpValue);
                Debug.Log("power up : " + concent.GetPower().ToString() + "by " + this.gameObject.name);
            }
            else
            {
                Debug.Log("파워를 모을 수 없는 상태");
            }
        }

    }


    bool CheckGraze(GameObject player)
    {
        //player 존재 여부, 그래이즈 이미 발동했는 지 여부
        if (player != null && !isGrazeOn) //&& !isPassedPosition, 그레이즈 발동 없이 이미 y값을 지나간 경우는 폐지하였음
        {
            float yValue = transform.position.y - player.transform.position.y;
            float xValue = transform.position.x - player.transform.position.x;

            if(transform.position.y < player.transform.position.y)
            {
                //isPassedPosition = true;
            }
            

            if (Mathf.Abs(yValue) < grazeAllowValue && Mathf.Abs(xValue) < grazeRadius)
            {
                isGrazeOn = true; // power값이 오르는 건 일회용
                return true;
            }
        }
        return false; // Player가 사라지거나, y값이 우리가 요구하는 범위가 아닌 경우
    }
}
