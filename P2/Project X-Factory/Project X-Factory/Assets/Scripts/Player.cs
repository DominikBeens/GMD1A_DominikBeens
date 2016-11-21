using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour {

    public Camera mainCamera;

    // Zet deze waarden in de inspector op goede getallen
    public float moveSpeed;
    public float turnSpeed;

    void Update() {
        // Beweging met pijltjestoetsen
        Vector3 nextDirection = gameObject.transform.position;
        Vector3 jump = gameObject.transform.position;
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float jumpMovement = Input.GetAxis("Jump");

        nextDirection += mainCamera.transform.right * horizontalMovement * moveSpeed * Time.deltaTime;
        nextDirection += mainCamera.transform.forward * verticalMovement * moveSpeed * Time.deltaTime;
        nextDirection += mainCamera.transform.up * jumpMovement * moveSpeed * Time.deltaTime;

        gameObject.transform.localPosition = nextDirection;

        // Rondkijken met muis
        Vector3 lookDirection = mainCamera.transform.localEulerAngles;
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        lookDirection.x -= verticalRotation * turnSpeed * Time.deltaTime;
        lookDirection.y += horizontalRotation * turnSpeed * Time.deltaTime;

        mainCamera.transform.localEulerAngles = lookDirection;
	}
}
