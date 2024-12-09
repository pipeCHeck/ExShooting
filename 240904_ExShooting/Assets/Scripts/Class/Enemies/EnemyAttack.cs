using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : Enemy
{
    public Attacker attack; //공격하는 적은 기본적으로 어태커 스크립트를 불러온다. 공격할 수 있는 방법을 주어지기 때문
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); //태그 값 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Init()
    {
        base.Init();
        attack = GetComponent<Attacker>(); // 어태커 스크립트 로드
    }
}
