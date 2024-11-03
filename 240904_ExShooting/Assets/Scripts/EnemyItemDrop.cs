using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    public GameObject scorePrefab;
    public GameObject[] itemPrefabs;

    public void CreateScorePrefabs(Vector3 pos, int amount)
    {
        for (int i = 0; i < amount; i++)
            Instantiate(scorePrefab, pos, Quaternion.identity);
    }

    public void CreateItemPrefab(Vector3 pos)
    {
        if (Random.Range(0, 3) == 0) 
            Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], pos, Quaternion.identity);
    }
}
