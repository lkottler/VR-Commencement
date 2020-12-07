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
        Vector3 position = new Vector3(Random.Range(-211f, -118f), 122.55f, Random.Range(250f, 312f));
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",UserStats.getTexture()), position, Quaternion.identity);
        UserStats.player = player;
    }
}
