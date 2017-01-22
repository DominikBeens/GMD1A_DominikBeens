using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{

    public List<bool> b = new List<bool>();

	void Start ()
    {
        for (int i = 0; i < b.Count; i++)
        {
            if (b[i] == true)
            {
                print("ik ben true");
            }
        }
    }
	
	void Update ()
    {
        
	}
}
