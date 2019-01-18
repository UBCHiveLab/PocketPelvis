using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity;
using System;
using System.Linq;

public class InteractionPanelFactory {
    
    //Instatiate all interaction buttons and store in dictionary for other scripts to get from

    Dictionary<string, InteractionPanel> interactionPanelOfName;

    private static readonly InteractionPanelFactory INSTANCE = new InteractionPanelFactory();
    enum INTERACTION { STRUCTURE, GROUP, NONE};

    private InteractionPanelFactory()
    {
        interactionPanelOfName = GenerateAllInteraction();
    }

    public static InteractionPanelFactory Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    public InteractionPanel GetInteractionPanel(string name)
    {
        if (interactionPanelOfName.ContainsKey(name))
        {
            return interactionPanelOfName[name];
        }
        else
        {
            Debug.Log("no structure named " + name + " in UI dictionary");
            return null;
        }
    }
    /*
    public InteractionPanel GetStructureInteraction(string name)
    {
        if (interactionPanelOfName.ContainsKey(name))
        {
            return interactionPanelOfName[name];
        } else
        {
            Debug.Log("no structure named " + name + " in UI dictionary");
            return null;
        }
    }

    public InteractionPanel GetGroupInteraction(string name)
    {
        if (interactionPanelOfName.ContainsKey(name))
        {
            return interactionPanelOfName[name];
        }
        else
        {
            Debug.Log("no group named " + name + " in UI dictionary");
            return null;
        }
    }
    */
    private Dictionary<string, InteractionPanel> GenerateAllInteraction()
    {
        string[] structureNamesWithAudio = new string[ParserForAll.Instance.SortAudioNamesByStructureNames.Keys.Count];
        ParserForAll.Instance.SortAudioNamesByStructureNames.Keys.CopyTo(structureNamesWithAudio, 0);
        string[] structureNames = new string[ParserForAll.Instance.SortGroupsByStructureNames.Keys.Count];
        ParserForAll.Instance.SortGroupsByStructureNames.Keys.CopyTo(structureNames, 0);
        string[] structureGroups = new string[ParserForAll.Instance.SortStructureNamesByGroups.Keys.Count];
        ParserForAll.Instance.SortStructureNamesByGroups.Keys.CopyTo(structureGroups, 0);

        //structureNames.Except(structureNamesWithAudio);

        Dictionary<string, InteractionPanel> allInteractions = new Dictionary<string, InteractionPanel>();
        
        foreach (string name in structureNames)
        {
            if (!(Array.IndexOf(structureGroups, name) > -1))
            {
                if (Array.Exists<string>(structureNamesWithAudio, element => element == name))
                {
                    allInteractions.Add(name, GenerateStructureInteractionWithAudio(name));
                } else
                {
                    allInteractions.Add(name, GenerateStructureInteraction(name));
                }
            }
        }
        
        /*
        foreach (string name in structureNamesWithAudio)
        {
            allInteractions.Add(name, GenerateStructureInteractionWithAudio(name));
        }

        foreach (string name in structureNames)
        {
            allInteractions.Add(name, GenerateStructureInteraction(name));
        }
        */

        foreach (string group in structureGroups)
        {
            allInteractions.Add(group, GenerateGroupInteraction(group));
        }

        return allInteractions;
    }

    public InteractionPanel GenerateStructureInteraction(string name)
    {
        return new InteractionStructure(name);
    }

    public InteractionPanel GenerateGroupInteraction(string name)
    {
        return new InteractionGroup(name);
    }

    public InteractionPanel GenerateStructureInteractionWithAudio(string name)
    {
        return new InteractionStructureWithAudio(name);
    }
}
