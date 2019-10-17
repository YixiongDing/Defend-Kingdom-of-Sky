using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{      

    public Transform enemyPrefab; // prefab of the enemy
    public Transform spawnPoint; 
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;
    public Text waveCountDownText; 

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
        
        // Redo countdown by 1 every second
        countdown -= Time.deltaTime; // The amount of time passed since the last time drew a fram

        // Round the float number to int and display the count down number
        waveCountDownText.text = "Next Wave: " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()   
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();

            // Handle enemy overlap
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Wave Incoming");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
