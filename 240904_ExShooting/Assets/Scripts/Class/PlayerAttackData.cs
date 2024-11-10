using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾ ���Ⱝȭ�� ���� �� ������� ����ϰ� �Ǵ� �����͵�. �ν����Ϳ� ������ �� ������, PlayerAttack��ũ��Ʈ�� ������ ���⿡ �´� �ش� ����ü�� �����͸� �̿��Ѵ�
[System.Serializable]
public class PlayerAttackData
{
    //���� �Ʒ��� ��� �����͵��� ��ȹ�� ��� �߰��� ���� �ƴϱ� ������ ���������� ���Ǵ� �����͸� �Ϻ� �����Ѵ�. ���� ���� �� �̻� ����� ���� ������ �ּ� ó���� ���� �� ����

    //public Sprite bulletImage; //���� �Ѿ� �̹��� �����͸� �ش� ��ũ��Ʈ�� �ֱ�� �����ϸ� �ٷ� ������ ����

    public string weaponName; // ����Ÿ��
    public GameObject weapon;
    
    //�Ʒ� �����͵��� ������ �´� ����� �����Ǿ� �־� �ε����� 5���̴�.
    public int shootVecCount; //�߻���� ����. �� ���� ���� Ȱ��ȭ �� �� �ִ� ��ġ������
    public float[] attackDelay; // ���� �ֱ�
    public float[] attackDamage; // ���ط�

    //�������� ��� �̵��ϴ� Ư¡�� �ƴ��� ������ ���������� �ε����� �����ϳ� ���� ���� 0�̴�
    public float[] shootSpeed; //����ü �ӵ�

}
