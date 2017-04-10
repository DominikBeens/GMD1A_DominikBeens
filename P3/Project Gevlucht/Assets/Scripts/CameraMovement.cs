using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Camera cam;
    public float moveSpeed = 3f;
    public float turnSpeed = 3f;

    public GameObject waypointLeft;
    public GameObject waypointMid;
    public GameObject waypointRight;

    public Transform player;

    void Update ()
    {
        if (player.transform.localPosition.z <= -1.7f)  //Left
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, waypointLeft.transform.position, (moveSpeed * Time.deltaTime));
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, waypointLeft.transform.rotation, (turnSpeed * Time.deltaTime));
        }

        if (player.transform.localPosition.z >= 4.0f)   //Right
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, waypointRight.transform.position, (moveSpeed * Time.deltaTime));
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, waypointRight.transform.rotation, (turnSpeed * Time.deltaTime));
        }

        if (player.transform.localPosition.z >= -1.7f && player.transform.localPosition.z <= 4.0f)  //Mid
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, waypointMid.transform.position, (moveSpeed * Time.deltaTime));
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, waypointMid.transform.rotation, (turnSpeed * Time.deltaTime));
        }
    }
}