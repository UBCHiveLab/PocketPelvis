using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum StepControl
{
    Backward,
    Forward
}

public class LoNavigator : MonoBehaviour
{
    // singeleton instance
    public static LoNavigator instance;

    public enum progress { notStarted, inProgress, win };
    public progress currentProgress;

    public Text buttonTextV, buttonTextH;

    // public delegate classes
    public delegate void setCurrentLODelegate(int LO, int step);
    public static event setCurrentLODelegate setCurrentLO;
    public delegate void displayLOUIDelegate();
    public static displayLOUIDelegate displayLOUI;
    public delegate void finishCurrentLODelegate();
    public static finishCurrentLODelegate finishCurrentLO;

    // private variable
    private bool watchedTutorial;
    [SerializeField]
    private Text introductionText, infoText, fitText;
    [SerializeField]
    private Button buttonForward, buttonBackward;
    [SerializeField]
    private GameObject stepButtons;
    
    private LoTexts loTexts;
    private Button[] buttons;
    private int currentLO, currentStep;

    const int INTRO_STEP = 0;

    private void Start()
    {
        instance = this;
        if (LearningObjectives.instance.learningObject.isNewUser)
        {
            buttonTextV.text = "START LEARNING";
            buttonTextH.text = "START LEARNING";
            watchedTutorial = false;
        }
        else
        {
            buttonTextV.text = "RESUME LEARNING";
            buttonTextH.text = "RESUME LEARNING";
            watchedTutorial = true;
        }
        setCurrentLO += saveCurrentLO;
        setCurrentLO += ChangeInfoTextBasedOnLO;
        setCurrentLO += ButtonDisplayBasedOnLO;
        setCurrentLO += resetProgress;
        displayLOUI += DisplayLOContent;
        displayLOUI += DisplayStepButtons;

        finishCurrentLO += HideAllPanels;
        finishCurrentLO += saveProgress;
        finishCurrentLO += displayFinishMessage;
        LoadInfoText();
        currentProgress = progress.notStarted;

        // set listeners for the buttons that enable navigation through the LOs
        buttonBackward.onClick.AddListener(() => GoToNextStep(StepControl.Backward));
        buttonForward.onClick.AddListener(() => GoToNextStep(StepControl.Forward));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.L) && currentStep != INTRO_STEP)
        {
            finishCurrentLO();
        }
    }
    public void TutorialWatched()
    {
        watchedTutorial = true;
    }
    private void OnDisable()
    {
        setCurrentLO -= saveCurrentLO;
        setCurrentLO -= ChangeInfoTextBasedOnLO;
        setCurrentLO -= ButtonDisplayBasedOnLO;
        setCurrentLO -= resetProgress;
        displayLOUI -= DisplayLOContent;
        displayLOUI -= DisplayStepButtons;
        finishCurrentLO -= HideAllPanels;
        finishCurrentLO -= saveProgress;
        finishCurrentLO -= displayFinishMessage;
    }
    public void StarButtonOnClick(string array)
    {
        string[] splitArray = array.Split(char.Parse("-"));
        int LO = int.Parse(splitArray[0]);
        int step = int.Parse(splitArray[1]);

        //update data
        setCurrentLO(LO, step);

        if (LearningObjectives.instance.learningObject.isNewUser)
        {
            DisplayTutorialPage();
        } else
        {
            PageManager.Instance.MakePageActive(PageType.Main);
            displayLOUI();
        }
    }
    public void LearningButton()
    {;
        if (LearningObjectives.instance.learningObject.isNewUser)
        {
            setCurrentLO(1, 1);
            DisplayTutorialPage();
        }
        else
        {
            setCurrentLO(
                LearningObjectives.instance.learningObject.lastLO,
                LearningObjectives.instance.learningObject.lastStep
            );
            displayLOUI();
        }
    }

    private void DisplayTutorialPage()
    {
        // prevent panels from obstructing the tutorial page view
        PanelManager.Instance.HideAllPanels();

        LearningObjectives.instance.learningObject.isNewUser = false;
        LearningObjectives.instance.SaveLOs();
        PageManager.Instance.MakePageActive(PageType.Tutorial);
    }

    /// <summary>
    ///  Reset all user record
    /// </summary>
    public void ResetUser()
    {
        LearningObjectives.instance.ResetLOs();
        buttonTextV.text = "START LEARNING";
        buttonTextH.text = "START LEARNING";
        watchedTutorial = false;
    }
    public void DisplayLOIntroduction()
    {
        stepButtons.SetActive(false);

        // set the introduction text for the lo's intro and make the intro panel visible
        introductionText.text = loTexts.GetIntroductionForLO(currentLO);
        PanelManager.Instance.ShowPanel(PanelType.Introduction);
    }

    public void DisplayLOContent()
    {
        PageManager.Instance.MakePageActive(PageType.Main);
        PanelManager.Instance.ShowPanel(PanelType.Fit);
    }
    public void DisplayStepButtons()
    {
        //int LO = LearningObjectives.instance.learningObject.lastLO;
        //int step = LearningObjectives.instance.learningObject.lastStep;
        int count = LearningObjectives.instance.learningObject.learningObjects[currentLO - 1]
            .learningObjectAchievement.Count;
        
        if (stepButtons != null)
        {
            // looking throuhg all the step buttons and enable gameobjects based on number of steps it has for each LO
            foreach (Transform loUI in stepButtons.transform)
            {
                if (count > 0)
                {
                    loUI.gameObject.SetActive(true);
                    count--;
                }
                else
                {
                    loUI.gameObject.SetActive(false);
                }

            }
            buttons = stepButtons.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
            if(currentStep != INTRO_STEP)
            buttons[currentStep - 1].interactable = false;
        }

        if (!stepButtons.activeSelf)
        {
            stepButtons.SetActive(true);
        }
    }
    public void PressDownStepButton(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        clickedButton.interactable = false;
    }

    public void OnClickStepButton(Button clickedButton)
    {
        // show the pressed down graphic and go to that button's step
        PressDownStepButton(clickedButton);

        // since arrays are 0-base indexed, the step of the clicked buttton will be the index of the button plus 1
        int step = System.Array.IndexOf(buttons, clickedButton) + 1;
        setCurrentLO(currentLO, step);
    }

    public void GoToNextStep(StepControl control)
    {
        if (control == StepControl.Forward)
        {
            if (currentStep == INTRO_STEP)
            {
                // if we are on the introduction step, then go to the next step in the current LO and display the LO content
                setCurrentLO(currentLO, currentStep + 1);
                displayLOUI();
            }
            else if (buttons.Length > currentStep)
            {
                // if there are still steps that we haven't gone to in the current LO, go to the next step
                PressDownStepButton(buttons[currentStep]);
                setCurrentLO(currentLO, currentStep + 1);
            }
            else if (currentLO < LearningObjectives.instance.learningObject.learningObjects.Count)
            {
                // otherwise, if there is a LO after the current LO, go to the introduction of the next LO
                setCurrentLO(currentLO + 1, INTRO_STEP);
                DisplayLOIntroduction();
            }
        }
        else if (control == StepControl.Backward)
        {
            int prevStep = currentStep - 1;
            if (prevStep == INTRO_STEP)
            {
                // if the previous step is the current LO's introduction, set that step to the current step and display the introduction
                setCurrentLO(currentLO, prevStep);
                DisplayLOIntroduction();
            } else if (prevStep > INTRO_STEP && buttons.Length > prevStep)
            {
                // the previous step is a step in the current LO, so go to that step
                PressDownStepButton(buttons[prevStep - 1]);
                setCurrentLO(currentLO, prevStep);
            }
            else if (currentLO > 1)
            {
                // otherwise, we have seen all the steps in the current LO, so go back to the last step in the previous LO, if possible
                setCurrentLO(currentLO - 1, LearningObjectives.instance.learningObject.learningObjects[currentLO - 2].learningObjectAchievement.Count);
                displayLOUI();
            }
        }
    }
    private void LoadInfoText()
    {
        string load;
        string jsonSavePath = Application.dataPath + "/SaveData/LOText.json";
        if (System.IO.File.Exists(jsonSavePath))
        {
            load = System.IO.File.ReadAllText(jsonSavePath);
        }
        else
        {
            load = System.IO.File.ReadAllText(Application.dataPath + "/SaveData/emptyData.json");
        }

        loTexts = JsonUtility.FromJson<LoTexts>(load);
    }

    public void saveCurrentLO(int LO, int step)
    {
        currentLO = LO;
        currentStep = step;
        LearningObjectives.instance.learningObject.lastLO = LO;
        LearningObjectives.instance.learningObject.lastStep = step;
        LearningObjectives.instance.SaveLOs();
    }
    public void ChangeInfoTextBasedOnLO(int LO, int step)
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
    public void ButtonDisplayBasedOnLO(int LO, int step)
    {
        GameObject backBttnGameObj = buttonBackward.gameObject;
        GameObject forwardBttnGameObj = buttonForward.gameObject;

        if (LO == 1 && step == INTRO_STEP)
        {
            backBttnGameObj.SetActive(false);
        }
        else if (LO == 10 && step == 3)
        {
            forwardBttnGameObj.SetActive(false);
        }
        else
        {
            if (backBttnGameObj.activeSelf || forwardBttnGameObj.activeSelf)
            {
                backBttnGameObj.SetActive(true);
                forwardBttnGameObj.SetActive(true);
            }
        }
    }
    public void resetProgress(int LO, int step)
    {
        currentProgress = progress.inProgress;
    }
   public void HideAllPanels()
    {
        PanelManager.Instance.HideAllPanels();
    }
    public void saveProgress()
    {
        if (currentStep == INTRO_STEP)
        {
            // have achieved no additional progress since last save if only on the introductory step
            return;
        }
        LearningObjectives.instance.learningObject.learningObjects[currentLO - 1].learningObjectAchievement[currentStep - 1] = true;
        LearningObjectives.instance.SaveLOs();
    }
    public void displayFinishMessage()
    {
        foreach (LOs lo in LearningObjectives.instance.learningObject.learningObjects)
        {
            
            foreach(bool isFinished in lo.learningObjectAchievement)
            {
                if (!isFinished)
                {
                    PanelManager.Instance.ShowPanel(PanelType.WellDone);
                    return;
                }
            }
        }
        PanelManager.Instance.ShowPanel(PanelType.AllDone);
    }
    
}
