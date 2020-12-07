
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSpawnMock
{
    //Button guestLoginButton, userLoginButton, regButton;
    //Text connectingText;
    public int RoomSize = 100;
    

    public void OnConnectedToMaster()
    {
        //PhotonNetwork.AutomaticallySyncScene = true;
        //guestLoginButton.interactable = true;
        //userLoginButton.interactable = true;
       // regButton.interactable = true;
        //connectingText.text = "Status: Connected";
        //connectingText.color = Color.green;
        Debug.Log("Guest Logged in");
    }

    public void guestStart()
    {
        //guestLoginButton.interactable = true;
        //PhotonNetwork.JoinRandomRoom();
        //PhotonNetwork.JoinRoom("Commencement");
        Debug.Log("Guest Logged in");
    }

    // This function is primarily depricated after now joining the specific room
    public void OnJoinRoomFailed(string message)
    {
        Debug.Log("Failed to join existing room");
        CreateRoom();
    }

    void CreateRoom() //creates a new room for multiplayer
    {
        Debug.Log("Creating a new room");
        RoomSize = Random.Range(0, 100); // random number for room index
        //RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        //PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        //PhotonNetwork.CreateRoom("Commencement", roomOps);
        Debug.Log("Created room: Commencement");
    }

    // This probably fails if the Random room number selected already exists as a room.
    public void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a new room");
        CreateRoom(); // Try to create a new room again
    }

    public void QuickQuit()
    {
        //quitButton.SetActive(false);
        //guestLoginButton.SetActive(true);
        //PhotonNetwork.LeaveRoom();
        Debug.Log("Quit: Commencement");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
