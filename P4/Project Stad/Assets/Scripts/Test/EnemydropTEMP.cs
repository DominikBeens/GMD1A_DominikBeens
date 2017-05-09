using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemydropTEMP : MonoBehaviour {
    public List<GameObject> drops = new List<GameObject>();
    public float dropChance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        if (Random.value > dropChance)
        {
            int i = Random.Range(0, drops.Count);
            Instantiate(drops[i], transform.position, Quaternion.identity);
        }
       
    }
}
