using System.Collections;
using System.Collections.Generic;
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

    #region VARIABLES
    public Progress currentProgress;

    // private variable
    [SerializeField]
    private Text introductionText, infoText, fitText;

    private LearningObjectives loData;
    private LoTexts loTexts;
    private int currentLO, currentStep;

    const int INTRO_STEP = 0;
    #endregion
    #region DELEGATE_METHODS
    // public delegate classes
    public delegate void setCurrentLODelegate(int LO, int step);
    public static event setCurrentLODelegate setCurrentLO;
    public delegate void displayLOUIDelegate();
    public static displayLOUIDelegate displayLOUI;
    //public delegate void finishCurrentLODelegate();
    //public static finishCurrentLODelegate finishCurrentLO;
    public delegate void SetProgressDelegate(Progress progress);
    public static SetProgressDelegate SetProgress;
    #endregion

    private void Start()
    {
        instance = this;
        loData = LearningObjectives.instance;

        #region SUBSCRIBE_DELEGATE_METHODS
        setCurrentLO += ChangeInfoTextBasedOnLO;
        setCurrentLO += UpdateLOProgress;
        setCurrentLO += SetCurrentGuideView;
        displayLOUI += DisplayLOContent;
        SetProgress += ChangeCurrentProgress;
        #endregion
        LoadInfoText();
        SetProgress(Progress.notStarted);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L) && currentStep != LearningObjectives.INTRO_STEP)
        {
            //finishCurrentLO();
        }
    }

    private void OnDisable()
    {
        #region DESUBSCRIBE_DELEGATE_METHODS
        // setCurrentLO -= saveCurrentLO;
        // setCurrentLO -= ChangeInfoTextBasedOnLO;
        // setCurrentLO -= ButtonDisplayBasedOnLO;

        // displayLOUI -= DisplayLOContent;
        // displayLOUI -= DisplayStepButtons;


        setCurrentLO -= ChangeInfoTextBasedOnLO;

        setCurrentLO -= UpdateLOProgress;
        setCurrentLO -= SetCurrentGuideView;
        displayLOUI -= DisplayLOContent;
        SetProgress -= ChangeCurrentProgress;
        // finishCurrentLO -= HideAllPanels;
        // finishCurrentLO -= SaveProgress;
        // finishCurrentLO -= DisplayFinishMessage;
        #endregion
    }

    public void OnClickStarButton(string array)
    {
        string[] splitArray = array.Split(char.Parse("-"));
        int LO = int.Parse(splitArray[0]);
        int step = int.Parse(splitArray[1]);

        //update data
        setCurrentLO(LO, step);

        if (loData.IsNewUser())
        {
            DisplayTutorialPage();
        }
        else
        {
            displayLOUI();
        }
    }

    public void LearningButton()
    {
        if (loData.IsNewUser())
        {
            // if user is new, show the tutorial; put the user on the first step
            // of the first learning objective
            setCurrentLO(1, 1);
            DisplayTutorialPage();
        }
        else
        {
            // set the user's progress to the step and LO they were previously at, unless
            // was last at the introduction. Then, go to the first step.
            int lastStep = loData.GetCurrentStep();
            int stepToGoTo = lastStep == LearningObjectives.INTRO_STEP ? 1 : lastStep;
            setCurrentLO(
                loData.GetCurrentLearningObjective(),
                stepToGoTo
            );

            displayLOUI();
        }
        SetProgress(Progress.inProgress);
    }

    private void DisplayTutorialPage()
    {
        // prevent panels from obstructing the tutorial page view
        PanelManager.Instance.HideAllPanels();
        PageManager.Instance.MakePageActive(PageType.Tutorial);
    }

    private void DisplayLOIntroduction()
    {
        SetProgress(Progress.notStarted);

        // stepButtonContainer.SetActive(false);

        // set the introduction text for the lo's intro and make the intro panel visible
        introductionText.text = loTexts.GetIntroductionForLO(currentLO);
        PanelManager.Instance.ShowPanel(PanelType.Introduction);
    }

    private void DisplayLOContent()
    {
        PageManager.Instance.MakePageActive(PageType.Main);
        PanelManager.Instance.ShowPanel(PanelType.Fit);
    }

    public void GoToNextStep(StepControl control)
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

        if (load != null)
            loTexts = JsonUtility.FromJson<LoTexts>(load.text);
    }
    public void SetCurrentGuideView(int LO, int step)
    {
        GuideViewOrientation foundOrientation = loTexts.GetGuideViewOrientation(LO, step);
        ModelTrackingManager.Instance.SetGuideView(foundOrientation);
    }

    private void UpdateLOProgress(int LO, int step)
    {
        currentLO = LO;
        currentStep = step;
        loData.UpdateLOProgress(currentLO, currentStep);
    }

    private void ChangeInfoTextBasedOnLO(int LO, int step)
    {
        List<string> foundText = loTexts.FindInfoText(LO, step);
        //Debug.Log(foundText);
        if (foundText != null) {

            infoText.text = foundText[0];
            if (foundText[1] != "")
            {
                fitText.text = "Please fit the 3D pelvis with the 2D shape!\n" + foundText[1];
            }
            else
            {
                fitText.text = "Please fit the 3D pelvis with the 2D shape!";
            }

            if (infoText.gameObject.activeInHierarchy)
            {
                //force refreshing auto layout
                LayoutRebuilder.ForceRebuildLayoutImmediate(infoText.rectTransform);
            }
        }
    }

   private void HideAllPanels()
    {
        PanelManager.Instance.HideAllPanels();
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
    // needs a better way to show all done panel
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
}
