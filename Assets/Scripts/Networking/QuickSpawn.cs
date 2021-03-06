﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSpawn : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Button guestLoginButton, userLoginButton, regButton;

    [SerializeField]
    InputField serverName;
    
    [SerializeField]
    Text connectingText;

    //[SerializeField]
    //private GameObject quitButton;

    [SerializeField]
    private int RoomSize;
    public static QuickSpawn m_Instance = null;
    public static QuickSpawn Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = (QuickSpawn)FindObjectOfType(typeof(QuickSpawn));
            return m_Instance;
        }
    }

    void Awake()
    {
        m_Instance = this;
    }

    private string getSelectedRoom()
    {
        return (serverName.text == "") ? "Commence" : serverName.text;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        guestLoginButton.interactable = true;
        userLoginButton.interactable = true;
        regButton.interactable = true;
        connectingText.text = "Status: Connected";
        connectingText.color = Color.green;//new Color(46, 204, 113, 255);
    }

    public void guestStart()
    {
        guestLoginButton.interactable = true;
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom(getSelectedRoom());
        Debug.Log("Guest Logged in");
    }

    // This function is primarily depricated after now joining the specific room
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join existing room");
        CreateRoom();
    }

    void CreateRoom() //creates a new room for multiplayer
    {
        Debug.Log("Creating a new room");
        //int randomRoomNumber = Random.Range(0, 10000); // random number for room index
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        //PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        PhotonNetwork.CreateRoom(getSelectedRoom(), roomOps);
        Debug.Log("Created room: " + getSelectedRoom());
    }

    // This probably fails if the Random room number selected already exists as a room.
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a new room");
        CreateRoom(); // Try to create a new room again
    }

    public void QuickQuit()
    {
        //quitButton.SetActive(false);
        //guestLoginButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
