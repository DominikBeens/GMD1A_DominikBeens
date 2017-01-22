using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{

    public float bulletSpeed = 5f;
    public GameObject bullet;


	void Start ()
    {
	
	}
	
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
}
