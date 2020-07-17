using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageUIUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject stepButtonContainer;
    [SerializeField]
    private GameObject toolbarButtonContainer;
    [SerializeField]
    private Button backwardButton, forwardButton;
    [SerializeField]
    private Text startButtonHorizontalTxt, startButtonVerticalTxt;
    // TODO: add loText field

    private GuideModeEventManager eventManager;
    private PageManager pageManager;
    private PanelManager panelManager;

    // TODO: maybe add these to the loText file?
    private const string START_TXT = "START LEARNING";
    private const string RESUME_TXT = "RESUME LEARNING";

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
        pageManager = PageManager.Instance;
        panelManager = PanelManager.Instance;
    }

    private void OnEnable()
    {
        // watch for changes to data that requires the UI to be modified
        eventManager.OnModelTrackingStatusChanged += UpdateUI;
        eventManager.OnUserProgressUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        if (eventManager != null)
        {
            // if the event manager and any references to it's events haven't already been destroyed, unsubscribe to all events
            eventManager.OnModelTrackingStatusChanged -= UpdateUI;
            eventManager.OnUserProgressUpdated -= UpdateUI;
        }
    }

    // TODO: possibily think of better names for these methods, to allow ppl to distinguish between them better
    private void UpdateUI(UserProgressData currentProgress)
    {
        // update the UI to reflect the user's current progress
        startButtonHorizontalTxt.text = currentProgress.isNewUser ? START_TXT : RESUME_TXT;
        startButtonVerticalTxt.text = currentProgress.isNewUser ? START_TXT : RESUME_TXT;

        // when the user isn't on the intro step, show the step buttons on the main page
        stepButtonContainer.SetActive(currentProgress.currentStep != SaveDataManager.INTRO_STEP);

        // when not on the first LO's intro, enable the back navigation button on the main page. Otherwise, disable it.
        if (currentProgress.currentLO != SaveDataManager.FIRST_LO || currentProgress.currentStep != SaveDataManager.INTRO_STEP)
        {
            ButtonInteractivityController.EnableButton(backwardButton);
        }
        else
        {
            ButtonInteractivityController.DisableButton(backwardButton);
        }

        // when not on the last LO's last step, enable the forward navigation button on the main page. Otherwise, disable it.
        int lastLO = 10; // TODO: get acutal lastLO from loText file
        if (currentProgress.currentLO != lastLO || currentProgress.currentStep != currentProgress.stepsInCurrentLO)
        {
            ButtonInteractivityController.EnableButton(forwardButton);
        }
        else
        {
            ButtonInteractivityController.DisableButton(forwardButton);
        }

        if (currentProgress.furthestLO >= SaveDataManager.FIRST_LO)
        {
            // if the user has selected a learning objective, display the main page
            pageManager.MakePageActive(PageType.Main);

            if (currentProgress.isNewUser)
            {
                panelManager.ShowPanel(PanelType.Tutorial);
            }
        }
    }

    private void UpdateUI(bool trackingState)
    {
        // TODO: update the UI to show whether the pelvis model is currently being tracked or not
        Debug.Log("TODO: update UI to reflect model tracking status changed");
    }
}
