using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public float timeActive;

    private float timePassed;
    // Update is called once per frame
    void Update()
    {
        if (timePassed + Time.deltaTime > timeActive)
        {
            Destroy(this.gameObject);
        }

        timePassed += Time.deltaTime;

    }
}
