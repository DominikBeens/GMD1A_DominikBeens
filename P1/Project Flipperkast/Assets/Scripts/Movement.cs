using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public Text scoreVeld;
    public int score;
    public Vector3 xAs;
    public Vector3 zAs;
    public Vector3 yAs;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += xAs;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= xAs;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += zAs;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= zAs;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += yAs;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= yAs;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        score = score + 10;
        scoreVeld.text = score.ToString();
    }
}
