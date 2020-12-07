using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteGame : MonoBehaviour
{
    private Button thisBtn;
    private bool muted = false;
    private void Start()
    {
        thisBtn = gameObject.GetComponent<Button>();
    }
    public void toggleMute()
    {
        muted = !muted;
        UserStats.player.GetComponentInChildren<AudioListener>().enabled = !muted;
        if (muted)
        {
            thisBtn.GetComponentInChildren<Text>().text = "Unmute";
            thisBtn.GetComponent<Image>().color = new Color(39, 174, 96, 255);
        }
        else
        {
            thisBtn.GetComponentInChildren<Text>().text = "Mute";
            thisBtn.GetComponent<Image>().color = new Color(231, 76, 60, 255);
        }
    }
}
