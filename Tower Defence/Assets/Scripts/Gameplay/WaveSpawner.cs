using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;

    public float waveTime = 5.0f;
    private float countDown = 0.0f;

    private int waveNumber = 0;
    private int enemiesAlive = 0;

    public Text waveNumberText;

    public void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = waveTime;
            return;
        }

        countDown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave()
    {
        ++waveNumber;
        waveNumberText.text = waveNumber.ToString();

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemiesAlive = 10;

        for (int i = 0; i < enemiesAlive; i++)
        {
            SpawnEnemy(enemyPrefab);

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void SpawnEnemy(GameObject go)
    {
        Instantiate(go, spawnPoint.position, Quaternion.identity);
    }
}
