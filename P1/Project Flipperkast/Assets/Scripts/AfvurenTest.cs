using UnityEngine;
using System.Collections;

public class AfvurenTest : MonoBehaviour
{
    public Rigidbody bal;
    public Vector3 direction;

	void Start ()
    {
	
	}
	
	void Update ()
    {

    }

    public void OnTriggerStay(Collider collider)
    {
        if (Input.GetButton("Jump"))
        {
            bal.AddForce(direction);
        }
    }
}