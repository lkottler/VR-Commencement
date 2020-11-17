using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderAndTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public Text DiplomaInstruction;
    void Start() 
    {
        DiplomaInstruction.enabled = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.name);
        dialogueTrigger.TriggerDialogue();
        DiplomaInstruction.enabled = true;

      
    }
}
