using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Added
    GameManager gameManager;

    public List<Wave> waves = new List<Wave>(); // �̸� ������ ���̺� ���
    private bool allWavesCompleted = false; // ��� ���̺갡 �������� ����

    void Start()
    {
        //Added
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(ManageWaves());
    }

    // ���̺� ���� �ڷ�ƾ
    IEnumerator ManageWaves()
    {
        // ���̺� ���� �α� ���
        Debug.Log("��ȯ���� ��� ���� ���� ȯ���մϴ�.");

        foreach (Wave wave in waves)
        {
            yield return new WaitForSeconds(wave.startTime); // ���̺� ���� �ð����� ���

            // ���̺� ���� (�α� ���)
            Debug.Log("�̴Ͼ��� �����Ǿ����ϴ�. " + wave.waveName);
            StartCoroutine(SpawnWave(wave));

            // ���̺��� ��� ���� ��ȯ�� ������ ���
            yield return new WaitForSeconds(wave.enemyCount * wave.spawnCooldown); // �� �� ������ ��Ÿ�� ���ϱ�
        }

        // ��� ���̺갡 ������ �� (�α� ���)
        allWavesCompleted = true;
        Debug.Log("�¸�! (���̺� ����)");
    }

    // ���� ���̺꿡 �°� ��ȯ�ϴ� �ڷ�ƾ
    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemyCount; i++)
        {
            // ���� ��ġ�� �� ���� (����, ���� ���� �������Ƿ� �����)
            //int spawnIndex = Random.Range(0, wave.spawnPoints.Length);
            switch (wave.spawnPattern)
            {
                case Wave.SpawnPattern.FixedPattern: // ���� ��ġ ���� ����
                    Instantiate(wave.enemyPrefab, wave.spawnPoints[i], Quaternion.identity);
                    break;
                case Wave.SpawnPattern.XRandomPattern: // X�� ���� ��ġ ���� ����
                    Vector3 pos = wave.spawnPoints[0];
                    pos.x = Random.Range(wave.minMaxRange.x, wave.minMaxRange.y + 1);
                    Instantiate(wave.enemyPrefab, pos, Quaternion.identity);
                    break;
            }
            //Added
            gameManager.SetEnemyCount(gameManager.GetEnemyCount() + 1);
            yield return new WaitForSeconds(wave.spawnCooldown); // �� ��ȯ ��Ÿ��
        }

        // ���̺� ���� (�α� ���)
        Debug.Log("������. " + wave.waveName);
    }


    //Added
    public void SetAllWavesCompleted(bool boolValue)
    {
        allWavesCompleted = boolValue;
    }

    public bool GetAllWavesCompleted()
    {
        return allWavesCompleted;
    }
}
