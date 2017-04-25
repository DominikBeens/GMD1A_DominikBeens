using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShipInsideCol : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject insideCam;

    public AudioSource rainAudioSource;
    public AudioMixerGroup mainGroup;
    public AudioMixerGroup insideGroup;

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            mainCam.SetActive(false);
            insideCam.SetActive(true);

            rainAudioSource.outputAudioMixerGroup = insideGroup;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            insideCam.SetActive(false);
            mainCam.SetActive(true);

            rainAudioSource.outputAudioMixerGroup = mainGroup;
        }
    }
}
