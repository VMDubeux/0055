using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform [] spawnPos;
    public int maxEnemyCount = 10, timeToStart = 5, wave = 5, timeBetweenWaves = 3;
    int eCount = 0;

    private void Start()
    {
        Invoke("SpawnEnemies", timeToStart);
    }
    private void Update()
    {

    }
    void SpawnEnemies()
    {
        while(eCount < maxEnemyCount)
        {
        eCount++;
        Invoke("Enemy", eCount*timeBetweenWaves );
        }
    }
    void Enemy()
    {
        int r = Random.Range(0, spawnPos.Length);
        for( int i = 0; i < wave; i++)
        {
            StartCoroutine(EnemyUnit(r));
        }
    }
    IEnumerator EnemyUnit(int r)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Instantiate(enemy, spawnPos[r].position, Quaternion.identity);
    }
}