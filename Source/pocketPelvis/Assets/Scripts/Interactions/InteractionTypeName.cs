using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTypeName {

    //Controls the name of interaction toggle. It's a separate script from the toggle monobehaviour in case you want to make it a separate button / panel.

    private static readonly InteractionTypeName INSTANCE = new InteractionTypeName();

    Text interactionTypeName;

    private InteractionTypeName()
    {
        interactionTypeName = GameObject.Find("structureInteractionsToggle").GetComponentInChildren<Text>();
        EventManager.Instance.InteractionEvent += OnInteractionEvent;
        //OnInteractionEvent("GAZELIGHT", null);
    }

    private void OnInteractionEvent(string interactionType, List<string> groupings)
    {
        interactionTypeName.text = interactionType;
    }
    
    public static InteractionTypeName Instance
    {
        get
        {
            return INSTANCE;
        }
    }
}
