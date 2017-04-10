using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInside : MonoBehaviour
{

    public UIManager uim;

    public Light lampLight;

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            uim.triggerPanelText.text = "Press E to use the lamp";
            uim.triggerPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) &&  lampLight.enabled == false)
        {
            lampLight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) &&  lampLight.enabled == true)
        {
            lampLight.enabled = false;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        uim.triggerPanel.SetActive(false);
    }
}
