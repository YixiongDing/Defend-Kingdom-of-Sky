using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyType1;
    public GameObject EnemyType2;

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
    }
}
