using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject cube;
    public GameObject spawn;

    void Start ()
    {
        
    }

    void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //GameObject spawn = (GameObject)Instantiate(cube, transform.position, transform.rotation);
            Vector3 spawnPos = spawn.transform.position;
            Instantiate(cube, spawnPos, Quaternion.identity);
        }
	}
}
