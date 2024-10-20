using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    //�̷��� ������� �� �Ӽ��� ������ �ٰŴ�, �÷��̾ y�� ��������
    //�Ѿ��� ���� �ڿ� �������� �ٽ� �ڷ� ���ļ� �׷���� �õ��Ϸ��� ��쵵 ���� �� ����

    [SerializeField]
    public float grazeRadius; //�Ѿ��� �߽��� �������� ����ϴ� �׷����� ��ȿ �Ÿ�. x���� ���ؼ� ��������
    public float grazeAllowValue; //�� ������Ʈ�� y ���� Ž���Ϸ��� �׷����� ���� ����
    public float powerUpValue;

    bool isGrazeOn; // �׷����� ���� ����. ���׷� ������ Ž���Ǵ� ���� �����Ѵ�.
    //bool isPassedPosition; // �� �ּ��� �ڸ�Ʈ�� ���� y���� �̹� ���������� �׷������ ���̻� ó������ �ʰ� �Ѵ�

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed()); // �ش� �Լ��� ��ӹ޾����Ƿ� �ݵ�� ����ؾ���
        CheckGraze(); //�׽�Ʈ������ ��ġ�� ���� ����� �� ����
    }

    protected override void Init()
    {
        base.Init();

    }

    void CheckGraze() // Player �����͸� ������� Ž���Ѵ�. �׷��� ���� �÷��̾ ü�� 0�� �Ǿ� ����� ������ �� ���� ���� �� ����
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
                Debug.Log("�Ŀ��� ���� �� ���� ����");
            }
        }

    }


    bool CheckGraze(GameObject player)
    {
        //player ���� ����, �׷����� �̹� �ߵ��ߴ� �� ����
        if (player != null && !isGrazeOn) //&& !isPassedPosition, �׷����� �ߵ� ���� �̹� y���� ������ ���� �����Ͽ���
        {
            float yValue = transform.position.y - player.transform.position.y;
            float xValue = transform.position.x - player.transform.position.x;

            if(transform.position.y < player.transform.position.y)
            {
                //isPassedPosition = true;
            }
            

            if (Mathf.Abs(yValue) < grazeAllowValue && Mathf.Abs(xValue) < grazeRadius)
            {
                isGrazeOn = true; // power���� ������ �� ��ȸ��
                return true;
            }
        }
        return false; // Player�� ������ų�, y���� �츮�� �䱸�ϴ� ������ �ƴ� ���
    }
}
