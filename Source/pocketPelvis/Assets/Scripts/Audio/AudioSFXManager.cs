using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXManager {

    private static readonly AudioSFXManager INSTANCE = new AudioSFXManager();

    Dictionary<string, AudioClip> SortSFXByName;

    enum TRACKINGSTATE { NO, YES }
    enum SFXTYPE { CLICKYES, CLICKNO, RECOGYES, RECOGNO }

    private AudioSFXManager()
    {
        SortSFXByName = ParserForAll.Instance.SortSFXByNames;

        //this event trigger sound depending on recognition found or lost
        EventManager.Instance.RecognitionStateChangedEvent += OnRecognitionStateChangedEvent;

        //all these events blindly trigger click sounds
        EventManager.Instance.ExpandedGroupEvent += OnExpandedGroupEvent;
        EventManager.Instance.CollisionEvent += OnCollisionEvent;
        EventManager.Instance.InteractionEvent += OnInteractionEvent;
        EventManager.Instance.AudioActiveEvent += OnAudioActiveEvent;
        EventManager.Instance.StateChangedEvent += OnStateChangedEvent;
        EventManager.Instance.InfoEvent += OnInfoEvent;
    }

    private void OnInfoEvent(string name)
    {
        playClickSFX();
    }

    private void OnStateChangedEvent(string name, string state)
    {
        playClickSFX();
    }

    private void OnAudioActiveEvent(bool activeOrNot)
    {
        playClickSFX();
    }

    private void OnInteractionEvent(string interactionType)
    {
        playClickSFX();
    }

    private void OnCollisionEvent(List<string> names)
    {
        playClickSFX();
    }

    private void OnRecognitionStateChangedEvent(string foundOrLost)
    {
        if (foundOrLost == "YES")
        {
            playRecogFound();
        }
        else
        {
            playRecogLost();
        }
    }

    private void OnExpandedGroupEvent(string group)
    {
        playClickSFX();
    }

    public static AudioSFXManager Instance
    {
        get
        {
            return INSTANCE;
        }
    }
    
    private void playClickSFX()
    {
        EventManager.Instance.publishAudioEvent(SortSFXByName["CLICKYES"]);
    }

    private void playRecogFound()
    {
        EventManager.Instance.publishAudioEvent(SortSFXByName["RECOGYES"]);
    }

    private void playRecogLost()
    {
        EventManager.Instance.publishAudioEvent(SortSFXByName["RECOGNO"]);
    }
}
