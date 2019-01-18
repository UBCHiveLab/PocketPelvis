using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EventManager {

    private static readonly EventManager INSTANCE = new EventManager();

    public delegate void StateDelegate(string name, string state);
    public event StateDelegate StateEvent;

    public delegate void InfoDelegate(string name);
    public event InfoDelegate InfoEvent;

    public delegate void ExpandedGroupDelegate(string group);
    public event ExpandedGroupDelegate ExpandedGroupEvent;

    public delegate void CollisionDelegate(List<string> names);
    public CollisionDelegate CollisionEvent;

    public delegate void InfoDisplayDelegate(string name, string type);
    public event InfoDisplayDelegate InfoDisplayEvent;

    public delegate void InteractionDelegate(string interactionType, List<string> groupings);
    public event InteractionDelegate InteractionEvent;

    public delegate void StateChangedDelegate(string name, string state);
    public event StateChangedDelegate StateChangedEvent;

    public delegate void VuforiaModelDelegate(string foundOrLost, string modelType, Transform parentTransform);
    public event VuforiaModelDelegate VuforiaModelEvent;

    public delegate void RecognitionStateChangedDelegate(string foundOrLost);
    public event RecognitionStateChangedDelegate RecognitionStateChangedEvent;

    public delegate void AudioEventDelegate(AudioClip audioToPlay);
    public event AudioEventDelegate AudioEvent;

    public delegate void AudioSFXEventDelegate(string soundType);
    public event AudioSFXEventDelegate AudioSFXEvent;

    public delegate void AudioActiveEventDelegate(bool activeOrNot);
    public event AudioActiveEventDelegate AudioActiveEvent;

    private EventManager()
    {
        //
    }

    public static EventManager Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    public void publishStateEvent(string name, string state)
    {
        StateEvent(name, state);
    }

    public void publishInfoEvent(string name)
    {
        InfoEvent(name);
    }

    public void publishExpandedGroupEvent(string group)
    {
        ExpandedGroupEvent(group);
    }

    public void publishCollisionEvent(List<string> names)
    {
        CollisionEvent(names);
    }

    public void publishInfoDisplayEvent(string name, string type)
    {
        InfoDisplayEvent(name, type);
    }

    public void publishInteractionEvent(string interaction, List<string> groupings)
    {
        InteractionEvent(interaction, groupings);
    }

    public void publishStateChangedEvent(string name, string state)
    {
        StateChangedEvent(name, state);
    }

    public void publishVuforiaModelEvent(string foundOrLost, string modelType, Transform parentTransform)
    {
        VuforiaModelEvent(foundOrLost, modelType, parentTransform);
    }

    public void publishRecognitionStateChangedEvent(string foundOrLost)
    {
        try
        {
            RecognitionStateChangedEvent(foundOrLost);
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log("Nothing listens to Vuforia recognition state changed. \nIgnore if this is thrown during scene loading (some items gets initialized after Vuforia targets). \nDebug otherwise. \n");
        }
    }

    public void publishAudioEvent(AudioClip audioToPlay)
    {
        AudioEvent(audioToPlay);
    }

    public void publishAudioSFXEvent(string soundType)
    {
        AudioSFXEvent(soundType);
    }

    public void publishAudioActiveEvent(bool activeOrNot)
    {
        AudioActiveEvent(activeOrNot);
    }
}