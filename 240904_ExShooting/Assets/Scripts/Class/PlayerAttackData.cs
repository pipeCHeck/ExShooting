using UnityEngine;

//플레이어가 무기강화를 통해 각 무기들이 상승하게 되는 데이터들. 인스펙터에 수정할 수 있으며, PlayerAttack스크립트가 레벨과 무기에 맞는 해당 구조체의 데이터를 이용한다
[System.Serializable]
public class PlayerAttackData
{
    public string weaponName; // 공격타입
    public Vector3[] shootVec; // 설계된 발사대들의 위치. 레벨 마다 활성화 할 수 있는 데이터가 존재한다
    
    //아래 데이터들은 레벨에 맞는 값들로 구성되어 있어 인덱스가 5개이다.
    public int[] shootVecCount; //발사대의 개수. 각 레벨 마다 활성화 할 수 있는 위치값들이
    public float[] attackDelay; // 공격 주기
    public float[] attackDamage; // 피해량

    //레이저의 경우 이동하는 특징이 아니지 때문에 형식적으로 인덱스가 존재하나 실제 값은 0이다
    public float[] shootSpeed; //투사체 속도

    
}
