using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public UIManager uim; 

    public AudioSource radioAudio;

    void Start()
    {
        radioAudio.Pause();
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            uim.triggerPanelText.text = "Press E to use the radio";
            uim.triggerPanel.SetActive(true);
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
        uim.triggerPanel.SetActive(false);
    }

}
