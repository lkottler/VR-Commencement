using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyTrigger : MonoBehaviour
{

    public KeyCode _key;
    public  Button _button;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(_key) && !PhotonChatManager.typing) 
        {
            _button.onClick.Invoke();
            Debug.Log("key pressed.");
        }
    }

}
