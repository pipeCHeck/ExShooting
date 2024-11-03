using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public int expAmount;

    EnemyItemDrop enemyItemDrop;

    private void OnDestroy()
    {
        enemyItemDrop = GameObject.FindGameObjectWithTag("ItemDropManager").GetComponent<EnemyItemDrop>();
        enemyItemDrop.CreateScorePrefabs(transform.position, expAmount);
        enemyItemDrop.CreateItemPrefab(transform.position);
    }
}
