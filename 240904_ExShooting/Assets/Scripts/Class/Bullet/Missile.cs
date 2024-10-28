using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    GameObject targetObject;
    Vector3[] targetObjectsVec;
    Vector3 tununingDir;
    float rotationSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove(Vector3.up, GetMoveSpeed());
        TunningObject();
    }

    //적의 오브젝트를 탐지하는 목적
    void TargetSearching()
    {
        //가까운 오브젝트를 알아내기 위한 속성 초기값을 크게 둬야 단거리로 갱신하기 쉽다
        float targetObjectDistance = 100f;

        //존재하는 적 오브젝트 탐지
        GameObject[] instanceObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //타겟들의 데이터 크기 조사
        targetObjectsVec = new Vector3[instanceObjects.Length];

        //데이터 위치값 조사. 가까운 오브젝트를 찾아야 하기 때문
        for (int i = 0; i < targetObjectsVec.Length; i++)
        {
            targetObjectsVec[i] = instanceObjects[i].GetComponent<Enemy>().transform.position;

            //거리 비교 후 오브젝트 및 거리 갱신. 또한 플레이어 전방의 오브젝트를 탐지하는 것으로 정의
            if (targetObjectDistance > targetObjectsVec[i].magnitude)
            {
                targetObjectDistance = targetObjectsVec[i].magnitude;
                targetObject = instanceObjects[i];
            }
        }
    }

    //missile의 경우 유도탄이므로 회전한다
    void TunningObject()
    {
        //해당 목표물을 향해 점차 회전하는 방식. 만약 타겟이 사라졌을 경우 재탐색을 한다
        if (targetObject != null)
        {
            /*
            Vector2 direction2D = (Vector2)(targetObject.transform.position - transform.position).normalized;
            transform.up = Vector2.Lerp(transform.up, direction2D, 0.1f);
            */

            Vector2 direction = (targetObject.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 각도 구하기
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Z축 회전만 적용


            Quaternion rotateValue = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);

            transform.rotation = rotateValue;
        }
        else //targetResearching
        {
            TargetSearching();
        }
    }

    protected override void Init()
    {
        base.Init();

        // 반반의 확률로 회전하는 각도 자체를 변형함
        if (Random.Range(0, 2) == 1)
        {
            rotationSpeed *= -1;
        }
        //미사일은 조금 느리게 움직이기
        SetMoveSpeed(GetMoveSpeed() - 7f);
        //생성되자마자 타겟 설정
        TargetSearching();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HitCharacterByCollision(ref other);
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }

    public void SetRotationSpeed(float rotateValue)
    {
        rotationSpeed = rotateValue;
    }
}
