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
//    public TurretManager turretManager;
    
    public PlayerManager playerManager;

    public int remainingEnemies;
    
    
    void Start ()
    {
        this.playerManager.score = startingScore;
        this.playerManager.health = startingHealth;
        this.playerManager.money = startingMoney;
    }

    void Update ()
    {
        // Update score text field
        this.scoreText.text = "Score: " + this.playerManager.score;
        this.healthText.text = "Health: " + this.playerManager.health;
        this.moneyText.text = "Money: " + this.playerManager.money;
        this.enemiesLeft.text = "Enemies Left: " + this.remainingEnemies;
    }
    

    public void waveStart()
    {
        this.startWaveButton.enabled = false;
    }

    public void waveComplete()
    {
        this.startWaveButton.enabled = true;
    }

//    public void selectTower(GameObject towerType)
//    {
//        TurretManager.instance.set= towerType;
//    }
}