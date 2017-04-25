using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInsideCol : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject insideCam;

    public GameObject audioGO;

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mainCam.SetActive(false);
            insideCam.SetActive(true);

            audioGO.GetComponent<AudioLowPassFilter>().enabled = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            insideCam.SetActive(false);
            mainCam.SetActive(true);

            audioGO.GetComponent<AudioLowPassFilter>().enabled = false;
        }
    }
}
