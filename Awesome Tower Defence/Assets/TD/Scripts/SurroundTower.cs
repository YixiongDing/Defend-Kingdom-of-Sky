using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundTower : BasicTower
{
    public int gunCount;


    // Update is called once per frame
    void Update()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, range, 1<<8);
        // int i = 0;
        // Debug.Log("CheckHits");
        // while (i < hitColliders.Length)
        // {
        //     Debug.Log(hitColliders[i].gameObject.name);
        //     i++;
        // }
        // if (target == null)
        // {
        //     if (hitColliders.Length > 0)
        //     {
        //         target = hitColliders[0].gameObject;
        //     }
        // }
        //else
        //{
        
        if(hitColliders.Length != 0) {
            if (timeCounter + Time.deltaTime > fireRate) 
            {
                for(int i=0; i<gunCount; i++) {
                    ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
                    p.transform.position = this.gameObject.transform.position;
                    var rotation = Quaternion.AngleAxis(i*(360/gunCount), Vector3.up);
                    var forward = Vector3.forward;
                    var right = rotation * forward;
                    p.velocity = right * projectileSpeed;
                    p.lifeTime = 10;
                }
                
                // p.transform.position = firePosition.position;
                // p.transform.rotation = firePosition.rotation;
                
                //target.GetComponent<HealthManager>().ApplyDamage(100);
                timeCounter = 0f;
                target = null;
            }
            timeCounter += Time.deltaTime;
        }
            
        //}
    }
}
