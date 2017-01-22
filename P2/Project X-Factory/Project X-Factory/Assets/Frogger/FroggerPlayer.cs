using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerPlayer : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public GameObject player;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown("w"))
        {
            player.transform.Translate(0.0f, 0.0f, 1.0f);
        }
        if (Input.GetKeyDown("a"))
        {
            player.transform.Translate(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown("s"))
        {
            player.transform.Translate(0.0f, 0.0f, -1.0f);
        }
        if (Input.GetKeyDown("d"))
        {
            player.transform.Translate(1.0f, 0.0f, 0.0f);
        }
    }
}
