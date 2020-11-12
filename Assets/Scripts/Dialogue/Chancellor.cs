using UnityEngine;

/// <summary>
/// Allows the player to control a character from the Synty Studios "Simple People" asset pack.
/// </summary>
public class ChancellorController : MonoBehaviour
{
    // Member variables.
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
}