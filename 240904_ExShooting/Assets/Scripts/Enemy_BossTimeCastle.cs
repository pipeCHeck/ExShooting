using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossTimeCastle : MonoBehaviour
{
    public GameObject[] patternPrefab; // 공격 패턴 프리펩
    int phase = 2; // 현재 페이즈

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(patternPrefab[0]);
        transform.position = new Vector3(12.2f, 0, transform.position.z);
        StartCoroutine(BossRoutine());
    }

    // 보스 움직임 코루틴
    IEnumerator BossRoutine()
    {
        // 등장 모션 (이동 및 2초 정지)
        yield return MoveToPosition(3f, transform.position, new Vector3(8f, 0, transform.position.z));
        yield return new WaitForSeconds(2f);

        while (true)
        {
            // 3번의 랜덤 위치 이동과 정지 반복
            for (int i = 0; i < 3; i++)
            {
                yield return MoveToRandomPosition(3f, 0f, 11f, -5f, 5f);
                yield return new WaitForSeconds(1);
            }

            // 현재 페이즈에 따라 공격 패턴 (phase가 증가하면 패턴 수 증가)
            int patternNum = Random.Range(0, phase + 1);
            Debug.Log("공격 패턴" + patternNum);
            Instantiate(patternPrefab[patternNum]);

            // 패턴 실행 후 3초간 정지
            yield return new WaitForSeconds(3);
        }
    }

    // 고정 위치 이동 코루틴
    IEnumerator MoveToPosition(float moveDuration_, Vector3 startPosition_, Vector3 targetPosition_)
    {
        // 이동에 걸릴 총 시간을 저장
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        // 시작 위치와 목표 위치를 설정
        Vector3 startPosition = startPosition_;
        Vector3 targetPosition = targetPosition_;

        while (elapsedTime < moveDuration)
        {
            // 선형 보간을 사용하여 이동
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime; // 시간 확인
            yield return null; // 다음 프레임으로
        }

        // 이동 완료 후 정확한 목표 위치로 설정
        transform.position = targetPosition;
    }

    // 랜덤 위치 이동 코루틴
    IEnumerator MoveToRandomPosition(float moveDuration_, float minX, float maxX, float minY, float maxY)
    {
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
