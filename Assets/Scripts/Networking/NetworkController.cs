﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    /*
     * Documentation: https://doc.photonengine.com/en-us/pun/current/getting-started/pun-intro
     * Scripting API: https://doc-api.photonengine.com/en/pun/v2/index.html
     * 
     * Refer to these documents for assistance with Photon
     */

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Photon servers
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PHOTON Connected to: " + PhotonNetwork.CloudRegion + " server.");
        //base.OnConnectedToMaster();)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}