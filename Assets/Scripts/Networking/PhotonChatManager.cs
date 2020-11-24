﻿using ExitGames.Client.Photon;
using Photon.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    [SerializeField]
    InputField userMessage;

    [SerializeField]
    Text chatLog;

    [SerializeField]
    Button sendButton;

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log("DebugReturn(DebugLevel level, string message) was called: DebugLevel: " + level + ", message: " + message);
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log("OnChatStateChange(ChatState state) was called. state: " + state);
    }

    public void OnConnected()
    {
        Debug.Log("OnConnected() Called");
        CC.Subscribe("public");
    }

    public void OnDisconnected()
    {
        Debug.Log("OnDisconnected() was called");
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        Debug.Log("OnGetMessages() called: channelName: " + channelName + " #senders: " + senders.Length + " messages: " + messages.Length);
        string msgs = "";
        for (int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("{0}\n{1}: {2}", msgs, senders[i], messages[i]);
        }
        chatLog.text += msgs;
    }


    // Unused
    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("OnStatusUpdate(string user, int status, bool gostMessage, object message) was called. " +
            "user: " + user + ", status: " + status + ", gotMessage: " + gotMessage + ", message: " + message);
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("OnSubscribed() called");
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log("OnUnsubscribed() was called");
    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log("OnUserSubscribed() called, channel: " + channel + "  , user: " + user);
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    ChatClient CC;
    string username;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("chat client started");
        username = UserStats.getUsername();
        CC = new ChatClient(this);
        CC.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(username));
    }

    public void PostMessage()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CC.PublishMessage("public", userMessage.text);
        userMessage.text = "";
    }

    public void ActivateInput()
    {
        Cursor.lockState = CursorLockMode.None;
        //UserStats.setBusy(true);
        userMessage.Select();
        userMessage.ActivateInputField();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (userMessage.text.Length > 0)
            {
                Debug.Log("user has a message: " + userMessage.text);
                PostMessage();
            } else
            {
                ActivateInput();
            }

        }
        CC.Service();
    }
}