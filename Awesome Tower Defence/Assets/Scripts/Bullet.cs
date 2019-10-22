using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 target;
    public float speed = 70f;
    public int damageAmount;
    public string tagToDamage;
    public float lifeTime;
    private float timeCounter = 0;
    public Rigidbody rb;
    private Vector3 direction;

    public void trace(Transform tar)
    {
        target = tar.position;
        
    }

    void Start() {
        direction = target - transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
     void Update()
     {

     //    if (target == null)
     //    {
     //        Destroy(gameObject);
     //        return;
     //    }
         timeCounter += Time.deltaTime;
         if(timeCounter >= lifeTime) {
             Destroy(gameObject);
         }
         //Vector3 dir = target - transform.position;
         //float distance = speed * Time.deltaTime;

 //        if (dir.magnitude <= distance)
 //        {
 //            Hit();
 //            return;
 //        }

//         transform.Translate(direction.normalized * distance, Space.World);
     }

// void FixedUpdate() {

// }
    // void Hit()
    // {
    //     Destroy(gameObject);
    // }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);

            // Destroy self
            Destroy(this.gameObject);
        }
    }
}


