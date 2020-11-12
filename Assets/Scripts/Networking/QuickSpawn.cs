using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSpawn : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button guestLoginButton;

    //[SerializeField]
    //private GameObject quitButton;

    [SerializeField]
    private int RoomSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        guestLoginButton.interactable = true;
    }

    public void guestStart()
    {
        guestLoginButton.interactable = true;
        //quitButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Guest Logged in");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join existing room");
        CreateRoom();
    }

    void CreateRoom() //creates a new room for multiplayer
    {
        Debug.Log("Creating a new room");
        int randomRoomNumber = Random.Range(0, 10000); // random number for room index
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
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
