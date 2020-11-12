using Photon.Pun;
using UnityEngine;

/// <summary>
/// Allows the player to control a character from the Synty Studios "Simple People" asset pack.
/// </summary>
public class SimplePeoplePlayer : MonoBehaviour
{
    // Member variables.
    public PhotonView photonView;
    private Animator animator;
    private bool isMoving = false;

    /// <summary>
    /// Performs initialisation of this component.
    /// </summary>
    public void Start()
    {
        this.animator = this.GetComponent<Animator>();
        if (this.animator != null)
        {
            // Set the character animation to idle and enable non-static animations.
            this.animator.SetFloat("Speed_f", 0.0f);
            //this.animator.SetBool("Static_b", false);
        }
    }

    /// <summary>
    /// Updates this component on each frame.
    /// </summary>
    public void Update()
    {
        // Process the movement input.
        if (photonView.IsMine)
            this.ProcessMovementInput();
    }

    /// <summary>
    /// Processes movement input issued by the player (e.g. directional arrow keys, gamepad directional stick .etc.).
    /// </summary>
    private void ProcessMovementInput()
    {
        if (photonView)
        if (this.animator != null)
        {
            // Get the movement input (if any) from the horizontal and vertical axes.
            float weAxis = Input.GetAxis("Horizontal");
            float nsAxis = Input.GetAxis("Vertical");

            // Process the movement input.
            if ((Mathf.Abs(weAxis) > 0.0f) || (Mathf.Abs(nsAxis) > 0.0f))
            {
                // If the character is currently idle...
                if (!this.isMoving)
                {
                    // Transition to the walking state.
                    this.isMoving = true;
                    this.animator.SetFloat("Speed_f", 0.4f);
                }
                
                /*if (weAxis < 0.0f)
                {
                    // If the character should be walking west, rotate them to face west.
                    this.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                }
                else if (weAxis > 0.0f)
                {
                    // If the character should be walking east, rotate them to face east.
                    this.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                }
                else if (nsAxis < 0.0f)
                {
                    // If the character should be walking south, rotate them to face south.
                    this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
                else if (nsAxis > 0.0f)
                {
                    // If the character should be walking north, rotate them to face north.
                    this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }*/
            }
            else if (this.isMoving)
            {
                // If there is no movement input and the character is currently moving, transition to the idle state.
                this.isMoving = false;
                this.animator.SetFloat("Speed_f", 0.0f);
            }
        }
    }
}