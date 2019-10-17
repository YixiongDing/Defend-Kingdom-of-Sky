using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    public GameObject destroyExplosionPrefab;
    public LevelManagerScript levelManager;
    public int scoreValue;
    public int moneyValue;
    public int damageAmount;
    public int enemyType;


    // This should be hooked up to the health manager on this object
    public void DestroyMe()
    {
        levelManager.enemyDestroyed(this);
        // Create explosion effect
        GameObject explosion = Instantiate(this.destroyExplosionPrefab);
        explosion.transform.position = this.transform.position;
        
        // Destroy self
        Destroy(this.gameObject);
    }

    public void DestroyMeAtGoal()
    {
        levelManager.enemyDestroyedAtGoal(this);
        // Create explosion effect
        GameObject explosion = Instantiate(this.destroyExplosionPrefab);
        explosion.transform.position = this.transform.position;
        
        // Destroy self
        Destroy(this.gameObject);
    }
    
}
