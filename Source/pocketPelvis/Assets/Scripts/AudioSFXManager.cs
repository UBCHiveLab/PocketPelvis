using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXManager {

    private static readonly AudioSFXManager INSTANCE = new AudioSFXManager();

    Dictionary<string, AudioClip> SortSFXByName;

    enum SFXTYPE { CLICKYES, CLICKNO, RECOGYES, RECOGNO }

    private AudioSFXManager()
    {
        SortSFXByName = ParserForAll.Instance.SortSFXByNames;

        EventManager.Instance.AudioSFXEvent += OnSFXEvent;
    }

    public static AudioSFXManager Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    private void OnSFXEvent(string soundType)
    {
        if (SortSFXByName.ContainsKey(soundType))
        {
            EventManager.Instance.publishAudioEvent(SortSFXByName[soundType]);
        }
    }

}
