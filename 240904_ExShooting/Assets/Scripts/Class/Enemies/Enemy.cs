using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int score;
    bool isAlreadyDeath;
    public override void SetDamagedHp(float damageValue)
    {
        base.SetDamagedHp(damageValue);
        if (GetHp() <= 0)
        {
            DeathEvent();
            Destroy(this.gameObject);
        }
    }

    //적이 플레이어에게 죽으면 점수 및 남은 적 감소
    protected override void DeathEvent()
    {
        base.DeathEvent();
        gameManager.SetStageScore(score);

        EnemyCountUpdate();
    }


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
        base.Init();
        SetTag("Enemy");
        if(score == 0)
        {
            SetEnemyScore(100);
        }
    }

    public void SetEnemyScore(int value)
    {
        score = value;
    }

    int GetEnemyScore()
    {
        return score;
    }
}
