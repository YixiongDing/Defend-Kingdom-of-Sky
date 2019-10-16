using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    
    public int money = 0;
    public int health = 0;
    public int score = 0;
    
    public void ResetScore()
    {
        this.score = 0;
    }
    
    public void ResetHealth()
    {
        this.health = 0;
    }
    
    public void ResetMoney()
    {
        this.money = 0;
    }
}