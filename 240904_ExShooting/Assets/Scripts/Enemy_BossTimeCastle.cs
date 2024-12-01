using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossTimeCastle : MonoBehaviour
{
    int phase = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(300, 700, transform.position.z);
        StartCoroutine(BossRoutine());
    }

    IEnumerator BossRoutine()
    {
        // 등장 모션 (이동 및 2초 정지)
        yield return MoveToPosition(3f, new Vector3(300, 700, transform.position.z), new Vector3(300, 600, transform.position.z));

        yield return new WaitForSeconds(2f);

        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return MoveToRandomPosition(3f, 0f, 600f, 550f, 680f);
                yield return new WaitForSeconds(3);
            }

            Debug.Log("공격 패턴" + Random.Range(0, phase + 1));
        }
    }

    IEnumerator MoveToPosition(float moveDuration_, Vector3 startPosition_, Vector3 targetPosition_)
    {
        // 3초에 걸쳐 X300, Y700 -> X300, Y600으로 이동
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        Vector3 startPosition = startPosition_;
        Vector3 targetPosition = targetPosition_;

        while (elapsedTime < moveDuration)
        {
            // 선형 보간 이동
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 이동 완료 후 정확한 목표 위치로 설정
        transform.position = targetPosition;
    }

    IEnumerator MoveToRandomPosition(float moveDuration_, float minX, float maxX, float minY, float maxY)
    {
        // 3초에 걸쳐 X300, Y700 -> X300, Y600으로 이동
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);

        while (elapsedTime < moveDuration)
        {
            // 선형 보간 이동
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 이동 완료 후 정확한 목표 위치로 설정
        transform.position = targetPosition;
    }
}
