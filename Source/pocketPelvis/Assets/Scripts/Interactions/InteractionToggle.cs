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

    List<string> activeRooms;
    IEnumerator activeRoomsEnum;
    
    // Use this for initialization
    void Start () {
        activeRooms = getActiveRooms();
        activeRoomsEnum = activeRooms.GetEnumerator();

        thisButton = this.gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(getNextInteraction);
        getNextInteraction();
	}

    private List<string> getActiveRooms()
    {
        OrderedDictionary roomTypes = ParserForAll.Instance.SortOnOffStatesByRoomTypes;

        List<string> activeRooms = new List<string>();

        foreach (DictionaryEntry de in roomTypes)
        {
            if ((bool)de.Value)
            {
                activeRooms.Add((string)de.Key);
            }
        }

        return activeRooms;
    }

    void getNextInteraction()
    {
        
        if (activeRoomsEnum.MoveNext() == false)
        {
            activeRoomsEnum.Reset();
            activeRoomsEnum.MoveNext();
        }

        currentInteraction = (string)activeRoomsEnum.Current;
        
        EventManager.Instance.publishInteractionEvent(currentInteraction);
    }

    
}
