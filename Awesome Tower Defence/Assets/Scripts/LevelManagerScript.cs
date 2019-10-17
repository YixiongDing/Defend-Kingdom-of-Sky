using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public WaveManager[] waves;
    public PlayerManager player;
    public UIController uiManager;
    private int currentWave;

    public int enemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = 0;
        currentWave = 0;
    }

    public void enemyDestroyed(GenericEnemy enemy)
    {
        player.score += enemy.scoreValue;
        player.money += enemy.moneyValue;
        enemiesLeft--;
        uiManager.remainingEnemies = enemiesLeft;
        if (enemiesLeft == 0)
        {
            waveCompleted();
        }
    }

    public void nextWave()
    {
        enemiesLeft = 0;
        if (currentWave != waves.Length)
        {
            for (int i = 0; i < waves[currentWave].wave.Length; i++)
            {
                if (waves[currentWave].wave[i] != 0)
                {
                    enemiesLeft++;
                }
            }
            waves[currentWave].startWave();
            uiManager.remainingEnemies = enemiesLeft;
            uiManager.waveStart();
        }
        else
        {
            Debug.Log("Level Complete!");
        }
    }

    public void waveCompleted()
    {
        player.score += waves[currentWave].waveScoreBonus;
        player.money += waves[currentWave].waveMoneyBonus;
        uiManager.waveComplete();
        currentWave++;
    }

    public void enemyDestroyedAtGoal(GenericEnemy genericEnemy)
    {
        enemiesLeft--;
        uiManager.remainingEnemies = enemiesLeft;
        if (enemiesLeft == 0)
        {
            waveCompleted();
        }
    }
}
