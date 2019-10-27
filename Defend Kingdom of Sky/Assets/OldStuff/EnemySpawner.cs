using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyType1;
    public GameObject EnemyType2;
    public GameObject EnemyType3;
    public GameObject EnemyType4;
    public GameObject EnemyType5;

    public LevelManagerScript levelManager;
    //public int spawnDelay;
    //public int enemyCount;


   // private int enemiesSpawned = 0;

    //private float timeCount = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
//    void Update()
//    {
//        if (enemyCount > enemiesSpawned)
//        {
//            if (timeCount + Time.deltaTime > spawnDelay)
//            {
//                GameObject enemy = GameObject.Instantiate<GameObject>(EnemyPrefab);
//                enemy.GetComponent<NavMeshAgent>().destination = Target.transform.position;
//                enemy.transform.position = this.gameObject.transform.position;
//                timeCount = 0f;
//                enemiesSpawned++;
//            }
//
//            timeCount += Time.deltaTime;
//        }
//        
//    }

    public void spawnEnemy(int enemyType)
    {
        if (enemyType == 1)
        {
            GameObject enemy = GameObject.Instantiate<GameObject>(EnemyType1);
            enemy.GetComponent<GenericEnemy>().levelManager = levelManager;
            enemy.transform.position = this.gameObject.transform.position;
            
        }

        if (enemyType == 2)
        {
            GameObject enemy = GameObject.Instantiate<GameObject>(EnemyType2);
            enemy.GetComponent<GenericEnemy>().levelManager = levelManager;
            enemy.transform.position = this.gameObject.transform.position;

        }

        if (enemyType == 3)
        {
            GameObject enemy = GameObject.Instantiate<GameObject>(EnemyType3);
            enemy.GetComponent<GenericEnemy>().levelManager = levelManager;
            enemy.transform.position = this.gameObject.transform.position;

        }

        if (enemyType == 4)
        {
            GameObject enemy = GameObject.Instantiate<GameObject>(EnemyType4);
            enemy.GetComponent<GenericEnemy>().levelManager = levelManager;
            enemy.transform.position = this.gameObject.transform.position;

        }

        if (enemyType == 5)
        {
            GameObject enemy = GameObject.Instantiate<GameObject>(EnemyType5);
            enemy.GetComponent<GenericEnemy>().levelManager = levelManager;
            enemy.transform.position = this.gameObject.transform.position;

        }

 
    }
}
