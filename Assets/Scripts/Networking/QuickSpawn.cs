using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSpawn : MonoBehaviourPunCallbacks
{
    string username = "Guest";
    [SerializeField]
    private Button guestLoginButton;

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

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        guestLoginButton.interactable = true;
    }

    public void guestStart()
    {
        guestLoginButton.interactable = true;
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom("Commencement");
        Debug.Log("Guest Logged in");
    }

    // Primarily Depricated code.
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join existing room");
        CreateRoom();
    }

    // This is for commencement
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join specific room");
        CreateRoom();
    }

    void CreateRoom() //creates a new room for multiplayer
    {
        Debug.Log("Creating a new room");
        //int randomRoomNumber = Random.Range(0, 10000); // random number for room index
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        //PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        PhotonNetwork.CreateRoom("Commencement", roomOps);
        Debug.Log("Created room: 'Commencement'");
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
