using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterAvatar : MonoBehaviour
{

    GameObject Canvas;
    public QuickSpawn QuickSpawnController;
    public Button GoBackBtn, enterStadiumBtn, selectBlackBtn, selectBrownBtn, selectWhiteBtn;
    public bool regSuccess;
    public static RegisterAvatar m_Instance = null;
    public static RegisterAvatar Instancce
    {
        get
        {
            if (m_Instance == null)
                m_Instance = (RegisterAvatar)FindObjectOfType(typeof(RegisterAvatar));
            return m_Instance;
        }
    }

    void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    public void CallEnterStadium()
    {
        StartCoroutine(Register());
        Debug.Log("CallGoBack called");
    }

    public void CallGoBack()
    {
        SceneManager.LoadScene(sceneName: "LoginScene");
        Debug.Log("CallGoBack called");
    }


    IEnumerator Register()
    {
        Debug.Log("Attempting to Register");
        WWWForm form = new WWWForm();
        //I want to update the field of current user with texture 
        form.AddField("name", UserStats.getUsername());
        form.AddField("password", UserStats.getPassword());
        form.AddField("texture", UserStats.getTexture());
        string url = "http://pages.cs.wisc.edu/~lkottler/commencement/register"; //TODO
        Debug.Log("Database updating started");
        regSuccess = true;
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))//FIXME, change this to update, or delete before this action
        {
            yield return webRequest.SendWebRequest();
            Debug.Log("Database update returned");
            if (webRequest.downloadHandler.text[0] == '0') 
            {
                regSuccess = true;
                QuickSpawnController.guestStart();
                Debug.Log("update avatar worked");
            }
            else
            {
                regSuccess = false;
                Debug.Log("Update avatar failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    public void CallSelectGradBlack() 
    {
        UserStats.setTexture("Graduate_Black");
    }
    public void CallSelectGradBrown()
    {
        UserStats.setTexture("Graduate_Brown");
    }
    public void CallSelectGradWhite()
    {
        UserStats.setTexture("Graduate_White");
    }

}
