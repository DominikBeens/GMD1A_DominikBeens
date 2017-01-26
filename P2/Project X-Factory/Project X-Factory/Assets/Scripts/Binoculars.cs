using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binoculars : MonoBehaviour
{

    public Animator animator;

    public bool usingBinoculars = false;

    public GameObject overlay;
    public GameObject binoculars;
    public Camera cam;

    public float zoomInFOV = 15f;
    public float zoomOutFOV;
    public float zoomOutMouseSens;

    public PlayerController playerController;

    void Start ()
    {
        zoomOutFOV = cam.fieldOfView;
        zoomOutMouseSens = playerController.mouseSensitivity;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            usingBinoculars = !usingBinoculars;
            animator.SetBool("Binoculars", usingBinoculars);

            if (usingBinoculars)
            {
                StartCoroutine(ZoomIn());
            }
            else
            {
                ZoomOut();
            }
        }
	}

    IEnumerator ZoomIn()
    {
        yield return new WaitForSeconds(0.9f);
        binoculars.SetActive(false);
        overlay.SetActive(true);

        playerController.mouseSensitivity = 1f;
        cam.fieldOfView = zoomInFOV;
    }

    public void ZoomOut()
    {
        overlay.SetActive(false);
        binoculars.SetActive(true);

        playerController.mouseSensitivity = zoomOutMouseSens;
        cam.fieldOfView = zoomOutFOV;
    }
}
