using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    private bool isDead = false;
    public Transform targetPosition;
    public GameObject destroyExplosionPrefab;
    public LevelManagerScript levelManager;
    public int scoreValue;
    public int moneyValue;
    public int damageAmount;
    public int enemyType;
    public GameObject destroyShockwaveEffect;


    // This should be hooked up to the health manager on this object
    public void DestroyMe()
    {
        if (isDead == false)
        {
            isDead = true;
            // Create explosion effect
            GameObject explosion = Instantiate(this.destroyExplosionPrefab);
            explosion.transform.position = this.transform.position;
            GameObject shockwave = Instantiate(destroyShockwaveEffect);
            shockwave.transform.position = transform.position;
            shockwave.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
            levelManager.enemyDestroyed(this);
            // Destroy self
            //Destroy(this.gameObject);
        }
    }

    public void DestroyMeAtGoal()
    {
        if (isDead == false)
        {
            isDead = true;
            levelManager.enemyDestroyedAtGoal(this);
            // Create explosion effect
            GameObject explosion = Instantiate(this.destroyExplosionPrefab);
            explosion.transform.position = this.transform.position;
        
            // Destroy self
            // Destroy(this.gameObject);
        }
        
    }
    
}
