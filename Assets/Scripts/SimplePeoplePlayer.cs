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
    private bool isJumping = false;
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
        float timer = 0.03f;
        if (!photonView.IsMine)
        {
            timer = 0.1f;
        }
        Vector3 pos1;
        Vector3 pos2;
        pos1 = trans.position;
        yield return new WaitForSeconds(timer);
        pos2 = trans.position;
        Vector3 dist = (pos2 - pos1);
        if (dist.y > 0.3)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        dist.y = 0;

        speed = dist.sqrMagnitude * 3.0f * (timer * 33);
        //Debug.Log(speed);

        checkMoving();
    }

    private void ProcessMovementInput()
    {
        //if (photonView)
        if (animator != null)
        {

            animator.SetBool("Jump_b", isJumping);
            animator.SetFloat("Speed_f", speed);
            

        }
    }
}