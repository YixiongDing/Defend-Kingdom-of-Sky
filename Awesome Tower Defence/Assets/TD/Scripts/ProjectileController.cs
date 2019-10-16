using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

    public Vector3 velocity;

    public int damageAmount = 50;
    public string tagToDamage;

    public float lifeTime;

    private float timeCounter = 0f;
    // Update is called once per frame
    void Update () {
        this.transform.Translate(velocity * Time.deltaTime);

        if (timeCounter + Time.deltaTime > lifeTime)
        {
            Destroy(this.gameObject);
        }

        timeCounter += Time.deltaTime;
    }

    // Handle collisions
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