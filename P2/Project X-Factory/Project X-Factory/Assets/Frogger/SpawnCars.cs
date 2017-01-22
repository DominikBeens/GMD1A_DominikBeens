using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{

    public GameObject[] spawnpoints;
    public GameObject carLeft;
    public GameObject carRight;

	void Start ()
    {
        Spawn();
    }

    void Update ()
    {
	    
	}

    public void Spawn()
    {
        GameObject car1 = (GameObject)Instantiate(carLeft, spawnpoints[0].transform.position, spawnpoints[0].transform.rotation);
        GameObject car2 = (GameObject)Instantiate(carLeft, spawnpoints[1].transform.position, spawnpoints[0].transform.rotation);
        GameObject car3 = (GameObject)Instantiate(carLeft, spawnpoints[2].transform.position, spawnpoints[0].transform.rotation);
        GameObject car4 = (GameObject)Instantiate(carRight, spawnpoints[3].transform.position, spawnpoints[0].transform.rotation);
        GameObject car5 = (GameObject)Instantiate(carRight, spawnpoints[4].transform.position, spawnpoints[0].transform.rotation);
        GameObject car6 = (GameObject)Instantiate(carRight, spawnpoints[5].transform.position, spawnpoints[0].transform.rotation);
    }
}
