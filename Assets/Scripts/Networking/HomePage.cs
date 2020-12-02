using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    GameObject userStatsObj;
    UserStats userStats;

    GameObject MenuCanvas;
    public InputField regUser, regPW, regConf, logUser, logPW,regDegree;
    public QuickSpawn QuickSpawnController;

    public Button loginBtn, regBtn, guestBtn;
    public bool regSuccess;
    public bool logSuccess;
    public static HomePage m_Instance = null;
    public static HomePage Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = (HomePage)FindObjectOfType(typeof(HomePage));
            return m_Instance;
        }
    }

    void Awake()
    {
        m_Instance = this;    
    }

    void Start()
    {
        userStatsObj = GameObject.Find("UserStats");
        UserStats userStats = userStatsObj.GetComponent<UserStats>();
        DontDestroyOnLoad(userStatsObj);

        MenuCanvas = GameObject.Find("HomePageCanvas");

        /* Attempting to set these by code failed
        Transform transLog, transReg;
        transLog = MenuCanvas.transform.GetChild(0);
        transReg = MenuCanvas.transform.GetChild(1);

        regUser = transReg.GetChild(0).GetComponent<InputField>();
        regPW   = transReg.GetChild(1).GetComponent<InputField>();
        regConf = transReg.GetChild(3).GetComponent<InputField>();

        logUser = transLog.GetChild(0).GetComponent<InputField>();
        logPW   = transLog.GetChild(1).GetComponent<InputField>();
        loginBtn = transLog.GetComponent<Button>();
        regBtn = transReg.GetComponent<Button>();
        guestBtn = MenuCanvas.GetComponent<Button>();
        */
    }
    public void CallRegister()
    {
        StartCoroutine(Register());
        Debug.Log("CallRegister called");
    }

    public void SpawnPlayer()
    {
        //GameObject generatedPlayer = Instantiate(player, new Vector3(-149.5f, 126.215f, 262.58f), Quaternion.identity);
        //generatedPlayer.transform.localScale = new Vector3(3, 3, 3);
        //SceneManager.LoadScene(0);
        QuickSpawnController.guestStart();
    }
    public void CallGuest()
    {
        SceneManager.LoadScene(sceneName: "RegisterGuestAvatar");
        Debug.Log("CallGuest called");
        //SpawnPlayer();
    }

    IEnumerator Register()
    {
        Debug.Log("Attempting to Register");
        WWWForm form = new WWWForm();
        form.AddField("name", regUser.text);
        form.AddField("password", regPW.text);
        form.AddField("degree", regDegree.text);
        string url = "http://pages.cs.wisc.edu/~lkottler/commencement/register"; //TODO
        Debug.Log("Database starting");
        regSuccess = true;
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log("Database returned");
            if (webRequest.downloadHandler.text[0] == '0')
            {
                regSuccess = true;
                Debug.Log("Registration worked.");
                //TODO populate connected user's fields into their prefab before loading
                UserStats.setUsername(regUser.text);
                UserStats.setDegree(regDegree.text);
                //SpawnPlayer();
                SceneManager.LoadScene(sceneName: "RegisterAvatar");

            }
            else
            {
                regSuccess = false;
                Debug.Log("Registration failed. Error #" + webRequest.downloadHandler.text);
            }
        }

    }

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", logUser.text);
        form.AddField("password", logPW.text);
        string url = "http://pages.cs.wisc.edu/~lkottler/commencement/login"; //TODO
        logSuccess = true;
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.downloadHandler.text[0] == '0')
            {
                logSuccess = true;
                Debug.Log("Login worked.");
                //TODO populate connected user's fields into their prefab before loading
                UserStats.setUsername(logUser.text);
                SpawnPlayer();
            }
            else
            {
                logSuccess = false;
                Debug.Log("Login failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    public void VerifyInputs()
    {
        //regBtn.interactable = (regPW.text != regConf.text) ? false : regUser.text.Length > 4 && regPW.text.Length > 4;
        //loginBtn.interactable = logUser.text.Length > 4 && logPW.text.Length > 4;
    }

}
