﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    GameObject MenuCanvas;
    public InputField regUser, regPW, regConf, logUser, logPW;
    public QuickSpawn QuickSpawnController;

    Button loginBtn, regBtn, guestBtn;
    public bool regSuccess;
    public bool logSuccess;

    void Start()
    {
        MenuCanvas = GameObject.Find("HomePageCanvas");

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
    }
    public bool CallRegister()
    {
        regSuccess = false;
        StartCoroutine(Register());
        return regSuccess;
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
                regSuccess = true;
                Debug.Log("Registration worked.");
                SpawnPlayer();
            }
            else
            {
                regSuccess = false;
                Debug.Log("Registration failed. Error #" + webRequest.downloadHandler.text);
            }
        }

    }

    public bool CallLogin()
    {
        logSuccess = false;
        StartCoroutine(Login());
        return logSuccess;
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
                Debug.Log("Login worked.");
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
        regBtn.interactable = (regPW.text != regConf.text) ? false : regUser.text.Length > 4 && regPW.text.Length > 4;
        loginBtn.interactable = logUser.text.Length > 4 && logPW.text.Length > 4;
    }

}
