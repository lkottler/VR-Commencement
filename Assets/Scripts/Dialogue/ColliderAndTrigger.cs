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
        //Collider gameobject PLAYER(CLONE)
        Debug.Log(other.name + ", " + UserStats.getUsername());
        GameObject otherObject = other.gameObject;

        //what it suppose to be
        Debug.Log("userName: " + UserStats.getUsername());


        //Transform CollideName = otherObject.transform.Find("Username");//Get the UserName Transform
        //TODO
        Text otherNameObject = otherObject.GetComponent<Text>();
        Debug.Log("NameObject: " + otherNameObject);


        string childerenname = otherObject.GetComponentInChildren<TextMesh>().text;
        Debug.Log("childeren: " + childerenname);
       


        //string NameText = otherObject.GetComponent<UnityEngine.UI.Text>().text;
        //Debug.Log("NameText: " + NameText);
        //Debug.Log("CollideName: " + CollideName);
        //Debug.Log("Text: " + CollideName.toString);
        //Debug.Log("TextMesh: " + CollideName.textMesh);

        // Text oldText = GameObject.Find("Username").GetComponent<Text>();
        //Debug.Log("Text:" + oldText);
        //Debug.Log("Text:" + oldText.text);


        if (childerenname == UserStats.getUsername().ToString()) 
        {
        dialogueTrigger.TriggerDialogue();
        DiplomaInstruction.enabled = true;
        }      
    }
}
