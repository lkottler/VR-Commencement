using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "OTHER_PLAYER"), new Vector3(-149.5f, 126.215f, 262.58f), Quaternion.identity);
        // TEMP, SHOULD ONLY HAVE TO NETWORK INSTANTIATE
        Instantiate(playerPrefab, new Vector3(-149.5f, 126.215f, 262.58f), Quaternion.identity);

    }
}
