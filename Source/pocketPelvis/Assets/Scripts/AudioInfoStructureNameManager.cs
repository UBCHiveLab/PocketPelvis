using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioInfoStructureNameManager {
    
    //InfoEvent plays audio files related to structure.
    //it used to play just the name of the structure, so it's named this way

    Dictionary<string, AudioClip> nameAndAudio;

    private static readonly AudioInfoStructureNameManager INSTANCE = new AudioInfoStructureNameManager();

    private AudioInfoStructureNameManager()
    {
        nameAndAudio = ParserForAll.Instance.SortAudioNamesByStructureNames;
        EventManager.Instance.InfoEvent += OnInfoEvent;
    }

    public static AudioInfoStructureNameManager Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    private void OnInfoEvent(string name)
    {
        if (nameAndAudio.ContainsKey(name))
        {
            EventManager.Instance.publishAudioEvent(nameAndAudio[name]);
        }
    }
}
