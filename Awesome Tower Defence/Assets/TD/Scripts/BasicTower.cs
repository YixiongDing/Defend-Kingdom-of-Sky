using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : MonoBehaviour
{
    public float range;

    public int cost;
    public Transform firePosition;
    List <GameObject> currentCollisions = new List <GameObject> ();

    public ProjectileController projectilePrefab;
    protected float timeCounter = 0;
    public float fireRate;
    public float projectileSpeed;

    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
//        this.gameObject.AddComponent<SphereCollider>();
//        SphereCollider sphere = this.gameObject.GetComponent<SphereCollider>();
//        sphere.radius = range;
//        sphere.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, range, 1<<8);
        int i = 0;
        Debug.Log("CheckHits");
        while (i < hitColliders.Length)
        {
            Debug.Log(hitColliders[i].gameObject.name);
            i++;
        }
        if (target == null)
        {
            if (hitColliders.Length > 0)
            {
                target = hitColliders[0].gameObject;
            }
        }
        else
        {
            this.gameObject.transform.LookAt(target.transform.position);
            if (timeCounter + Time.deltaTime > fireRate) 
            {
                //ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
                //p.transform.position = firePosition.position;
                //p.transform.rotation = firePosition.rotation;
                //p.velocity = (this.target.transform.position - firePosition.position);
                //p.lifeTime = p.velocity.magnitude / range;
                target.GetComponent<HealthManager>().ApplyDamage(100);
                timeCounter = 0f;
                target = null;
            }
            timeCounter += Time.deltaTime;
        }
        
        

    }

//    void OnTriggerEnter (Collider col) {
// 
//        // Add the GameObject collided with to the list.
//        currentCollisions.Add (col.gameObject);
//        Debug.Log("Collision");
// 
//        // Print the entire list to the console.
//        foreach (GameObject gObject in currentCollisions) {
//            print (gObject.name);
//        }
//    }
// 
//    void OnTriggerExit (Collider col) {
// 
//        // Remove the GameObject collided with from the list.
//        currentCollisions.Remove (col.gameObject);
// 
//        // Print the entire list to the console.
//        foreach (GameObject gObject in currentCollisions) {
//            print (gObject.name);
//        }
//    }
}
