using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Range(0,100)] public int maxWaveCount = 10, waveRate = 5;
    int waveCount = 0;
    Spawner spawner;
    void Start()
    {
        spawner = GetComponent<Spawner>();
        InvokeRepeating("StartWave", waveRate, waveRate);

    }
    void Update()
    {
        if(waveCount >= maxWaveCount)
        {
            CancelInvoke();
        }
    }
    void StartWave()
    {
        int r = Random.Range(0, 3);
        if (r == 0)
        {
            spawner.top = true;
        }
        else if (r == 1)
        {
            spawner.bot = true;
        }
        else if (r == 2)
        {
            spawner.left = true;
        }
        else if (r == 3)
        {
            spawner.right = true;
        }
    }
}
