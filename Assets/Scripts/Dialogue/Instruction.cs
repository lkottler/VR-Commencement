using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public KeyCode _key;
    public Button _button;
    //public DialogueTrigger dialogueTrigger;
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _button.onClick.Invoke();
            Debug.Log("key pressed.");

        }

    }
}


