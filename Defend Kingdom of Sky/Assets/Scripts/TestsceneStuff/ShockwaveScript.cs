using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveScript : MonoBehaviour
{

	public float lifeTime;
	//private float timeCounter;
	private float timeKiller;

	public float expansionRate;
	//public Material mat;
	//private static readonly int TimeControl = Shader.PropertyToID("_TimeControl");

	void Start ()
	{
		//timeCounter = 0f;
		timeKiller = 0f;
		//mat.SetFloat(TimeControl, 0f);
	}
	
	
	void Update ()
	{
		//timeCounter += Time.deltaTime;
		timeKiller += Time.deltaTime;
		//mat.SetFloat(TimeControl, timeCounter);
		if (timeKiller >= lifeTime)
		{
			Destroy(gameObject);
		}
		
        transform.localScale += new Vector3(expansionRate, expansionRate, expansionRate);
//        if(transform.localScale.x > 2f)
//        {
//            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
//        }
		
	}
}
    