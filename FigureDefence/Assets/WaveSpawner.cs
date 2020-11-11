using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.0f;
    private float countDown = 2f;

    private int waveIndex = 0;
    private void Update()
    {
        if(countDown <= 0.0f)
        {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        for(int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
