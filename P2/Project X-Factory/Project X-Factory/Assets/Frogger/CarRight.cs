using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRight : MonoBehaviour
{

    public float carSpeed = 5f;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -carSpeed);
    }
}
