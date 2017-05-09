using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createtower : MonoBehaviour {
    public bool animisPlaying;
    public GameObject tower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Create();

    }

    void Create()
    {
        if (Input.GetKeyDown("f"))
        {
            Instantiate(tower, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
