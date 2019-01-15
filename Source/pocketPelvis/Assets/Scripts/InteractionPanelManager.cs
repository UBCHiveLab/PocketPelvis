using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanelManager {

    //Recreate interaction panel with new set of buttons everytime CollisionEvent is published

    GameObject canvas;
    List<GameObject> interactionPanel = new List<GameObject>();

    private static readonly InteractionPanelManager INSTANCE = new InteractionPanelManager();
    enum INTERACTION { STRUCTURE, GROUP, NONE };

    private InteractionPanelManager()
    {
        canvas = GameObject.Find("structureInteractionsPanelContent");
        EventManager.Instance.CollisionEvent += OnCollisionEvent;
    }

    public static InteractionPanelManager Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    public void OnCollisionEvent(List<string> names)
    {
        ResetPanel();
        interactionPanel = GenerateInteractionPanel(names, canvas);
    }

    public List<GameObject> GenerateInteractionPanel(List<string> names, GameObject parent)
    {

        List<GameObject> interactionPanel = new List<GameObject>();

        float countOnlyGenerated = 0f;
        float currentPanelHeight = 0f;

        for (int countAllNames = names.Count - 1; countAllNames >= 0; countAllNames--)
        {
            GameObject thisInteraction = InteractionPanelFactory.Instance.GetInteractionPanel(names[countAllNames]).thisInteraction;
            thisInteraction.transform.SetParent(canvas.transform);
            float currentHeight = thisInteraction.GetComponent<RectTransform>().rect.height * (.5f + countOnlyGenerated);
            interactionPanel.Add(thisInteraction);
            //thisInteraction.GetComponent<RectTransform>().anchoredPosition = new Vector2(thisInteraction.transform.position.x, currentHeight);
            thisInteraction.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, currentHeight); //TODO: dont hardcode 0f in !!!
            countOnlyGenerated++;
            currentPanelHeight += thisInteraction.GetComponent<RectTransform>().rect.height;
        }

        parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentPanelHeight);
        return interactionPanel;
    }

    private void ResetPanel()
    {
        canvas.transform.DetachChildren();
    }
}
