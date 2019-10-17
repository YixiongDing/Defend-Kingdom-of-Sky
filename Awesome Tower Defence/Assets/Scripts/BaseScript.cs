using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public PlayerManager player;
    public string tagToDamage;
    public GameObject deathParticles;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            player.health -= col.gameObject.GetComponent<GenericEnemy>().damageAmount;
            col.gameObject.GetComponent<GenericEnemy>().DestroyMe();
            if (player.health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Instantiate(deathParticles);
    }
}
