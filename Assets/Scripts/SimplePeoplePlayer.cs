using Photon.Pun;
using System.Collections;
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
    private float speed = 0f;

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
        checkMoving();
    }

    /// <summary>
    /// Updates this component on each frame.
    /// </summary>
    public void Update()
    {
        ProcessMovementInput();
    }

    /// <summary>
    /// Processes movement input issued by the player (e.g. directional arrow keys, gamepad directional stick .etc.).
    /// </summary>
    private void checkMoving()
    {
        StartCoroutine(IsThisObjectMoving(transform));
    }
    IEnumerator IsThisObjectMoving(Transform trans) {
        Vector3 pos1;
        Vector3 pos2;
        pos1 = trans.position;
        yield return new WaitForSeconds(0.05f);
        pos2 = trans.position;
        Debug.Log((pos1 - pos2).sqrMagnitude);
        speed = (pos1 - pos2).sqrMagnitude * 1.5f;
        checkMoving();
    }

    private void ProcessMovementInput()
    {
        //if (photonView)
        if (animator != null)
        {
            if (isMoving)
            {
                // Transition to the walking state.
                animator.SetFloat("Speed_f", speed);

            } else
            {
                animator.SetFloat("Speed_f", speed);
            }
        }
    }
}