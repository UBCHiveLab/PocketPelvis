// TODO: Remove file when finish refactoring

/*
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public enum StepControl
{
    Backward,
    Forward
}
public enum Progress { notStarted, inProgress, win };

public class LoNavigator : SceneSingleton<LoNavigator>
{
    // singeleton instance
    public static LoNavigator instance;

    IEnumerator WinMessage()
    {
        PanelManager.Instance.ShowPanel(PanelType.WellDone);
        //display win panel and close it after 1 second
        yield return new WaitForSeconds(1f);
        PanelManager.Instance.ShowPanel(PanelType.Info);
    }

    #region VARIABLES
    public Progress currentProgress;
    public Text buttonTextV, buttonTextH;

    // private variable
    [SerializeField]
    private Text introductionText, infoText, fitText;
    [SerializeField]
    private Button buttonForward, buttonBackward;
    [SerializeField]
    private GameObject stepButtonContainer;

    private LearningObjectives loData;
    private LOTexts loTexts;
    private List<Button> stepButtons;
    private int currentLO, currentStep;
    private ButtonInteractivityController buttonInteractivityController;
    #endregion

    #region DELEGATE_METHODS
    public delegate void setCurrentLODelegate(int LO, int step);
    public static event setCurrentLODelegate setCurrentLO;
    public delegate void displayLOUIDelegate();
    public static displayLOUIDelegate displayLOUI;
    public delegate void SetProgressDelegate(Progress progress);
    public static SetProgressDelegate SetProgress;
    #endregion

    const string START_LEARNING_TEXT = "START LEARNING";
    const string RESUME_LEARNING_TEXT = "RESUME LEARNING";

    private void Start()
    {
        instance = this;
        loData = LearningObjectives.instance;

        if (loData.IsNewUser())
        {
            buttonTextV.text = START_LEARNING_TEXT;
            buttonTextH.text = START_LEARNING_TEXT;
        }
        else
        {
            buttonTextV.text = RESUME_LEARNING_TEXT;
            buttonTextH.text = RESUME_LEARNING_TEXT;
        }

        #region SUBSCRIBE_DELEGATE_METHODS
        setCurrentLO += ChangeInfoTextBasedOnLO;
        setCurrentLO += UpdateStepControls;
        setCurrentLO += UpdateLOProgress;
        setCurrentLO += SetCurrentGuideView;
        setCurrentLO += SetLabels;
        displayLOUI += DisplayLOContent;
        displayLOUI += DisplayStepButtons;
        SetProgress += ChangeCurrentProgress;
        SetProgress += DisplayWinMessage;
        #endregion

        LoadInfoText();
        SetProgress(Progress.notStarted);

        buttonInteractivityController = gameObject.GetComponentInParent<ButtonInteractivityController>();
        stepButtons = stepButtonContainer.GetComponentsInChildren<Button>(true).ToList();

        // set listeners for the buttons that enable navigation through the LOs
        buttonBackward.onClick.AddListener(() => GoToNextStep(StepControl.Backward));
        buttonForward.onClick.AddListener(() => GoToNextStep(StepControl.Forward));
    }

    private void OnDisable()
    {
        #region DESUBSCRIBE_DELEGATE_METHODS
        setCurrentLO -= ChangeInfoTextBasedOnLO;
        setCurrentLO -= UpdateStepControls;
        setCurrentLO -= UpdateLOProgress;
        setCurrentLO -= SetCurrentGuideView;
        setCurrentLO -= SetLabels;
        displayLOUI -= DisplayLOContent;
        displayLOUI -= DisplayStepButtons;
        SetProgress -= ChangeCurrentProgress;
        SetProgress -= DisplayWinMessage;
        #endregion

        StopAllCoroutines();
    }

    public void StarButtonOnClick(string array)
    {
        string[] splitArray = array.Split(char.Parse("-"));
        int LO = int.Parse(splitArray[0]);
        int step = int.Parse(splitArray[1]);

        //update data
        setCurrentLO(LO, step);
        SetProgress(Progress.inProgress);
    }

    public void StarLearningFromLastSave()
    {
        
        // set the user's progress to the step and LO they were previously at, unless
        // was last at the introduction. Then, go to the first step.
        int lastStep = loData.GetCurrentStep();
        int stepToGoTo = lastStep == LearningObjectives.INTRO_STEP ? LearningObjectives.INTRO_STEP + 1 : lastStep;
        setCurrentLO(
            loData.GetCurrentLearningObjective(),
            stepToGoTo
        );

        displayLOUI();
        SetProgress(Progress.inProgress);
    }

    /// <summary>
    ///  Reset all user record
    /// </summary>
    public void ResetUser()
    {
        loData.ResetLOs();
        buttonTextV.text = START_LEARNING_TEXT;
        buttonTextH.text = START_LEARNING_TEXT;
    }

    public void OnClickStepButton(Button clickedButton)
    {
        // since arrays are 0-base indexed, the step of the clicked buttton will be the index of the button plus 1
        int step = stepButtons.IndexOf(clickedButton) + 1;
        setCurrentLO(currentLO, step);
    }

    private void DisplayLOIntroduction()
    {
        SetProgress(Progress.notStarted);

        stepButtonContainer.SetActive(false);

        // set the introduction text for the lo's intro and make the intro panel visible
        introductionText.text = loTexts.GetIntroductionForLO(currentLO);
        PanelManager.Instance.ShowPanel(PanelType.Introduction);
    }

    private void DisplayLOContent()
    {
        PageManager.Instance.MakePageActive(PageType.Main);

        if (!loData.IsNewUser())
        {
            PanelManager.Instance.ShowPanel(PanelType.Fit);
        } else
        {
            PanelManager.Instance.ShowPanel(PanelType.Tutorial);
        }
    }

    private void DisplayStepButtons()
    {
        if (stepButtons == null)
        {
            return;
        }

        if (!stepButtonContainer.activeSelf)
        {
            // make sure that the step button container is active, so can see the step buttons
            stepButtonContainer.SetActive(true);
        }

        int numStepsInLO = loData.GetNumberOfSteps(currentLO);

        for (int stepIndex = 0; stepIndex < stepButtons.Count; stepIndex++)
        {
            if (stepIndex < numStepsInLO)
            {
                // the step is in the lo. Make that step's button visible
                stepButtons[stepIndex].gameObject.SetActive(true);

                if (stepIndex == GetStepButtonIndex(currentStep))
                {
                    // this step is the current step, which has the pressed down graphic applied. Thus, nothing needs to be done
                    continue;
                } else if (loData.HaveBeenToStep(currentLO, stepIndex + 1))
                {
                    // We've never been to this step before. So, make this step's button interactable
                    buttonInteractivityController.EnableButton(stepButtons[stepIndex]);
                } else
                {
                    // we've never been to this step before. So, make the this step's button non-interactable
                    buttonInteractivityController.DisableButton(stepButtons[stepIndex]);
                }
            } else
            {
                // the step is not in the lo. Hide the button
                stepButtons[stepIndex].gameObject.SetActive(false);
            }
        }
    }
    private void PressDownStepButton(int step, int prevStep)
    {
        if (step == LearningObjectives.INTRO_STEP)
        {
            // there's no step buttons to press down in the introduction step
            return;
        }

        int stepIndex = GetStepButtonIndex(step);
        bool tintStepButton = false;

        if (prevStep != LearningObjectives.INTRO_STEP)
        {
            // stop pressing down on the previous step button
            int prevStepIndex = GetStepButtonIndex(prevStep);
            buttonInteractivityController.EnableButton(stepButtons[prevStepIndex], tintStepButton);
        }

        // make sure that the current step button looks like it is interactable
        buttonInteractivityController.EnableButton(stepButtons[stepIndex]);
        // give the button the pressed down graphic
        buttonInteractivityController.DisableButton(stepButtons[stepIndex], tintStepButton);
    }

    private void GoToNextStep(StepControl control)
    {
        SetProgress(Progress.inProgress);
        int numStepsInLO = loData.GetNumberOfSteps(currentLO);

        if (control == StepControl.Forward)
        {
            int nextStep = currentStep + 1;
            if (currentStep == LearningObjectives.INTRO_STEP)
            {
                // if we are on the introduction step, then go to the next step in the current LO and display the LO content
                setCurrentLO(currentLO, nextStep);
                displayLOUI();
            }
            else if (numStepsInLO > currentStep)
            {
                // if there are still steps that we haven't gone to in the current LO, go to the next step
                setCurrentLO(currentLO, nextStep);
            }
            else if (currentLO < loData.GetNumberOfLearningObjectives())
            {
                // otherwise, if there is a LO after the current LO, go to the introduction of the next LO
                setCurrentLO(currentLO + 1, LearningObjectives.INTRO_STEP);
                DisplayLOIntroduction();
            }
        }
        else if (control == StepControl.Backward)
        {
            int prevStep = currentStep - 1;
            if (prevStep == LearningObjectives.INTRO_STEP)
            {
                // if the previous step is the current LO's introduction, set that step to the current step and display the introduction
                setCurrentLO(currentLO, prevStep);
                DisplayLOIntroduction();
            } else if (prevStep > LearningObjectives.INTRO_STEP && numStepsInLO > prevStep)
            {
                // the previous step is a step in the current LO, so go to that step
                setCurrentLO(currentLO, prevStep);
            }
            else if (currentLO > 1)
            {
                // otherwise, we have seen all the steps in the current LO, so go back to the last step in the previous LO, if possible
                int prevLoLastStep = loData.GetNumberOfSteps(currentLO - 1);

                setCurrentLO(currentLO - 1, prevLoLastStep);
                displayLOUI();
            }
        }
    }
    private void LoadInfoText()
    {
        //loading info text from resource folder
        TextAsset load;
        load = Resources.Load<TextAsset>("GuideModeData/LOText");

        if(load!=null)
        loTexts = JsonUtility.FromJson<LOTexts>(load.text);
    }

    public void SetCurrentGuideView(int LO, int step)
    {
        //GuideViewOrientation foundOrientation = loTexts.GetGuideViewOrientation(LO, step);
        //ModelTrackingManager.Instance.SetGuideView(foundOrientation);
    }
    public void SetLabels(int LO, int step)
    {
        //string[] labelText = loTexts.GetLabelText(LO, step);
        //LabelManager.Instance.EnableLabelsByText(SearchingTextType.bottomText, labelText);
    }

    private void UpdateLOProgress(int LO, int step)
    {
        currentLO = LO;
        currentStep = step;
        loData.UpdateLOProgress(currentLO, currentStep);
    }

    private void ChangeInfoTextBasedOnLO(int LO, int step)
    {
        //List<string> foundText = loTexts.FindInfoText(LO, step);
        //if (foundText != null) {

        //    infoText.text = foundText[0];
        //    if (foundText[1] != "")
        //    {
        //        fitText.text = "Please fit the 3D pelvis with the 2D shape!\n" + foundText[1];
        //    }
        //    else
        //    {
        //        fitText.text = "Please fit the 3D pelvis with the 2D shape!";
        //    }

        //    if (infoText.gameObject.activeInHierarchy)
        //    {
        //        //force refreshing auto layout
        //        LayoutRebuilder.ForceRebuildLayoutImmediate(infoText.rectTransform);
        //    }
        //}
    }

    private void UpdateStepControls(int LO, int step)
    {
        GameObject backBttnGameObj = buttonBackward.gameObject;
        GameObject forwardBttnGameObj = buttonForward.gameObject;

        // when not on the intro of the first LO, show the back navigation button. Otherwise, hide it.
        bool showBackButton = step != LearningObjectives.INTRO_STEP || LO != 1;

        // when not on the last step of the last LO, show the forward navigation button. Otherwise, hide it.
        int lastLO = loData.GetNumberOfLearningObjectives();
        bool showForwardButton = LO != lastLO || step != loData.GetNumberOfSteps(lastLO);

        backBttnGameObj.SetActive(showBackButton);
        forwardBttnGameObj.SetActive(showForwardButton);

        // Make sure the step's button has the pressed down graphic
        PressDownStepButton(step, currentStep);
    }

    private void SaveProgress()
    {
        if (currentStep == LearningObjectives.INTRO_STEP)
        {
            // have achieved no additional progress since last save if only on the introductory step
            return;
        }
        loData.AchieveLOStep(currentLO, currentStep);
    }

    // TODO: need a better way to show all done panel
    private void DisplayFinishMessage()
    {
        int numLOs = loData.GetNumberOfLearningObjectives();
        for (int loIndex = 0; loIndex < numLOs; loIndex++)
        {
            int learningObjective = loIndex + 1;
            int numSteps = loData.GetNumberOfSteps(learningObjective);
            for (int stepInd = 0; stepInd < numSteps; stepInd++)
            {
                int step = stepInd + 1;
                if (loData.HaveAchievedStep(learningObjective, step))
                {
                    PanelManager.Instance.ShowPanel(PanelType.WellDone);
                    return;
                }
            }
        }
        PanelManager.Instance.ShowPanel(PanelType.AllDone);
    }

    public void ChangeCurrentProgress(Progress progress)
    {
        currentProgress = progress;
        if (progress == Progress.win)
        {
            SaveProgress();
        }

    }

    private void DisplayWinMessage(Progress progress)
    {
        if (progress == Progress.win)
        {
            StartCoroutine(WinMessage());
        }
        else if (progress == Progress.inProgress)
        {
            StopCoroutine(WinMessage());
            DisplayLOContent();
        }
        else
        {
            StopCoroutine(WinMessage());
        }
    }

    private int GetStepButtonIndex(int step)
    {
        // since stepButton array's indexes are 0-based, the index will be one less than the step number
        return step - 1;
    }
}
*/
