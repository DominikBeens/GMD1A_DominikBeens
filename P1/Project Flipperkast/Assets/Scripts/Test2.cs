using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {

    public int test;
    public float test2;
    public bool test3;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    { 
        PlusEen();
        KeerFloat();
	}

    public void PlusEen ()
    {
        if (test3 == true) //shortcut: if (test3)
        {
            test = test + 1;
        }
    }

    public void KeerFloat()
    {
        test2 = test * 0.123f;
    }
}
