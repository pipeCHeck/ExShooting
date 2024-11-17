using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    public GameObject scorePrefab;
    public GameObject[] itemPrefabs;
    //public GameObject weaponLevelUpKit; //아이템 3개가 플레이어에게 오는..친구

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

    /*
    public void SpawnWeaponLevelUp()
    { 
        Vector3 instanceSpawnVec = new Vector3(-11f, 0, 0);
        Instantiate(weaponLevelUpKit, instanceSpawnVec, transform.rotation);
    }
    */
}
