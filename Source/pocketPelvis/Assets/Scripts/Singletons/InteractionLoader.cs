using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLoader
{
    private GameObject StructureInteraction;
    private GameObject StructureInteractionWithAudio;
    private GameObject GroupInteraction;
    private GameObject SearchInteraction;

    private static readonly InteractionLoader INSTANCE = new InteractionLoader();

    private InteractionLoader()
    {
        StructureInteraction = (GameObject)GameObject.Instantiate(Resources.Load("InteractionPanels/structureInteractions"));
        StructureInteractionWithAudio = (GameObject)GameObject.Instantiate(Resources.Load("InteractionPanels/structureInteractionsWithAudio"));
        GroupInteraction = (GameObject)GameObject.Instantiate(Resources.Load("InteractionPanels/groupInteractions"));
        SearchInteraction = (GameObject)GameObject.Instantiate(Resources.Load("InteractionPanels/searchInteraction"));
    }

    public static InteractionLoader Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    public GameObject GetStructureInteraction()
    {
        return (GameObject)GameObject.Instantiate(StructureInteraction);
    }

    public GameObject GetStructureInteractionWithAudio()
    {
        return (GameObject)GameObject.Instantiate(StructureInteractionWithAudio);
    }

    public GameObject GetGroupInteraction()
    {
        return (GameObject)GameObject.Instantiate(GroupInteraction);
    }

    public GameObject GetSearchInteraction()
    {
        return (GameObject)GameObject.Instantiate(SearchInteraction);
    }
}
