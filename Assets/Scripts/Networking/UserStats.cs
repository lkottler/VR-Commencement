using Photon.Pun;
using UnityEngine;

public class UserStats : MonoBehaviour
{
    private static string username = "Guest";
    private static string avatarTexture = "UWGraduate_Brown";//default texture
    private static string userDegree = "Bachelor of Science";//default Bachelor of Science
    private static string userPassword = "";
    private static bool busy = false;
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

    public static void setTexture(string texture) 
    {
        avatarTexture = texture;
        Debug.Log("setting avatar texture as: " + texture);
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

    public static string getUsername() { return username; }
    public static string getTexture() { return avatarTexture; }
    public static string getDegree() { return userDegree; }
    public static string getPassword() { return userPassword; }
}
