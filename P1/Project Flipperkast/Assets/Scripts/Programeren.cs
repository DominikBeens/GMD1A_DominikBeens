using UnityEngine;
using System.Collections;

public class Programeren : MonoBehaviour {

	int getal = 0;


	// Use this for initialization
	void Start () {
		print(getal);
	}
	
	// Update is called once per frame
	void Update () {
		getal = getal + 1;
		print(getal);
	}
}
