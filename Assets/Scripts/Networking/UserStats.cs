using Photon.Pun;
using UnityEngine;

public class UserStats : MonoBehaviour
{
    private static string username = "Guest";
    public static UserStats m_Instance = null;
    public static UserStats Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = (UserStats)FindObjectOfType(typeof(UserStats));
            return m_Instance;
        }
    }

    void Awake()
    {
        m_Instance = this;
    }
    public static void setUsername(string name)
    {
        username = name;
        Debug.Log("setting name as: " + name);
        PhotonNetwork.LocalPlayer.NickName = name;
    }
    public static string getUsername() { return username; }
}
