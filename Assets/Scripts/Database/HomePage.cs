﻿using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    public InputField regUser, regPW, regConf, logUser, logPW;
    public GameObject MenuCanvas;

    public GameObject player;
    public Camera loginCam;

    public Button loginBtn;
    public Button regBtn;
    public Button guestBtn;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void SpawnPlayer()
    {
        GameObject generatedPlayer = Instantiate(player, new Vector3(-149.5f, 126.215f, 262.58f), Quaternion.identity);
        loginCam.enabled = false;
        //generatedPlayer.transform.localScale = new Vector3(3, 3, 3);
        MenuCanvas.SetActive(false);

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
        string url = "LINK TO PHP OF REGISTER"; //TODO

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.downloadHandler.text[0] == '0')
            {
                Debug.Log("Registration worked.");
                // TODO load user into the game
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
        string url = "LINK TO PHP OF REGISTER"; //TODO

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.downloadHandler.text[0] == '0')
            {
                Debug.Log("Login worked.");
                // TODO load user into the game
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
