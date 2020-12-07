using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStatsMock 
{
    private static string username = "Guest";
    //private static string[] avatarTextures = { "Graduate_Black", "Graduate_Brown", "Graduate_White" };//default texture
    private static int avatarIndex = 0;
    private static string userDegree = "Bachelor of Science";//default Bachelor of Science
    private static string userPassword = "";
    //private static bool busy = false;
    //public static UserStats m_Instance = null;
    public static bool Chaton = false;
    public static bool isGuest = false;
    public static GameObject player;

    
    public static void setUsername(string name)
    {
        username = name;
        Debug.Log("setting name as: " + name);
        //PhotonNetwork.LocalPlayer.NickName = name;
    }

    public static void setAvatarIndex(int index)
    {
        avatarIndex = index;
    }

    public static void setDegree(string degree)
    {
        userDegree = degree;
        Debug.Log("setting user degree as: " + degree);
    }

    public static void setPassword(string password)
    {
        userPassword = password;
        Debug.Log("setting user password as: " + password);
    }

    public static void setChatOn(bool newChatOn)
    {
        Chaton = newChatOn;
        Debug.Log("setting ChatOn as: " + newChatOn);
    }

    public static string getUsername() { return username; }
    public static string getDegree() { return userDegree; }
    public static string getPassword() { return userPassword; }
    public static int getAvatarIndex() { return avatarIndex; }
    public static bool getChatOn() { return Chaton; }
}
