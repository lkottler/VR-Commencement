using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class UserDiplomaText : MonoBehaviour
{
    public Text userName;
    public Text userMajor;
    void Start()
    {
        userName.text = UserStats.getUsername();
    }
}
