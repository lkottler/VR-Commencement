using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soccerScore : MonoBehaviour
{
    private int points = 0;
    public TextMesh pointText;
    private AudioSource pointAudio;
    private void Start()
    {
        pointAudio = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject ball = other.gameObject;
        if (ball.name.Contains("ball")){
            pointAudio.Play();
            pointText.text = "Score:\n" + ++points;
        }
    }
}
