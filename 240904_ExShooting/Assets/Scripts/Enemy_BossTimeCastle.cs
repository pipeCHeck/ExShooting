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
        // ���� ��� (�̵� �� 2�� ����)
        yield return MoveToPosition(3f, new Vector3(300, 700, transform.position.z), new Vector3(300, 600, transform.position.z));

        yield return new WaitForSeconds(2f);

        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return MoveToRandomPosition(3f, 0f, 600f, 550f, 680f);
                yield return new WaitForSeconds(3);
            }

            Debug.Log("���� ����" + Random.Range(0, phase + 1));
        }
    }

    IEnumerator MoveToPosition(float moveDuration_, Vector3 startPosition_, Vector3 targetPosition_)
    {
        // 3�ʿ� ���� X300, Y700 -> X300, Y600���� �̵�
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        Vector3 startPosition = startPosition_;
        Vector3 targetPosition = targetPosition_;

        while (elapsedTime < moveDuration)
        {
            // ���� ���� �̵�
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �̵� �Ϸ� �� ��Ȯ�� ��ǥ ��ġ�� ����
        transform.position = targetPosition;
    }

    IEnumerator MoveToRandomPosition(float moveDuration_, float minX, float maxX, float minY, float maxY)
    {
        // 3�ʿ� ���� X300, Y700 -> X300, Y600���� �̵�
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);

        while (elapsedTime < moveDuration)
        {
            // ���� ���� �̵�
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �̵� �Ϸ� �� ��Ȯ�� ��ǥ ��ġ�� ����
        transform.position = targetPosition;
    }
}
