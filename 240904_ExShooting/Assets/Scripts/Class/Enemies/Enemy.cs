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

    //���� �÷��̾�� ������ ���� �� ���� �� ����
    protected override void DeathEvent()
    {
        base.DeathEvent();
        gameManager.SetStageScore(score);

        EnemyCountUpdate();
    }


    //���� ���� ä ȭ�鿡 ��� ��� gameManager �� �ܿ� �� ī��Ʈ ����
    protected void EnemyCountUpdate()
    {
        if (!isAlreadyDeath)
        {
            //gameManager.SetEnemyCount(gameManager.GetEnemyCount() - 1);
            isAlreadyDeath = true;
        }
    }

    //����μ� ���� �������� �������� �ۼ��Ͽ��⿡ ���� �ٽ� �۾��ϰų� ������ ����.
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
