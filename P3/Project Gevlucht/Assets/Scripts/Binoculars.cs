using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binoculars : MonoBehaviour //NOT USING THIS SCRIPT RIGHT NOW
{

    public UIManager uim;
    public CharacterMovement charMove;

    public GameObject mainCam;
    public GameObject binocularCam;

    //public bool usingBinoculars;
    //public float mouseSensitivity = 5.0f;
    //float verticalRotation = 0;

    //void Update()
    //{
    //    Vector3 rotLeftRight = new Vector3(Input.GetAxis("Mouse Y") * mouseSensitivity, Input.GetAxis("Mouse X") * mouseSensitivity);
    //    binocularCam.transform.localRotation = Quaternion.Euler(rotLeftRight);
    //}

    public void OnTriggerStay(Collider col)
    {
        uim.triggerPanelText.text = "Press E to use or stop using binoculars";
        uim.triggerPanel.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E) && binocularCam.activeInHierarchy == false)
        {
            StartCoroutine(StartBinoculars());
        }
        else if (Input.GetKeyDown(KeyCode.E) && binocularCam.activeInHierarchy == true)
        {
            StartCoroutine(StopBinoculars());
        }
    }

    public void OnTriggerExit(Collider col)
    {
        uim.triggerPanel.SetActive(false);
    }

    public IEnumerator StartBinoculars()
    {
        uim.fadeOverlay.canvasRenderer.SetAlpha(0.01f);
        uim.fadeOverlay.CrossFadeAlpha(1f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);

        mainCam.SetActive(false);
        uim.binocularsOverlay.SetActive(true);
        binocularCam.SetActive(true);
        //usingBinoculars = true;

        uim.fadeOverlay.CrossFadeAlpha(0f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator StopBinoculars()
    {
        uim.fadeOverlay.canvasRenderer.SetAlpha(0.01f);
        uim.fadeOverlay.CrossFadeAlpha(1f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);

        mainCam.SetActive(true);
        uim.binocularsOverlay.SetActive(false);
        binocularCam.SetActive(false);
        //usingBinoculars = false;

        uim.fadeOverlay.CrossFadeAlpha(0f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);
    }
}
