using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour {

    bool onoff;
    Text text;

    enum SFXTYPE { CLICKYES, CLICKNO, RECOGYES, RECOGNO }

    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Button>().onClick.AddListener(soundonoff);
        text = this.gameObject.GetComponentInChildren<Text>();

        onoff = false;
        soundonoff();
    }

    private void soundonoff()
    {
        if (onoff)
        {
            onoff = false;
            text.text = "Unmute";
            EventManager.Instance.publishAudioActiveEvent(onoff);
        }
        else
        {
            onoff = true;
            text.text = "Mute";
            EventManager.Instance.publishAudioActiveEvent(onoff);
            EventManager.Instance.publishAudioSFXEvent("CLICKYES");
        }
    }
}
