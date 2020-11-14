using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiplomaImage : MonoBehaviour
{
    public Image image;
    public Text userName;
    public Text userMajor;
    public Text instruction;
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        userName.enabled = false;
        userMajor.enabled = false;
        instruction.enabled = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
      
            Debug.Log("key G pressed.");
            image.enabled = !image.enabled;
            userName.enabled = image.enabled;
            userMajor.enabled = image.enabled;
            instruction.enabled = image.enabled;
        }
    }
}
