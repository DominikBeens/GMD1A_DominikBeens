using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float parallaxSpeed;
    private float lastCameraX;

    public Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        float deltaX = cam.transform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * parallaxSpeed);
        lastCameraX = cam.transform.position.x;
    }
}
