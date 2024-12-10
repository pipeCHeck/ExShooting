using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossTimeCastle : MonoBehaviour
{
    public GameObject[] patternPrefab; // ���� ���� ������
    int phase = 2; // ���� ������

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(patternPrefab[0]);
        transform.position = new Vector3(12.2f, 0, transform.position.z);
        StartCoroutine(BossRoutine());
    }

    // ���� ������ �ڷ�ƾ
    IEnumerator BossRoutine()
    {
        // ���� ��� (�̵� �� 2�� ����)
        yield return MoveToPosition(3f, transform.position, new Vector3(8f, 0, transform.position.z));
        yield return new WaitForSeconds(2f);

        while (true)
        {
            // 3���� ���� ��ġ �̵��� ���� �ݺ�
            for (int i = 0; i < 3; i++)
            {
                yield return MoveToRandomPosition(3f, 0f, 11f, -5f, 5f);
                yield return new WaitForSeconds(1);
            }

            // ���� ����� ���� ���� ���� (phase�� �����ϸ� ���� �� ����)
            int patternNum = Random.Range(0, phase + 1);
            Debug.Log("���� ����" + patternNum);
            Instantiate(patternPrefab[patternNum]);

            // ���� ���� �� 3�ʰ� ����
            yield return new WaitForSeconds(3);
        }
    }

    // ���� ��ġ �̵� �ڷ�ƾ
    IEnumerator MoveToPosition(float moveDuration_, Vector3 startPosition_, Vector3 targetPosition_)
    {
        // �̵��� �ɸ� �� �ð��� ����
        float moveDuration = moveDuration_;
        float elapsedTime = 0;

        // ���� ��ġ�� ��ǥ ��ġ�� ����
        Vector3 startPosition = startPosition_;
        Vector3 targetPosition = targetPosition_;

        while (elapsedTime < moveDuration)
        {
            // ���� ������ ����Ͽ� �̵�
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime; // �ð� Ȯ��
            yield return null; // ���� ����������
        }

        // �̵� �Ϸ� �� ��Ȯ�� ��ǥ ��ġ�� ����
        transform.position = targetPosition;
    }

    // ���� ��ġ �̵� �ڷ�ƾ
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
