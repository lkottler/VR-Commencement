using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAndTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;   
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.name);
        dialogueTrigger.TriggerDialogue();
      
    }
}
