using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    public InputField regUser, regPW, regConf, logUser, logPW;
    public GameObject MenuCanvas;
    public QuickSpawn QuickSpawnController;

    public GameObject player;

    public Button loginBtn;
    public Button regBtn;
    public Button guestBtn;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void SpawnPlayer()
    {
        //GameObject generatedPlayer = Instantiate(player, new Vector3(-149.5f, 126.215f, 262.58f), Quaternion.identity);
        //generatedPlayer.transform.localScale = new Vector3(3, 3, 3);
        SceneManager.LoadScene(0);
        QuickSpawnController.guestStart();
    }
    public void CallGuest()
    {
        SpawnPlayer();
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", regUser.text);
        form.AddField("password", regPW.text);
        string url = "http://pages.cs.wisc.edu/~lkottler/commencement/register"; //TODO

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.downloadHandler.text[0] == '0')
            {
                Debug.Log("Registration worked.");
                SpawnPlayer();
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
                Debug.Log("Login worked.");
                SpawnPlayer();
            }
            else
            {
                Debug.Log("Login failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    public void VerifyInputs()
    {
        regBtn.interactable = (regPW.text != regConf.text) ? false : regUser.text.Length > 4 && regPW.text.Length > 4;
        loginBtn.interactable = logUser.text.Length > 4 && logPW.text.Length > 4;
    }

}
