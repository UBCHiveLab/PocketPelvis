using UnityEngine;
using UnityEngine.UI;

public class PageUIUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject stepButtonContainer;
    [SerializeField]
    private Button backwardButton, forwardButton, infoButton, labelButton;
    [SerializeField]
    private Text startButtonHorizontalTxt, startButtonVerticalTxt, introTxt, fitTxt, infoTxt;
    
    private LOTexts loTexts;

    private GuideModeEventManager eventManager;
    private PageManager pageManager;
    private PanelManager panelManager;
    private LabelManager labelManager;
    private ModelTrackingManager modelTrackingManager;

    // TODO: maybe add these to the loText file?
    private const string START_TXT = "START LEARNING";
    private const string RESUME_TXT = "RESUME LEARNING";

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
        pageManager = PageManager.Instance;
        panelManager = PanelManager.Instance;
        labelManager = LabelManager.Instance;
        modelTrackingManager = ModelTrackingManager.Instance;
        loTexts = new LOTextParser().loTexts;
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

    /// <summary> Update the UI to reflect the user's current progress </summary>
    private void UpdateUI(UserProgressData currentProgress)
    {
        startButtonHorizontalTxt.text = currentProgress.isNewUser ? START_TXT : RESUME_TXT;
        startButtonVerticalTxt.text = currentProgress.isNewUser ? START_TXT : RESUME_TXT;

        // when not on the first LO's intro, enable the back navigation button on the main page. Otherwise, disable it.
        bool showBackButton = currentProgress.currentLO != SaveDataManager.FIRST_LO || currentProgress.currentStep != SaveDataManager.INTRO_STEP;
        ButtonInteractivityController.SetButtonInteractivity(backwardButton, showBackButton);

        // when not on the last LO's last step, enable the forward navigation button on the main page. Otherwise, disable it.
        bool showForwardButton = currentProgress.currentLO != loTexts.GetLastLO() || currentProgress.currentStep != currentProgress.stepsInCurrentLO;
        ButtonInteractivityController.SetButtonInteractivity(forwardButton, showForwardButton);

        if (PageType.Main == pageManager.GetActivePageType())
        {
            // when the user isn't on the intro step, show the step buttons on the main page
            stepButtonContainer.SetActive(currentProgress.currentStep != SaveDataManager.INTRO_STEP);

            // determine the proper panel and panel text to display, based on the user's current progress
            PanelType defaultPanel, panelToShow;
            defaultPanel = panelToShow = PanelType.FitInstructions;
            // set guide view to empty
            modelTrackingManager.SetGuideView(GuideViewOrientation.NoGuideView);
            if (currentProgress.isNewUser)
            {
                panelToShow = PanelType.Tutorial;
            }
            else if (currentProgress.currentStep == SaveDataManager.INTRO_STEP)
            {
                // Update Intro Text
                introTxt.text = loTexts.GetIntroductionForLO(currentProgress.currentLO);
                defaultPanel = panelToShow = PanelType.Introduction;
            }
            else
            {
                StepText stepText = loTexts.GetStepText(currentProgress.currentLO, currentProgress.currentStep);
                // Update fit text
                fitTxt.text = "Please fit the 3D pelvis with the 2D shape! " + stepText.fitInfoText;
                // Update Info Text
                infoTxt.text = stepText.stepInfoText;
                // Enable Corresponding Labels
                string[] labelTexts = stepText.labelTexts != null ? stepText.labelTexts.ToArray() : null;
                labelManager.EnableLabelsByText(SearchingTextType.bottomText, labelTexts);
                // Set guide view
                modelTrackingManager.SetGuideView(LOTextParser.ParseGuideViewOrientation(stepText.guideViewOrientation));
            }

            panelManager.SetDefaultPanelType(defaultPanel);
            panelManager.ShowPanel(panelToShow);
        }
    }

    /// <summary> Update the UI to show whether the pelvis model is currently being tracked or not </summary>
    private void UpdateUI(bool isTrackingModel)
    {
        // only allow the label and info buttons to be interacted with while the pelvis model is being tracked
        ButtonInteractivityController.SetButtonInteractivity(infoButton, isTrackingModel);
        ButtonInteractivityController.SetButtonInteractivity(labelButton, isTrackingModel);

        // When no other panels are showing, if the model is being tracked, show the model tracking indicator; otherwise, tell user how to align the model
        panelManager.SetDefaultPanelType(isTrackingModel ? PanelType.IsTrackingModel : PanelType.FitInstructions);
        panelManager.TogglePanel(PanelType.IsTrackingModel);
    }
}
