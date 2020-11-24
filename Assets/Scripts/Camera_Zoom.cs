using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom: MonoBehaviour
{
    public GameObject player;              // Associated player gameObject.
    private float zoomSpeed;                // Rate of Zoom-translation.

    private Vector3 minZoomPosition;        // Minimum ZoomIn position, (current player position).
    private Vector3 maxZoomPosition;        // Vector difference between initial cameraPosition and current playerPosition.

    private float xIntDistance;             // Initial vector component distances determined by the initial camera offset
    private float yIntDistance;             // and player position. (Helps initialize maxZoomOutPosition)
    private float zIntDistance;

    private float xZoomDistance;            // Determines current distance between camera and player after zooming each frame.
    private float yZoomDistance;            // (Helps update the current camera transform based on this distance and the current
    private float zZoomDistance;            // position of the player);

    public float height = 1.0f;
    public int ZoomFactor = 20;

    // Start is called before the first frame update.
    void Start()
    {
        // Initialize camera zoom speed.
        zoomSpeed = 5.0f;
        // Uppder bound of camera zoom range.
        maxZoomPosition = transform.position - player.transform.position;
        // Initialize values of camera offset distance.
        xIntDistance = transform.position.x - player.transform.position.x;
        yIntDistance = transform.position.y - player.transform.position.y;
        zIntDistance = transform.position.z - player.transform.position.z;
        // Initialize distance of camera from player position.
        xZoomDistance = xIntDistance;
        yZoomDistance = yIntDistance;
        zZoomDistance = zIntDistance;

        // Initialize minimum zoomIn position.
        minZoomPosition = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z+height);
        // Initialize maximum zoomOut position.
        maxZoomPosition = new Vector3(minZoomPosition.x + xIntDistance, minZoomPosition.y + yIntDistance, minZoomPosition.z + zIntDistance);
        // Initialize current camera position.
        transform.position = new Vector3(minZoomPosition.x + xZoomDistance, minZoomPosition.y + yZoomDistance, minZoomPosition.z + zZoomDistance);
    }

    // Gets player input each frame.
    private void Update()
    {
        zoomAnimator(); // Animate camera zooming in the specified direction;
    }

    // Updates the camera and player position at the end of the frame.
    private void LateUpdate()
    {
        updateCameraPositionProperties(); // Update the vector the camera zooms across
    }

    /* UPDATE CAMERA POSITION PROPERTIES:
     * Updates the vector in which the camera zooms across. It consists of the minimum zoomIn position (current player position,
     * plus a specifed offset of 0.5f above the player position), the maxZoomOutPosition (cameraOffset), and the current 
     * transform of the camera. 
     */
    void updateCameraPositionProperties ()
    {
        // Update minimum zoomIn position.
        minZoomPosition = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z);
        // Update maximum zoomOut position.
        maxZoomPosition = new Vector3(minZoomPosition.x + xIntDistance, minZoomPosition.y + yIntDistance, minZoomPosition.z + zIntDistance);
        // Update current camera position.
        transform.position = new Vector3(minZoomPosition.x + xZoomDistance, minZoomPosition.y + yZoomDistance, minZoomPosition.z + zZoomDistance);
    }

    /* ZOOM CONTROLLER:
     * During Update, this method checks for "Mouse ScrollWheel" input and zooms the camera in the direction
     * of the players position. Mouse ScrollWheel Down zooms inward just above the player position, Mouse ScrollWheel
     * Up zooms outward towards the current cameraOffset.
     */
    bool isZoomingIn = false;  // Checks for mouse wheel down.
    bool isZoomingOut = false; // Checks for mouse wheel up.
    void zoomAnimator()
    {
        checkScrollWheelInput(); 
        if (isZoomingIn)
        {
            zoomCameraIn(); // Translate camera zooming in (one-step);
        }
        if (isZoomingOut)
        { 
            zoomCameraOut(); // Translate camera zooming out (one-step);
        }
    }

    /* CHECK SCROLLWHEEL INPUT:
     * Gets input from the scrollwheel and updates whether the camera is currently zooming in or zooming out.
     * Each time input is recieved from the scrollwheel the bounds of the current zoom step (the range the
     * camera must translate) are moved in the direction of the scroll wheel input.
     */
    public static float stepDistance = 0.2f;                                                                            // Distance to interpolate for each recognized frame of input.
    private static float upperStepBound = Mathf.Clamp(1.0f, minCameraDistance + stepDistance, 1.0f);                    // Initial maximum interpolation value for current zoom step.
    private static float lowerStepBound = Mathf.Clamp(1.0f - stepDistance, minCameraDistance, 1.0f - stepDistance);     // Initial minimum interpolation value for current zoom step.
    private static float minCameraDistance = 0.1f;                                                                      // Minimum distance the camera can be away from the player (fraction of interpolation).
    void checkScrollWheelInput()
    {
        // SCROLLWHEEL DOWN SWITCH (ZOOMING IN):
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            isZoomingIn = true;
            isZoomingOut = false;
            // Check if the camera has moved to the lower bound of the Zoom step.
            if (currentInterpolation == lowerStepBound)
            {
                // Decrease the current interpolation by the stepDistance.
                // Clamps the value of the lowerStepBound between the minimumCameraDistance and maximum lowerStepBound.
                lowerStepBound = Mathf.Clamp(lowerStepBound - stepDistance, minCameraDistance, 1.0f - stepDistance);
                upperStepBound = Mathf.Clamp(upperStepBound - stepDistance, minCameraDistance + stepDistance, 1.0f);

            }
        }
        // SCROLLWHEEL UP SWITCH (ZOOMING OUT):
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            isZoomingOut = true;
            isZoomingIn = false;
            // Checks if the camera has moved to the upper bound of the Zoom step.
            if (currentInterpolation == upperStepBound)
            {
                // Increase the current interpolation by the stepDistance.
                // Clamps value between the minimum uperStepBound of zoom step and the maxium interpolation from the camera.
                upperStepBound = Mathf.Clamp(upperStepBound + stepDistance, minCameraDistance + stepDistance, 1.0f);
                lowerStepBound = Mathf.Clamp(lowerStepBound + stepDistance, minCameraDistance, 1.0f - stepDistance);
            }
        }
    }

    /* ZOOM CAMERA IN:
     * Translates the camera in the direction of the players position. Based on the functionality of Mathf.Lerp
     * the cameras position is held within a range between the current players position and a position based on
     * the initial distance of the camera.
     */
    private Vector3 newCameraPosition;                  // New position of camera after zooming.
    private static float currentInterpolation = 1.0f;   // Interpolation value between the Camera (1.0f) and Player (0.0f) position.
    void zoomCameraIn()
    {
        // Updates Zoom Interpolation Range and Current Interpolation.
        newCameraPosition = new Vector3(Mathf.Lerp(minZoomPosition.x, maxZoomPosition.x, currentInterpolation), Mathf.Lerp(minZoomPosition.y, maxZoomPosition.y, currentInterpolation), Mathf.Lerp(minZoomPosition.z, maxZoomPosition.z, currentInterpolation));

        currentInterpolation = Mathf.Clamp((currentInterpolation - (Time.deltaTime * zoomSpeed)), lowerStepBound, upperStepBound);
        

        xZoomDistance = newCameraPosition.x - minZoomPosition.x;
        yZoomDistance = newCameraPosition.y - minZoomPosition.y;
        zZoomDistance = newCameraPosition.z - minZoomPosition.z;

        // Updates Camera Position
        transform.position = newCameraPosition * Time.deltaTime * zoomSpeed;

    }

    /* ZOOM CAMERA OUT:
     * Translates the camera in the direction away from the players position. Based on the functionality of Mathf.Lerp
     * the cameras position is held within a range between the current players position and a position based on
     * the initial distance of the camera's.
     */
    void zoomCameraOut()
    {
        // Updates Zoom Interpolation Range and Current Interpolation.
        newCameraPosition = new Vector3(Mathf.Lerp(minZoomPosition.x, maxZoomPosition.x, currentInterpolation), Mathf.Lerp(minZoomPosition.y, maxZoomPosition.y, currentInterpolation), Mathf.Lerp(minZoomPosition.z, maxZoomPosition.z, currentInterpolation));
        currentInterpolation = Mathf.Clamp((currentInterpolation + (Time.deltaTime * zoomSpeed)), lowerStepBound, upperStepBound);

        xZoomDistance = newCameraPosition.x - minZoomPosition.x;
        yZoomDistance = newCameraPosition.y - minZoomPosition.y;
        zZoomDistance = newCameraPosition.z - minZoomPosition.z;

        // Updates Camera Position
        transform.position = newCameraPosition * Time.deltaTime * zoomSpeed*ZoomFactor;
    }      
}
