using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : Bullet
{
    GameObject targetObject;
    Vector3[] targetObjectsVec;
    Vector3 tununingDir;
    float rotationSpeed = 1f; //미사일이 회전할 수 있는 최대 각도. 미사일일 특정 오브젝트를 추격하는 시간이 길어질 수록 값이 오름

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        TunningObject();
    }

    //적의 오브젝트를 탐지하는 목적
    void TargetSearching()
    {
        //가까운 오브젝트를 알아내기 위한 속성 초기값을 크게 둬야 단거리로 갱신하기 쉽다
        float targetObjectDistance = 200f;

        //존재하는 적 오브젝트 탐지
        GameObject[] instanceObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //타겟들의 데이터 크기 조사
        targetObjectsVec = new Vector3[instanceObjects.Length];
        float targetDistance = 0;
        //데이터 위치값 조사. 가까운 오브젝트를 찾아야 하기 때문
        for (int i = 0; i < targetObjectsVec.Length; i++)
        {
            targetObjectsVec[i] = instanceObjects[i].GetComponent<Character>().transform.position;
            targetDistance = (targetObjectsVec[i] - this.transform.position).magnitude;
            //총알과 적의 거리 비교 후 오브젝트 및 거리 갱신. 또한 화면 기준 아직 벗어나지 않은 적을 기준으로 탐지
            if (targetObjectDistance > targetDistance &&
                Mathf.Abs(targetObjectsVec[i].x) <= 11 &&
                Mathf.Abs(targetObjectsVec[i].y) <= 5)
            {
                targetObjectDistance = targetDistance;
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
            //다른 형태의 유도탄1. 
            Vector2 direction2D = (Vector2)(targetObject.transform.position - transform.position).normalized;
            transform.up = Vector2.Lerp(transform.up, direction2D, 0.1f);
            */



            // 목표 방향 벡터 계산
            Vector3 directionToTarget = (targetObject.transform.position - transform.position).normalized;

            // 방향 벡터를 계산할 때 2D형식은 up을 기준으로 함
            Vector3 currentForward = transform.up; 

            
            // 회전 각도 계산
            float angle = Vector3.SignedAngle(currentForward, directionToTarget, Vector3.forward);

            // 회전 적용
            if (angle != 0)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, angle * GetRotationSpeed() * Time.deltaTime);
                transform.rotation = rotation * transform.rotation;
                // 회전각을 더하는 이유는 일정한 각도로 빠르게 설정하면 유도탄 답지 않은 연출이 되며, 낮게 주면 오브젝트를 맞추지 못하고 공전하는듯한 현상을 보인다.
                // 이로 인해 한번 타깃을 정한 오브젝트의 추적이 길어질 수록 회전 한계값을 늘려 결국 적중하게 만듦
                SetRotationSpeed(GetRotationSpeed() + 1.5f);
            }

            Debug.Log(GetMoveSpeed());
        }
        else //targetResearching
        {
            TargetSearching();
            //위 회전각을 더하는 원리에 의해서 타깃이 사라져 재탐지하거나 최초 탐지를 할 때 초기화를 해야한다 
            SetRotationSpeed(0.5f);
        }
    }

    protected override void Init()
    {
        base.Init();

        //미사일은 조금 느리게 움직이기
        SetMoveSpeed(15f);
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
