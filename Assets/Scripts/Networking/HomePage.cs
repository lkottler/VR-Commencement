using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    GameObject userStatsObj;
    UserStats userStats;

    public GameObject LoginUI, SelectUI;
    public InputField regUser, regPW, regConf, logUser, logPW,regDegree;
    public QuickSpawn QuickSpawnController;
    public Camera mainCam;
    public bool logSuccess = false, regSuccess = false;
    public Text loginText, regDebug;
    private int avatarIndex = 0;
    private Vector3 cameraPosition, originalPos;
    private Quaternion cameraRotation, originalRot;
    private float cameraSpeed = 180.0f;
    private float cameraRotationSpeed = 1f;

    public Button loginBtn, regBtn, guestBtn;
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
        cameraPosition = mainCam.transform.position;
        cameraRotation = mainCam.transform.rotation;
        originalPos = cameraPosition;
        originalRot = cameraRotation;
        userStatsObj = GameObject.Find("UserStats");
        UserStats userStats = userStatsObj.GetComponent<UserStats>();
        DontDestroyOnLoad(userStatsObj);

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

    private void selectAvatar()
    {
        StartCoroutine(DelayUI(true));
        cameraPosition = new Vector3(1894f, -184.07f, 626.04f);
        cameraRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
    }
    IEnumerator DelayUI(bool choosing)
    {   
        SelectUI.SetActive(false);
        LoginUI.SetActive(false);
        yield return new WaitForSeconds(3.2f);
        if (choosing)
            SelectUI.SetActive(true);
        else
            LoginUI.SetActive(true);
        
    }
    public void goBack()
    {
        StartCoroutine(DelayUI(false));
        cameraPosition = originalPos;
        cameraRotation = originalRot;
    }

    public void CallRegister()
    {
        //StartCoroutine(Register());
        StartCoroutine(checkUsername());
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
        //SceneManager.LoadScene(sceneName: "RegisterGuestAvatar");
        Debug.Log("CallGuest called");
        SpawnPlayer();
    }

    public void RegisterAndSpawn()
    {
        UserStats.setAvatarIndex(avatarIndex);
        StartCoroutine(Register());
    }
    public void setAvatar(int index)
    {
        avatarIndex = index;
        UserStats.setAvatarIndex(index);
    }

    IEnumerator checkUsername()
    {
        if (regPW.text != regConf.text)
        {
            regDebug.text = "Passwords do not match!";
            yield break;
        }
        WWWForm form = new WWWForm();
        form.AddField("name", regUser.text);
        form.AddField("password", regPW.text);
        string url = "http://pages.cs.wisc.edu/~lkottler/commencement/login"; //TODO
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.downloadHandler.text[0] == '5')
            {
                logSuccess = true;
                Debug.Log("Register is possible.");
                selectAvatar();
            }
            else
            {
                Debug.Log("username taken");
                regDebug.text = "Unable to register with that username!";
            }
        }
    }

    IEnumerator Register()
    {
        Debug.Log("Attempting to Register");
        WWWForm form = new WWWForm();
        form.AddField("name", regUser.text);
        form.AddField("password", regPW.text);
        form.AddField("degree", regDegree.text);
        form.AddField("avatar", avatarIndex);
        string url = "http://pages.cs.wisc.edu/~lkottler/commencement/register"; //TODO
        Debug.Log("Database starting");
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log("Database returned");
            if (webRequest.downloadHandler.text[0] == '0')
            {
                regSuccess = true;
                Debug.Log("Registration worked.");
                UserStats.setUsername(regUser.text);
                UserStats.setDegree(regDegree.text);
                SpawnPlayer();
                //SceneManager.LoadScene(sceneName: "RegisterAvatar");

            }
            else
            {
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
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.downloadHandler.text[0] == '0')
            {
                logSuccess = true;
                string[] data = webRequest.downloadHandler.text.Split('\t');
                Debug.Log("Login worked.");
                //TODO populate connected user's fields into their prefab before loading
                UserStats.setUsername(logUser.text);
                UserStats.setDegree(data[1]);
                UserStats.setAvatarIndex(int.Parse(data[2]));
                SpawnPlayer();
            }
            else
            {
                loginText.text = "Login failed. Error #" + webRequest.downloadHandler.text;
                Debug.Log("Login failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    public void VerifyInputs()
    {
        //regBtn.interactable = (regPW.text != regConf.text) ? false : regUser.text.Length > 4 && regPW.text.Length > 4;
        //loginBtn.interactable = logUser.text.Length > 4 && logPW.text.Length > 4;
    }


    private void Update()
    {
        mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position,
            cameraPosition, cameraSpeed * Time.deltaTime);
        mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation,
            cameraRotation, cameraRotationSpeed * Time.deltaTime);
    }
}
