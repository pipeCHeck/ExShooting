using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public int score; //���� �⺻������ �÷��̾ ���� ������ ������
    bool isAlreadyDeath; //������θ� Ȯ���ϱ� ���� ����

     protected virtual void Start()
     {
        Init(); //void
        SetTag("Enemy"); //���̹Ƿ� �� �±� ����
        if (score == 0)
        {
            //�ʱⰪ ����
            SetEnemyScore(100);
        }
        Debug.Log("Started enemy");
     }
    public override void SetDamagedHp(float damageValue)
    {
        //���ظ� ���� �� ü���� �����ϸ�, 0���� �� �� ������ �ο��ϸ� ����
        base.SetDamagedHp(damageValue);
        if (GetHp() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /* // ���ھ� ��� ���� ó���� ���� ������ ����
    //���� �÷��̾�� ������ ���� �� ���� �� ����
    protected override void DeathEvent()
    {
        base.DeathEvent();
        gameManager.SetStageScore(score);

        EnemyCountUpdate();
    }

    */

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
