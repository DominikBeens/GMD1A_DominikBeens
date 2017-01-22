using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public UI_Manager uim; 

    public AudioSource radioAudio;

    void Start()
    {
        uim.radioPanel.SetActive(false);
        radioAudio.Pause();
    }

    void Update()
    {

    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            uim.radioPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && radioAudio.isPlaying == false)
        {
            radioAudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E) && radioAudio.isPlaying == true)
        {
            radioAudio.Pause();
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        uim.radioPanel.SetActive(false);
    }

}
