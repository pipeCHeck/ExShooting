using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string waveName; // 웨이브의 이름
    public GameObject enemyPrefab; // 웨이브에서 소환될 적의 프리팹
    public int enemyCount; // 소환할 적의 수
    public float spawnCooldown; // 적이 소환되는 쿨타임
    public Vector3[] spawnPoints; // 적이 소환될 위치 (타입에 따라 다르게 사용될 수 있음)
    public Vector2 minMaxRange; // 랜덤 수 최소값과 최대값
    public float startTime; // 이 웨이브가 시작되는 시간

    public enum SpawnPattern
    {
        FixedPattern,   // 고정 위치 패턴
        XRandomPattern,  // X값 랜덤 위치 패턴
        YRandomPattern,  // Y값 랜덤 위치 패턴
    }

    public SpawnPattern spawnPattern; // 이 웨이브가 가지는 생성 패턴

    // 생성자
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
