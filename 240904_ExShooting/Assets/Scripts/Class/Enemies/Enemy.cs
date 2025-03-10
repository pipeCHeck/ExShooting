using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public int score; //적은 기본적으로 플레이어를 위한 점수를 제공함
    bool isAlreadyDeath; //사망여부를 확인하기 위한 변수

     protected virtual void Start()
     {
        Init(); //void
        SetTag("Enemy"); //적이므로 적 태그 설정
        if (score == 0)
        {
            //초기값 설정
            SetEnemyScore(100);
        }
        Debug.Log("Started enemy");
     }
    public override void SetDamagedHp(float damageValue)
    {
        //피해를 받을 시 체력이 감소하며, 0이하 일 시 점수를 부여하며 삭제
        base.SetDamagedHp(damageValue);
        if (GetHp() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /* // 스코어 상승 관련 처리는 추후 수정할 예정
    //적이 플레이어에게 죽으면 점수 및 남은 적 감소
    protected override void DeathEvent()
    {
        base.DeathEvent();
        gameManager.SetStageScore(score);

        EnemyCountUpdate();
    }

    */

    //죽지 않은 채 화면에 벗어난 경우 gameManager 내 잔여 적 카운트 감소
    protected void EnemyCountUpdate()
    {
        if (!isAlreadyDeath)
        {
            //gameManager.SetEnemyCount(gameManager.GetEnemyCount() - 1);
            isAlreadyDeath = true;
        }
    }

    //현재로선 적이 내려오는 기준으로 작성하였기에 추후 다시 작업하거나 수정될 예정.
    protected void EnemyAutoRemove()
    {
        if(transform.position.y < -5f)
        {
            EnemyCountUpdate();
            Destroy(this.gameObject);
        }
    }

    protected override void Init()
    {
        //void
    }

    //getset
    public void SetEnemyScore(int value)
    {
        score = value;
    }

    int GetEnemyScore()
    {
        return score;
    }
}
