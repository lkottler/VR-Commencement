using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonlSelectAvatar : MonoBehaviour
{
    public GameObject SelectAvatar;
    public GameObject other1;
    public GameObject other2;
    public GameObject other3;
    public Button btn;
    private Animator SelectAnimator;
    private Animator other1Animator;
    private Animator other2Animator;
    private Animator other3Animator;
    private float speed;
    // Update is called once per frame
    void Start() 
    {
        speed = 0.0f;
        SelectAnimator = SelectAvatar.GetComponent<Animator>();
        other1Animator = other1.GetComponent<Animator>();
        other2Animator = other2.GetComponent<Animator>();
        other3Animator = other3.GetComponent<Animator>();
        btn.onClick.AddListener(Click);
    }
    void Click()
    {
        Debug.Log("You have clicked the button!");
        if (SelectAnimator != null) {
            Debug.Log("You have enter the SelectAnimator!");
            if (speed == 0.0) 
            {
                speed = 0.5f;
            }
            else
            {
                speed = 0.0f;
            }

            SelectAnimator.SetFloat("Speed_f", speed);
            if (other1Animator != null) 
            {
                other1Animator.SetFloat("Speed_f", 0.0f);
            }
            if (other2Animator != null)
            {
                other2Animator.SetFloat("Speed_f", 0.0f);
            }
            if (other3Animator != null)
            {
                other3Animator.SetFloat("Speed_f", 0.0f);
            }
        }
    }
}
