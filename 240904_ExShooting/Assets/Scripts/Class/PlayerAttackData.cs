using UnityEngine;

//�÷��̾ ���Ⱝȭ�� ���� �� ������� ����ϰ� �Ǵ� �����͵�. �ν����Ϳ� ������ �� ������, PlayerAttack��ũ��Ʈ�� ������ ���⿡ �´� �ش� ����ü�� �����͸� �̿��Ѵ�
[System.Serializable]
public class PlayerAttackData
{
    public string weaponName; // ����Ÿ��
    public Vector3[] shootVec; // ����� �߻����� ��ġ. ���� ���� Ȱ��ȭ �� �� �ִ� �����Ͱ� �����Ѵ�
    
    //�Ʒ� �����͵��� ������ �´� ����� �����Ǿ� �־� �ε����� 5���̴�.
    public int[] shootVecCount; //�߻���� ����. �� ���� ���� Ȱ��ȭ �� �� �ִ� ��ġ������
    public float[] attackDelay; // ���� �ֱ�
    public float[] attackDamage; // ���ط�

    //�������� ��� �̵��ϴ� Ư¡�� �ƴ��� ������ ���������� �ε����� �����ϳ� ���� ���� 0�̴�
    public float[] shootSpeed; //����ü �ӵ�

    
}
