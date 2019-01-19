using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSearchHandler {

    //Handles all search functions in search interaction mode

    private static readonly InteractionSearchHandler INSTANCE = new InteractionSearchHandler();

    GameObject canvas;
    RectTransform canvasRT;
    GameObject searchInteraction;
    RectTransform searchRT;
    String[] allNames;
    Vector2 originalMax;
    Vector2 newMax;
    InputField mainInputField;

    enum INTERACTION { STRUCTURE, GROUP, NONE };

    private InteractionSearchHandler()
    {
        canvas = GameObject.Find("structureInteractionsPanel");
        canvasRT = canvas.GetComponent<RectTransform>();
        searchInteraction = InteractionLoader.Instance.GetSearchInteraction();
        searchRT = searchInteraction.GetComponent<RectTransform>();
        allNames = ParserForAll.Instance.SortGroupsByStructureNames.Keys.ToArray();
        initializeSearchInteraction();
        initializeCanvasHeights();
        EventManager.Instance.InteractionEvent += OnInteractionEvent;
    }

    private void initializeSearchInteraction()
    {
        searchInteraction.transform.SetParent(canvas.transform);
        searchInteraction.transform.localPosition = new Vector2(10f, canvasRT.rect.height / 2f); 

        mainInputField = searchInteraction.transform.Find("InputField").GetComponent<InputField>();
        mainInputField.onEndEdit.AddListener(delegate { GetNameFromUser(mainInputField); });
        searchInteraction.transform.Find("okBtn").GetComponent<Button>().onClick.AddListener(StartSearchWithName);
    }

    private void StartSearchWithName()
    {
        string givenName = ParserForAll.Instance.stringTrimmer(mainInputField.text.ToLower()).Replace(" ", String.Empty);
        List<string> lon = new List<string>();
        if (givenName.Length > 0)
        {
            foreach (string name in allNames)
            {
                if (name.ToLower().Contains(givenName))
                {
                    lon.Add(name);
                }
            }
        }
        EventManager.Instance.publishCollisionEvent(lon);
    }

    private void GetNameFromUser(InputField mainInputField)
    {
        //whatever user typed is automatically saved to mainInputField
    }

    private void OnInteractionEvent(string interactionType)
    {
        if (interactionType == "Search")
        {
            canvasRT.offsetMax = newMax;
            searchInteraction.SetActive(true);
            

        } else
        {
            canvasRT.offsetMax = originalMax;
            searchInteraction.SetActive(false);
        }
    }

    private void initializeCanvasHeights()
    {
        originalMax = new Vector2(canvasRT.offsetMax.x, canvasRT.offsetMax.y);
        newMax = new Vector2(canvasRT.offsetMax.x, canvasRT.offsetMax.y - searchRT.rect.height);
    }

    public static InteractionSearchHandler Instance
    {
        get
        {
            return INSTANCE;
        }
    }


}
