using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InteractionToggle : MonoBehaviour {

    //Change interaction type
    //name of button controlled by InteractionTypeName

    Button thisButton;
    string currentInteraction;
    List<string> currentGroupings;
    OrderedDictionary interactionAndGroupings;
    IDictionaryEnumerator interactionAndGroupingsEnumerator;

    enum SFXTYPE { CLICKYES, CLICKNO, RECOGYES, RECOGNO }

    // Use this for initialization
    void Start () {
        interactionAndGroupings = ParserForAll.Instance.SortGroupsByInteractionTypes_ordered;
        interactionAndGroupingsEnumerator = interactionAndGroupings.GetEnumerator();

        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(getNextInteraction);
        getNextInteraction();
	}

    void getNextInteraction()
    {
        
        if (interactionAndGroupingsEnumerator.MoveNext() == false)
        {
            interactionAndGroupingsEnumerator.Reset();
            interactionAndGroupingsEnumerator.MoveNext();
        }

        currentInteraction = (string)interactionAndGroupingsEnumerator.Key;
        currentGroupings = (List<string>)interactionAndGroupingsEnumerator.Value;

        EventManager.Instance.publishInteractionEvent(currentInteraction, currentGroupings);

        EventManager.Instance.publishAudioSFXEvent("CLICKYES");
    }

    
}
