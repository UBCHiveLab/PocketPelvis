using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler {

    AudioSource audioPlayer;
    bool activatedOrNot;

    private static readonly AudioHandler INSTANCE = new AudioHandler();

    private AudioHandler()
    {
        GameObject mygameobject = new GameObject();
        audioPlayer = mygameobject.AddComponent<AudioSource>();

        activatedOrNot = true;

        EventManager.Instance.AudioEvent += OnAudioEvent;
        EventManager.Instance.AudioActiveEvent += OnAudioActiveEvent;
    }

    public static AudioHandler Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    private void OnAudioEvent(AudioClip audioToPlay)
    {
        if (activatedOrNot)
        {
            audioPlayer.clip = audioToPlay;
            audioPlayer.Play();
        }
    }

    private void OnAudioActiveEvent(bool activeOrNot)
    {
        activatedOrNot = activeOrNot;
    }
}
