using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Realtime;

public class GameSetupController : MonoBehaviour
{
    public float SpawnTime;
    float timer;
    bool PlayerSpawned = false;

    [SerializeField]
    GameObject playerPrefab;
    void Start()
    {

    }

    private void Update()
    {
        if (!PlayerSpawned)
        {
            timer += Time.deltaTime;
            if (timer >= SpawnTime)
            {
                Debug.Log("CREATING A NEW PLAYER");
                PlayerSpawned = true;
                CreatePlayer();
            }
        }
    }
    private void CreatePlayer()
    {
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PLAYER"), new Vector3(-149.5f, 127.3f, 262.58f), Quaternion.identity);
        player.GetComponentInChildren<Camera>().enabled = true;
        player.GetComponentInChildren<AudioListener>().enabled = true;

        //TODO set the players name somehow
        player.GetComponentInChildren<TextMesh>().text = "Guest";
    }
}
