using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{
    public int[] wave;
    public float spawnDelay;
    public EnemySpawner spawner;
    private float timeCounter;
    private int enemyCount;
    public int enemyNum;
    private bool waveStarted;
    public int waveMoneyBonus;
    public int waveScoreBonus;


    // Start is called before the first frame update
    void Start()
    {
        waveStarted = false;
        enemyCount = wave.Length;
        enemyNum = 0;
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveStarted)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= spawnDelay)
            {
                if (enemyNum < enemyCount)
                {
                    spawner.spawnEnemy(wave[enemyNum]);
                    enemyNum++;
                }

                timeCounter = 0;
            }
        }
        
    }

    public void startWave()
    {
        waveStarted = true;
    }

}
