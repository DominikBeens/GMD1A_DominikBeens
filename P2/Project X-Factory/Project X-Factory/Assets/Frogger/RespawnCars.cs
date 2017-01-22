using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCars : MonoBehaviour
{

    public SpawnCars script;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(collider.transform.gameObject);
            script.Spawn();
        }
    }
}