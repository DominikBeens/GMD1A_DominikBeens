using UnityEngine;
using System.Collections;

public class TestIncrementenMaken : MonoBehaviour
{

    public bool xAs;
    public bool yAs;
    public bool zAs;
    public Vector3 x;
    public Vector3 y;
    public Vector3 z;

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        { 
            if (xAs == true)
            {
                transform.position += x;
            }
            else
            {
                transform.position -= x;
            }
        }
        {
            if (yAs == true)
            {
                transform.position += y;
            }
            else
            {
                transform.position -= y;
            }
        }
        {
            if (zAs == true)
            {
                transform.position += z;
            }
            else
            {
                transform.position -= z;
            }
        }
    }
}
