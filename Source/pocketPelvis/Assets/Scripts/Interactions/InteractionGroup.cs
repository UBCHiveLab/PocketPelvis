using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionGroup : InteractionPanel {

    //Interaction group panel
    //Functionalities for info button is commented out

    bool expandedOrNot;
    Text expandedSymbol;

    public InteractionGroup(string name) : base(name)
    {
        SetUpButton(name);
        //base.SetUpButtonRecolor();
    }

    private void SetUpButton(string name)
    {
        thisInteraction = InteractionLoader.Instance.GetGroupInteraction();

        GameObject state = thisInteraction.transform.Find("nameBtn").gameObject;
        Button stateBtn = state.GetComponent<Button>();
        stateBtn.onClick.AddListener(delegate { EventManager.Instance.publishStateEvent(name, ""); });
        stateBtn.GetComponentInChildren<Text>().text = name;
        //GameObject info = thisInteraction.transform.Find("infoBtn").gameObject;
        //Button infoBtn = info.GetComponent<Button>();
        //infoBtn.onClick.AddListener(delegate { EventManager.Instance.publishInfoEvent(name); });
        GameObject thisButton = thisInteraction.transform.Find("expandBtn").gameObject;
        Button groupBtn = thisButton.GetComponent<Button>();
        groupBtn.onClick.AddListener(delegate { EventManager.Instance.publishExpandedGroupEvent(name); });
        groupBtn.onClick.AddListener(ChangeExpandedSymbol);

        expandedOrNot = false;
        expandedSymbol = thisButton.GetComponentInChildren<Text>();
        //▼►
    }

    private void ChangeExpandedSymbol()
    {
        if (expandedOrNot)
        {
            expandedSymbol.text = "►";
            expandedOrNot = false;
        } else
        {
            expandedSymbol.text = "▼";
            expandedOrNot = true;
        }
    }
}
