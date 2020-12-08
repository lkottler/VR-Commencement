using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;

public class newBall : MonoBehaviour
{
    public Button spawnBallButton;
    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;

        if (player.name.Contains("Clone"))
        {
            if (player.GetComponent<PhotonView>().IsMine)
            {
                spawnBallButton.gameObject.SetActive(true);
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
                spawnBallButton.gameObject.SetActive(false);
            }
        }
    }
    public void spawnNewBall()
    {
        Vector3 position = new Vector3(-174.48f, 133f, 375f);
        GameObject ball = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ball"), position, Quaternion.identity);
    }
}
