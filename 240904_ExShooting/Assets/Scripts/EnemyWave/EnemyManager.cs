using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Wave> waves = new List<Wave>(); // 미리 정의한 웨이브 목록
    private bool allWavesCompleted = false; // 모든 웨이브가 끝났는지 여부

    void Start()
    {
        StartCoroutine(ManageWaves());
    }

    // 웨이브 관리 코루틴
    IEnumerator ManageWaves()
    {
        // 웨이브 시작 로그 출력
        Debug.Log("소환사의 협곡에 오신 것을 환영합니다.");

        foreach (Wave wave in waves)
        {
            yield return new WaitForSeconds(wave.startTime); // 웨이브 시작 시간까지 대기

            // 웨이브 시작 (로그 출력)
            Debug.Log("미니언이 생성되었습니다. " + wave.waveName);
            StartCoroutine(SpawnWave(wave));

            // 웨이브의 모든 적이 소환될 때까지 대기
            yield return new WaitForSeconds(wave.enemyCount * wave.spawnCooldown); // 적 한 마리당 쿨타임 곱하기
        }

        // 모든 웨이브가 끝났을 때 (로그 출력)
        allWavesCompleted = true;
        Debug.Log("승리! (웨이브 종료)");
    }

    // 적을 웨이브에 맞게 소환하는 코루틴
    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemyCount; i++)
        {
            // 랜덤 위치에 적 생성 (고정, 랜덤 패턴 나눴으므로 폐쇄함)
            //int spawnIndex = Random.Range(0, wave.spawnPoints.Length);
            switch (wave.spawnPattern)
            {
                case Wave.SpawnPattern.FixedPattern: // 고정 위치 생성 패턴
                    Instantiate(wave.enemyPrefab, wave.spawnPoints[i], Quaternion.identity);
                    break;
                case Wave.SpawnPattern.XRandomPattern: // X값 랜덤 위치 생성 패턴
                    Vector3 pos = wave.spawnPoints[0];
                    pos.x = Random.Range(wave.minMaxRange.x, wave.minMaxRange.y + 1);
                    Instantiate(wave.enemyPrefab, pos, Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(wave.spawnCooldown); // 적 소환 쿨타임
        }

        // 웨이브 종료 (로그 출력)
        Debug.Log("마무리. " + wave.waveName);
    }
}
