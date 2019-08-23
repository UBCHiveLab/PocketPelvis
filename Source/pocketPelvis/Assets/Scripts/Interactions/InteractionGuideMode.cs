using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class InteractionGuideMode
{
    //Guide Mode
    //TODO refactor search handler into 

    enum STATE { DEFAULT, HIGHLIGHT, FADE, HIDE };

    private static readonly InteractionGuideMode INSTANCE = new InteractionGuideMode();

    OrderedDictionary guidedRooms;
    LinkedList<string> currentModules;
    LinkedListNode<string> currentModule;
    Dictionary<string, List<string>> guideSteps;
    LinkedList<string> currentSteps;
    LinkedListNode<string> currentStep;
    Text currentStepStatus;

    GameObject canvas;
    RectTransform canvasRT;
    GameObject guideInteraction;
    RectTransform guideRT;
    Vector2 originalMax;
    Vector2 newMax;

    private InteractionGuideMode()
    {
        guidedRooms = ParserForAll.Instance.SortGuideStepsByGuideRooms_ordered;
        guideSteps = ParserForAll.Instance.SortStructuresByGuideSteps;
        initializeRoomsAndSteps();

        canvas = GameObject.Find("structureInteractionsPanel");
        canvasRT = canvas.GetComponent<RectTransform>();
        guideInteraction = InteractionLoader.Instance.GetGuideInteraction();
        guideRT = guideInteraction.GetComponent<RectTransform>();
        initializeGuideInteraction();
        initializeCanvaseHeight();
        guideInteraction.SetActive(false);

        EventManager.Instance.InteractionEvent += OnInteractionEvent;
    }

    private void initializeRoomsAndSteps()
    {
        string[] stub = new string[guidedRooms.Keys.Count];
        guidedRooms.Keys.CopyTo(stub, 0);
        currentModules = new LinkedList<string>(stub);
        currentModule = currentModules.First;
        currentSteps = (LinkedList<string>)guidedRooms[currentModule.Value];
        currentStep = currentSteps.First;
    }

    private void initializeCanvaseHeight()
    {
        originalMax = new Vector2(canvasRT.offsetMax.x, canvasRT.offsetMax.y);
        newMax = new Vector2(canvasRT.offsetMax.x, canvasRT.offsetMax.y - guideRT.rect.height);
    }

    private void initializeGuideInteraction()
    {
        guideInteraction.transform.SetParent(canvas.transform);
        guideInteraction.transform.localPosition = new Vector2(10f, canvasRT.rect.height / 2f);

        currentStepStatus = guideInteraction.transform.Find("currentStep").GetComponentInChildren<Text>();
        guideInteraction.transform.Find("nextStep").GetComponent<Button>().onClick.AddListener(GoToNextStep);
        guideInteraction.transform.Find("prevStep").GetComponent<Button>().onClick.AddListener(GoToPrevStep);
        guideInteraction.transform.Find("nextModule").GetComponent<Button>().onClick.AddListener(GoToNextModule);
        guideInteraction.transform.Find("prevModule").GetComponent<Button>().onClick.AddListener(GoToPrevModule);
    }

    private void GoToPrevModule()
    {
        if (currentModule.Previous == null)
        {
            currentModule = currentModules.Last;
        } else
        {
            currentModule = currentModule.Previous;
        }
        updateModuleStatus();
    }

    private void GoToNextModule()
    {
        if (currentModule.Next == null)
        {
            currentModule = currentModules.First;
        } else
        {
            currentModule = currentModule.Next;
        }
        updateModuleStatus();
    }

    private void updateModuleStatus()
    {
        currentSteps = (LinkedList<string>)guidedRooms[currentModule.Value];
        currentStep = currentSteps.First;
        changeCurrentStatus();
    }

    private void GoToPrevStep()
    {
        if (currentStep.Previous == null)
        {
            currentStep = currentSteps.Last;
        } else
        {
            currentStep = currentStep.Previous;
        }
        changeCurrentStatus();
    }

    private void GoToNextStep()
    {
        if (currentStep.Next == null)
        {
            currentStep = currentSteps.First;
        } else
        {
            currentStep = currentStep.Next;
        }
        changeCurrentStatus();
    }

    private void changeCurrentStatus()
    {
        changeCurrentTextStatus();
        changeCurrentStructuresStatus();
    }

    private void changeCurrentStructuresStatus()
    {
        EventManager.Instance.publishCollisionEvent(guideSteps[currentStep.Value]);
        EventManager.Instance.publishStateEvent("All", "HIDE");
        foreach (string s in guideSteps[currentStep.Value])
        {
            EventManager.Instance.publishStateEvent(s, "DEFAULT");
        }
    }

    private void changeCurrentTextStatus()
    {
        currentStepStatus.text = "Current: " + currentStep.Value;
    }

    private void OnInteractionEvent(string interactionType)
    {
        if (interactionType == "Guide")
        {
            canvasRT.offsetMax = newMax;
            guideInteraction.SetActive(true);
            EventManager.Instance.publishCollisionEvent(guideSteps[currentStep.Value]);
        }
        else
        {
            guideInteraction.SetActive(false);
        }
    }

    public static InteractionGuideMode Instance
    {
        get
        {
            return INSTANCE;
        }
    }
}