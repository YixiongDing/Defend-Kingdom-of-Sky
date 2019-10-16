using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    public GameObject destroyExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    // This should be hooked up to the health manager on this object
    public void DestroyMe()
    {
        // Create explosion effect
        GameObject explosion = Instantiate(this.destroyExplosionPrefab);
        explosion.transform.position = this.transform.position;

        // Destroy self
        Destroy(this.gameObject);
    }
}
