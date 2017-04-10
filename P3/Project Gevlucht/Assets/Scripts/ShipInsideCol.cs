using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInsideCol : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject insideCam;

    public GameObject player;

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mainCam.SetActive(false);
            insideCam.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            insideCam.SetActive(false);
            mainCam.SetActive(true);
        }
    }
}
