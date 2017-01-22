using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

    public static TestManager testManager;

	void Start ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }	
}
