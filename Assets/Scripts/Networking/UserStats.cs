using Photon.Pun;
using UnityEngine;

public class UserStats : MonoBehaviour
{
    private static string username = "Guest";

    public static void setUsername(string name)
    {
        username = name;
        Debug.Log("setting name as: " + name);
        PhotonNetwork.LocalPlayer.NickName = name;
    }
    public static string getUsername() { return username; }
}
