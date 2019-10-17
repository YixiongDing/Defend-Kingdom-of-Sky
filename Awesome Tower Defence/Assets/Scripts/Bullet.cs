using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damageAmount;
    public string tagToDamage;

    public void trace(Transform tar)
    {
        target = tar;
    }

    // Update is called once per frame
    void Update()
    {
//        if (target == null)
//        {
//            Destroy(gameObject);
//            return;
//        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

//        if (dir.magnitude <= distance)
//        {
//            Hit();
//            return;
//        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

    void Hit()
    {
        Destroy(gameObject);
    }
    
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


