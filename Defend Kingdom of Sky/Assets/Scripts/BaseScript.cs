using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public PlayerManager player;
    public string tagToDamage;
    public static bool GameIsOver = false;

    void Start()
    {
        GameIsOver = false;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(tagToDamage))
        {
            player.health -= col.gameObject.GetComponent<GenericEnemy>().damageAmount;
            col.gameObject.GetComponent<GenericEnemy>().DestroyMeAtGoal();
            if (player.health <= 0) 
            {
                GameIsOver = true;
            }
        }
    }
}
