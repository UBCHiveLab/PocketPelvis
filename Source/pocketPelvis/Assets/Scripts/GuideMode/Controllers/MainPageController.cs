using UnityEngine;
using UnityEngine.UI;

public class MainPageController : PageController
{
    [SerializeField]
    private GameObject stepButtonContainer;
    [SerializeField]
    private Button backwardButton, forwardButton, infoButton, labelButton;
    [SerializeField]
    private Text introTxt, fitTxt, infoTxt;

    private PanelManager panelManager;
    private LabelManager labelManager;
    private ModelTrackingManager modelTrackingManager;

    private const string PLEASE_FIT_TXT = "Please fit the 3D pelvis with the 2D shape! ";

    private void Awake()
    {
        panelManager = PanelManager.Instance;
        labelManager = LabelManager.Instance;
        modelTrackingManager = ModelTrackingManager.Instance;
    }

    public override void UpdateUI(UserProgressData currentProgress, LOTexts loTexts)
    {
        // when not on the first LO's intro, enable the back navigation button. Otherwise, disable it.
        bool showBackButton = currentProgress.currentLO != SaveDataManager.FIRST_LO || currentProgress.currentStep != SaveDataManager.INTRO_STEP;
        ButtonInteractivityController.SetButtonInteractivity(backwardButton, showBackButton);

        // when not on the last LO's last step, enable the forward navigation. Otherwise, disable it.
        bool showForwardButton = currentProgress.currentLO != loTexts.GetLastLO() || currentProgress.currentStep != currentProgress.stepsInCurrentLO;
        ButtonInteractivityController.SetButtonInteractivity(forwardButton, showForwardButton);

        // when the user isn't on the intro step, show the step buttons on the main page
        stepButtonContainer.SetActive(currentProgress.currentStep != SaveDataManager.INTRO_STEP);

        // determine the proper panel, panel text, and pelvis outline to display, based on the user's current progress
        GuideViewOrientation pelvisOutline = GuideViewOrientation.NoGuideView;
        PanelType defaultPanel, panelToShow;

        if (currentProgress.currentStep == SaveDataManager.INTRO_STEP)
        {
            defaultPanel = panelToShow = PanelType.Introduction;
            introTxt.text = loTexts.GetIntroductionForLO(currentProgress.currentLO);
        }
        else
        {
            defaultPanel = panelToShow = PanelType.FitInstructions;
            StepText stepText = loTexts.GetStepText(currentProgress.currentLO, currentProgress.currentStep);

            // Get the step's fit and info text
            fitTxt.text = PLEASE_FIT_TXT + stepText.fitInfoText;
            infoTxt.text = stepText.stepInfoText;

            // Enable the step's corresponding model labels
            string[] labelTexts = stepText.labelTexts != null ? stepText.labelTexts.ToArray() : null;
            labelManager.EnableLabelsByText(SearchingTextType.bottomText, labelTexts);

            // Determine which pelvis model outline to show, so that the user knows how they are supposed to align the model
            pelvisOutline = LOTextParser.ParseGuideViewOrientation(stepText.guideViewOrientation);
        }

        // now that we know which content to display for the step, show the tutorial, if the user is new
        if (currentProgress.isNewUser)
        {
            panelToShow = PanelType.Tutorial;
        }

        modelTrackingManager.SetGuideViewOrientation(pelvisOutline);
        panelManager.SetDefaultPanelType(defaultPanel);
        panelManager.ShowPanel(panelToShow);
    }

    public override void UpdateUI(bool isTrackingModel)
    {
        // only allow the label and info buttons to be interacted with while the pelvis model is being tracked
        ButtonInteractivityController.SetButtonInteractivity(infoButton, isTrackingModel);
        ButtonInteractivityController.SetButtonInteractivity(labelButton, isTrackingModel);

        // when the step buttons are not active, then the user is on the introduction step
        PanelType notTrackingPanel = stepButtonContainer.activeSelf ? PanelType.FitInstructions : PanelType.Introduction;

        // when no other panels are showing, if the model is being tracked, show the model tracking indicator; otherwise, show the step's regular default panel
        panelManager.SetDefaultPanelType(isTrackingModel ? PanelType.IsTrackingModel : notTrackingPanel);
        panelManager.TogglePanel(PanelType.IsTrackingModel);
    }
}
