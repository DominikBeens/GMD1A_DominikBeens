using UnityEngine;
using System.Collections;

public class Test3 : MonoBehaviour
{

    public Vector3 dir;
    public float speed;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 d = dir * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(d);
        }
	}
}
