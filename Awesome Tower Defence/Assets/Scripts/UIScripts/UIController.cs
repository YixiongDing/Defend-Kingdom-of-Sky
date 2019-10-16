using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public int startingMoney;
    public int startingHealth;
    public int startingScore;
    public Text scoreText;
    public Text healthText;
    public Text moneyText;
    public Button startWaveButton;
    public Text enemiesLeft;
    
    public PlayerManager playerManager;
    public WaveManager waveManager;

    public int remainingEnemies;
    
    //public ScoreManager scoreManager;
    //public PlayerController player;

    // A very simple way to keep data persistent between scenes is via
    // a static attribute as below. There are other ways whereby statics
    // can be avoided, but involve a bit more complexity (use of persistent
    // objects between scenes).
    //public static bool lastGameWon;
    
    void Start ()
    {
        this.playerManager.score = startingScore;
        this.playerManager.health = startingHealth;
        this.playerManager.money = startingMoney;

        // Create swarm with parameters adjusted for difficulty
        //swarmManager.stepTime = 2.1f - (GlobalOptions.difficulty * 2.0f);
        //swarmManager.enemyRows = 2 + (int)(5.0f * GlobalOptions.difficulty);
        //swarmManager.GenerateSwarm();
    }

    void Update ()
    {
        // Update score text field
        this.scoreText.text = "Score: " + this.playerManager.score;

        this.healthText.text = "Health: " + this.playerManager.health;
        this.moneyText.text = "Money: " + this.playerManager.money;
        this.enemiesLeft.text = "Enemies Left: " + this.remainingEnemies;
    }

    

    // Called when the game should be ended
    // Changes the UI accordingly
    // Note: Currently hooked up to player health manager "zero event"
    //public void GameOver()
    //{
    //    InGameController.lastGameWon = false;
    //    SceneManager.LoadScene("GameEnded");
    //}

    //public void PlayerWon()
    //{
    //    InGameController.lastGameWon = true;
    //    SceneManager.LoadScene("GameEnded");
    //}
    public void waveStart()
    {
        this.startWaveButton.enabled = false;
    }

    public void waveComplete()
    {
        this.startWaveButton.enabled = true;
    }
}