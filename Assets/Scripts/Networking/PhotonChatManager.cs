using ExitGames.Client.Photon;
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
        throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        Debug.Log("OnConnected() Called");
    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        Debug.Log("OnGetMessages() called: channelName: " + channelName + " #senders: " + senders.Length + " messages: " + messages.Length);
        string msgs = "";
        for (int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("{0}{1}={2}, ", msgs, senders[i], messages[i]);
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
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("OnSubscribed() called");
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
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
    }

    bool typing = false;

    void SendMessage()
    {
        CC.PublishMessage("public", userMessage.text);
        userMessage.text = "";
    }

    public IEnumerator ActivateInput()
    {
        yield return 0;
        userMessage.Select();
        userMessage.ActivateInputField();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("User pressed enter");
            if (userMessage.text.Length > 0)
            {
                Debug.Log("user has a message: " + userMessage.text);
                SendMessage();
            } else
            {
                Debug.Log("Attempting to activate input field");
                ActivateInput();
            }

        }
        CC.Service();
    }
}
