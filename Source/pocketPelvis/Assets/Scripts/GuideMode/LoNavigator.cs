using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LoNavigator : MonoBehaviour
{
    // singeleton instance
    public static LoNavigator instance;

    public enum progress { notStarted, inProgress, win };
    public progress currentProgress;

    public GameObject tutorialPage;
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
    private GameObject buttonForward, buttonBackward;
    [SerializeField]
    private GameObject panelWellDone,panelAlldone,panelFit,panelIntro;
    
    private LoTexts loTexts;
    private GameObject stepButtons;
    private Button[] buttons;
    private int currentLO, currentStep;
    private GameObject uiGroup, panelGroup;

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
        //setCurrentLO += DisplayFitPanel;

        displayLOUI += HideAllPanel;
        displayLOUI += DisplayLOIntroduction;
        displayLOUI += DisplayStepButtons;

        finishCurrentLO += HideAllPanel;
        finishCurrentLO += saveProgress;
        finishCurrentLO += displayFinishMessage;
        LoadInfoText();
        currentProgress = progress.notStarted;
        uiGroup = GameObject.Find("LearningObjectives");
        panelGroup= GameObject.Find("Panels");
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
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
        displayLOUI -= HideAllPanel;
        displayLOUI -= DisplayLOIntroduction;
        displayLOUI -= DisplayStepButtons;
        finishCurrentLO -= HideAllPanel;
        finishCurrentLO -= saveProgress;
        finishCurrentLO -= displayFinishMessage;
    }
    public void StarButtonOnClick(string array)
    {
        string[] splitArray = array.Split(char.Parse("-"));
        int LO = int.Parse(splitArray[0]);
        int step = int.Parse(splitArray[1]);
        //update data

        if (LearningObjectives.instance.learningObject.isNewUser)
        {
            LearningObjectives.instance.learningObject.isNewUser = false;
            LearningObjectives.instance.SaveLOs();
            tutorialPage.SetActive(true);
        }
        setCurrentLO(LO, step);
        displayLOUI();

    }
    public void LearningButton()
    {
        Debug.Log("working");
        if (LearningObjectives.instance.learningObject.isNewUser)
        {
            setCurrentLO(1, 1);
            LearningObjectives.instance.learningObject.isNewUser = false;
            LearningObjectives.instance.SaveLOs();
            tutorialPage.SetActive(true);
            //StarButtonOnClick("1-1");
        }
        else
        {
            /*int LO = LearningObjectives.instance.learningObject.lastLO;
            int step = LearningObjectives.instance.learningObject.lastStep;
            StarButtonOnClick(LO.ToString() + "-" + step.ToString());*/
            setCurrentLO(LearningObjectives.instance.learningObject.lastLO, LearningObjectives.instance.learningObject.lastStep);

        }
        displayLOUI();
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
        // set the introduction text for the lo's intro and make the intro panel visible
        introductionText.text = loTexts.GetIntroductionForLO(currentLO);
        panelIntro.SetActive(true);   
    }
    public void HideAllPanel()
    {
        foreach (Transform panel in panelGroup.transform)
        {
            panel.gameObject.SetActive(false);
        }
    }
    public void DisplayFitPanel()
    {
        foreach(Transform introPanel in uiGroup.transform)
        {
            if (introPanel.gameObject.activeSelf)
            {
                return;
            }
        }
        if(panelFit!=null)
        panelFit.SetActive(true);

    }
    public void DisplayStepButtons()
    {
        stepButtons = GameObject.Find("StepButtons");
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
            buttons[currentStep - 1].interactable = false;
        }

    }
    public void StepButtonPressDown(Button clickedButton)
    {
        //buttons = stepButtons.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);
        //LearningObjectives.instance.learningObject.lastStep = buttonIndex + 1;
        //LearningObjectives.instance.SaveLOs();
        setCurrentLO(LearningObjectives.instance.learningObject.lastLO, buttonIndex + 1);
        clickedButton.interactable = false;
        HideAllPanel();
        DisplayFitPanel();
    }
    /// <summary>
    /// + for going to previous lo step
    /// - for going to next lo step
    /// </summary>
    /// <param name="control"></param>
    public void StepsControl(string control)
    {
        
        if (control == "+")
        {
            if (buttons.Length > currentStep)
            {
                StepButtonPressDown(buttons[currentStep]);
                
            }
            else
            {
                if (currentLO < LearningObjectives.instance.learningObject.learningObjects.Count)
                {
                    //if 
                    setCurrentLO(currentLO + 1, 1);
                    displayLOUI();
                }
            }

        }
        else if (control == "-")
        {
            if (currentStep - 2 >= 0)
            {
                StepButtonPressDown(buttons[currentStep - 2]);
                
            }
            else
            {
                if (currentLO > 1)
                {
                    setCurrentLO(currentLO - 1, LearningObjectives.instance.learningObject.learningObjects[currentLO - 2].learningObjectAchievement.Count);
                    displayLOUI();
                }
            }

        }
        //HideAllPanel();
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
        if (LO == 1 && step == 1)
        {
            buttonBackward.SetActive(false);
        }
        else if (LO == 10 && step == 3)
        {
            buttonForward.SetActive(false);
        }
        else
        {
            if (buttonBackward.activeSelf || buttonForward.activeSelf)
            {
                buttonBackward.SetActive(true);
                buttonForward.SetActive(true);
            }
        }
    }
    public void resetProgress(int LO, int step)
    {
        currentProgress = progress.inProgress;
    }
   
    public void saveProgress()
    {
        LearningObjectives.instance.learningObject.learningObjects[currentLO - 1].learningObjectAchievement[currentStep - 1] = true;
        LearningObjectives.instance.SaveLOs();
    }
    public void displayFinishMessage()
    {
        //HideAllPanel();
        foreach (LOs lo in LearningObjectives.instance.learningObject.learningObjects)
        {
            
            foreach(bool isFinished in lo.learningObjectAchievement)
            {
                if (!isFinished)
                {
                    if(panelWellDone!=null)
                    panelWellDone.SetActive(true);
                    return;
                }
            }
        }
        if (panelAlldone != null)
            panelAlldone.SetActive(true);
    }
    
}
