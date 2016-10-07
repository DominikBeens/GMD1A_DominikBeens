using UnityEngine;
using System.Collections;

public class Nexus : MonoBehaviour
{

    public int maxHealth = 100;
    public int curHealth = 100;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (curHealth == 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision pinball)
    {
        if (pinball.gameObject.tag == "Pinball")
        {
            curHealth -= 25;
            //Destroy(pinball.gameObject);
        }
    }
}
