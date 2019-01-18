using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class InteractionGroupSorter {

    //Show list of buttons according to groupings
    //Doesn't handle gazelight and search interactions
    
    enum SFXTYPE { CLICKYES, CLICKNO, RECOGYES, RECOGNO}

    List<string> names;

    Dictionary<string, List<string>> structureGroup;

    private static readonly InteractionGroupSorter INSTANCE = new InteractionGroupSorter();

    private InteractionGroupSorter()
    {
        names = new List<string>();

        structureGroup = ParserForAll.Instance.SortStructureNamesByGroups;

        EventManager.Instance.InteractionEvent += OnInteractionEvent;
        EventManager.Instance.ExpandedGroupEvent += OnExpandedGroupEvent;
    }

    public static InteractionGroupSorter Instance
    {
        get
        {
            return INSTANCE;
        }
    }
    
    void OnInteractionEvent(string interactionType, List<string> groupings)
    {
        names = new List<string>();

        if (interactionType != "GAZELIGHT" && interactionType != "SEARCH")
        {
            foreach (string group in groupings)
            {
                if (structureGroup.ContainsKey(group))
                {
                    names.Add(group);
                } else
                {
                    throw new Exception("recheck structureGroupings if all groups exist in structureGroups");
                }
            }
        }
        
        EventManager.Instance.publishCollisionEvent(names);
    }

    void OnExpandedGroupEvent(string group)
    {
        int indexOfGroup = names.IndexOf(group);
        if (indexOfGroup + 1 >= names.Count || structureGroup.ContainsKey(names[indexOfGroup + 1]))
        {
            AddNamesToList(group, indexOfGroup);
            EventManager.Instance.publishAudioSFXEvent("CLICKYES");
        }
        else
        {
            RemoveNamesFromList(group, indexOfGroup);
            EventManager.Instance.publishAudioSFXEvent("CLICKNO");
        }
        
        EventManager.Instance.publishCollisionEvent(names);
    }

    private void AddNamesToList(string group, int index)
    {
        List<string> FirstHalf = names.GetRange(0, index + 1);
        List<string> StructuresOfGroup = structureGroup[group];
        FirstHalf.AddRange(StructuresOfGroup);

        if (!(index + 1 >= names.Count))
        {
            List<string> LastHalf = names.GetRange(index + 1, names.Count - index - 1);
            FirstHalf.AddRange(LastHalf);
        }

        names = FirstHalf;
    }

    private void RemoveNamesFromList(string group, int index)
    {
        int LastHalfIndex = index;
        LastHalfIndex++;
        bool yes = true;
        while (yes)
        {
            LastHalfIndex++;
            if (LastHalfIndex + 1 > names.Count || structureGroup.ContainsKey(names[LastHalfIndex]))
            {
                yes = false;
            }
        }

        List<string> FirstHalf = names.GetRange(0, index + 1);

        if (!(LastHalfIndex + 1 > names.Count))
        {
            List<string> LastHalf = names.GetRange(LastHalfIndex, names.Count - LastHalfIndex);
            FirstHalf.AddRange(LastHalf);
        }
        
        names = FirstHalf;
    }
}
