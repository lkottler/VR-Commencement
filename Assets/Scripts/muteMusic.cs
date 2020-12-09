using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class muteMusic : MonoBehaviour
{
    public Button muteButton;
    private bool muted = false;
    public KeyCode _key;

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;

        if (player.name.Contains("Clone"))
        {
            if (player.GetComponent<PhotonView>().IsMine)
            {
                muteButton.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject player = other.gameObject;

        if (player.name.Contains("Clone"))
        {
            if (player.GetComponent<PhotonView>().IsMine)
            {
                muteButton.gameObject.SetActive(false);
            }
        }
    }
    public void clickMute()
    {
        muted = !muted;
        gameObject.GetComponent<AudioSource>().mute = muted;
        if (muted)
        {
            muteButton.GetComponentInChildren<Text>().text = "(M)Unmute";
            muteButton.GetComponent<Image>().color = Color.green;
        }
        else
        {
            muteButton.GetComponentInChildren<Text>().text = "(M)Mute";
            muteButton.GetComponent<Image>().color = Color.red;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(_key) && !PhotonChatManager.typing)
        {
            muteButton.onClick.Invoke();
            Debug.Log("Mute key pressed.");
        }
    }
}
