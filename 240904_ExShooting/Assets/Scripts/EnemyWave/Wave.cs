using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string waveName; // ���̺��� �̸�
    public GameObject enemyPrefab; // ���̺꿡�� ��ȯ�� ���� ������
    public int enemyCount; // ��ȯ�� ���� ��
    public float spawnCooldown; // ���� ��ȯ�Ǵ� ��Ÿ��
    public Vector3[] spawnPoints; // ���� ��ȯ�� ��ġ (Ÿ�Կ� ���� �ٸ��� ���� �� ����)
    public Vector2 minMaxRange; // ���� �� �ּҰ��� �ִ밪
    public float startTime; // �� ���̺갡 ���۵Ǵ� �ð�

    public enum SpawnPattern
    {
        FixedPattern,   // ���� ��ġ ����
        XRandomPattern,  // X�� ���� ��ġ ����
        YRandomPattern,  // Y�� ���� ��ġ ����
    }

    public SpawnPattern spawnPattern; // �� ���̺갡 ������ ���� ����

    // ������
    public Wave(string name, GameObject prefab, int count, float cooldown, Vector3[] points, Vector2 minMax, float time, SpawnPattern pattern)
    {
        waveName = name;
        enemyPrefab = prefab;
        enemyCount = count;
        spawnCooldown = cooldown;
        spawnPoints = points;
        minMaxRange = minMax;
        startTime = time;
        spawnPattern = pattern;
    }
}
