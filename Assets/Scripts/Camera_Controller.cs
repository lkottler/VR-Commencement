using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform playerTransform;   // player gameObject transform.
    Vector3 thirdPersonOffset;          // vector offset above player gameObject.
    private float mouseX = 0.0f;        // Current X value of mouse input.
    private float mouseY = 0.0f;        // Current Y value of mouse input.
    private float initialCameraAngle;   // Inital angle of the player's camera.

    private void Start()
    {
        thirdPersonOffset = new Vector3(playerTransform.position.x, playerTransform.position.y + 2.0f, playerTransform.position.z);
        transform.LookAt(thirdPersonOffset); // Face Camera towards thirdPersonOffset.

        Cursor.lockState = CursorLockMode.Locked;       // Cursor is centered to the screen and locked in place.
        initialCameraAngle = transform.eulerAngles.x;   // Initial angle between interpolation vector and thirdPersonOffset.
    }
    private void Update()
    {
        mouseInput(); // Update values of mouseX and mouseY.
    }
    private void LateUpdate()
    {
        thirdPersonOffset = new Vector3(playerTransform.position.x, playerTransform.position.y + 2.0f, playerTransform.position.z);
        repositionCamera(); // Reposition camera based on the rotation assosiated with mouseInput.
    }

    void mouseInput()
    {
        mouseX += Input.GetAxis("Mouse X");
        /* GETTING MOUSE Y-AXIS INPUT:
         * The mouse y-axis input is inverted so that moving the mouse upward
         * looks up, and moving the mouse down looks down. The value is then 
         * clamped based on the initial orientation of the camera.
         * 
         * NOTE: Because the inital orientation is based on the camera zoom 
         * interpolation vector, the original local rotation of the camera 
         * is 43.351 on the x-axis.
         */
        mouseY -= Input.GetAxis("Mouse Y");
        /* Clamps the Y-axis input of the mouse in the direction between an angle of (89f) degrees and
         * the plane in which the player character resides. The 89f is used to resolve a bug when
         * viewing from 90 degrees as the cameras interpolation vector would be continuosly reset.
         */
        mouseY = Mathf.Clamp(mouseY, -initialCameraAngle, 89f - initialCameraAngle);  
    }

    void repositionCamera()
    {
        // Updates vector between camera and thirdPersonOffset
        Vector3 offset = transform.position - thirdPersonOffset; 
        // Creates a rotation based on mouse input, rotate on X-Axis (mouseY), rotate on Y-Axis (mouseX);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        // Position of the camera is rotated based on mouse input.
        transform.position = thirdPersonOffset + rotation * offset;
        // Face the camera towards vector offset above the player position.
        transform.LookAt(thirdPersonOffset);   
    }

}
