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
    public int maxEnemyCount = 10, timeToStart = 5;
    public float enemySpawnRate = 2f;
    int eCount = 0, spawnPosIndex = 0;
    public bool top, bot, right, left;

    private void Start()
    {
        Invoke("WaveSpawn", timeToStart);
    }
    private void Update()
    {
        SpawnController();
    }
    void WaveSpawn()
    {
        while(eCount < maxEnemyCount)
        {
        eCount++;
        Invoke("Enemy", eCount*enemySpawnRate);
        }
    }
    void Enemy()
    {
        Instantiate(enemy, spawnPos[spawnPosIndex].position, Quaternion.identity);
    }

    void SpawnController()
    {
        if(top)
        {
            top = false;
            eCount = 0;
            spawnPosIndex = 0;
            WaveSpawn();
        }
        if (bot)
        {
            bot = false;
            eCount = 0;
            spawnPosIndex = 1;
            WaveSpawn();
        }
        if(right)
        {
            right = false;
            eCount = 0;
            spawnPosIndex = 2;
            WaveSpawn();
        }
        if(left)
        {
            left = false;
            eCount = 0;
            spawnPosIndex = 3; 
            WaveSpawn();
        }
    }
}