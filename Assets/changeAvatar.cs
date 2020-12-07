using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAvatar : MonoBehaviour
{
    public int avatarIndex;

    private void OnTriggerEnter(Collider other)
    {
        Transform trans = other.transform;
        for (int i = 1; i < 12; i++)
        {
            trans.GetChild(i).gameObject.SetActive(false);
        }
        trans.GetChild(avatarIndex).gameObject.SetActive(true);
        Debug.Log("Transform: " + other.transform);
        //Debug.Log("Components? : " + other.GetComponents<GameObject>());
    }
}
