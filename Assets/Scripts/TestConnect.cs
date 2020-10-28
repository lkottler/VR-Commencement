using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    private void Start() 
    {
        print("Connecting to server.");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.connectToBestCloudServer();
    }
    
    public override void OnConnectedToMaster() 
    {
        print("Connected to server.");
    }

    public override void OnDisconnected(DisconnectCause cause) 
    {
        print("Disconnected from server for reason" + cause.ToString());
    }

 
}

