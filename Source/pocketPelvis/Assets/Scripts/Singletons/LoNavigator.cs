using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LoNavigator : MonoBehaviour
{
    public Text buttonTextV,buttonTextH;
    private GameObject stepButtons;
    private Button[] buttons;
    public static LoNavigator instance;
    public GameObject tutorialPage;
    public delegate void setCurrentLODelegate(int LO, int step);
    public static event setCurrentLODelegate setCurrentLO;
    public delegate void displayLOUIDelegate ();
    public static displayLOUIDelegate displayLOUI;
    private bool watchedTutorial;
    [SerializeField]
    private Text infoText,fitText;
    [SerializeField]
    private GameObject buttonForward, buttonBackward;
    private InfoTexts infoTexts;

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
        displayLOUI += DisplayLoInfo;
        displayLOUI += DisplayStepButtons;
        LoadInfoText();
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
        displayLOUI -= DisplayLoInfo;
        displayLOUI -= DisplayStepButtons;
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
        if (LearningObjectives.instance.learningObject.isNewUser)
        {
            setCurrentLO(1, 1);
            LearningObjectives.instance.learningObject.isNewUser = false;
            LearningObjectives.instance.SaveLOs();
        }
        else
        {
            setCurrentLO(LearningObjectives.instance.learningObject.lastLO, LearningObjectives.instance.learningObject.lastStep);
        }
    }
    public void ResetUser()
    {
        LearningObjectives.instance.ResetLOs();
        buttonTextV.text = "START LEARNING";
        buttonTextH.text = "START LEARNING";
        watchedTutorial = false;
    }
    public void DisplayLoInfo()
    {
        GameObject uiGroup = GameObject.Find("LearningObjectives");
        foreach(Transform loUI in uiGroup.transform)
        {
            loUI.gameObject.SetActive(false);
        }
        if(watchedTutorial)
        uiGroup.transform.GetChild(LearningObjectives.instance.learningObject.lastLO - 1)
            .gameObject.SetActive(true);
    }
    public void DisplayStepButtons()
    {
        stepButtons = GameObject.Find("StepButtons");
        int LO = LearningObjectives.instance.learningObject.lastLO;
        int step = LearningObjectives.instance.learningObject.lastStep;
        int count = LearningObjectives.instance.learningObject.learningObjects[LO-1]
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
            buttons[step - 1].interactable = false;
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
    }
    /// <summary>
    /// + for going to previous lo step
    /// - for going to next lo step
    /// </summary>
    /// <param name="control"></param>
    public void StepsControl(string control)
    {
        int LO = LearningObjectives.instance.learningObject.lastLO;
        int step = LearningObjectives.instance.learningObject.lastStep;
        if (control == "+")
        {
            if (buttons.Length > step)
            {
                StepButtonPressDown(buttons[step]);
            }
            else
            {
                if(LO < LearningObjectives.instance.learningObject.learningObjects.Count)
                {
                    //if 
                    setCurrentLO(LO+1, 1);
                    displayLOUI();
                }
            }
            
        }
        else if (control == "-")
        {
            if (step - 2 >= 0)
            {
                StepButtonPressDown(buttons[step - 2]);
            }
            else
            {
                if (LO > 1)
                {
                    setCurrentLO(LO - 1, LearningObjectives.instance.learningObject.learningObjects[LO-2].learningObjectAchievement.Count);
                    displayLOUI();
                }
            }
            
        }
    }
    private void LoadInfoText()
    {
        string load;
        string jsonSavePath = Application.dataPath + "/SaveData/LOInfoText.json";
        if (System.IO.File.Exists(jsonSavePath))
        {
            load = System.IO.File.ReadAllText(jsonSavePath);
        }
        else
        {
            load = System.IO.File.ReadAllText(Application.dataPath + "/SaveData/emptyData.json");
        }

        infoTexts = JsonUtility.FromJson<InfoTexts>(load);
    }
    public void saveCurrentLO(int LO,int step)
    {
        LearningObjectives.instance.learningObject.lastLO = LO;
        LearningObjectives.instance.learningObject.lastStep = step;
        LearningObjectives.instance.SaveLOs();
    }
    public void ChangeInfoTextBasedOnLO(int LO, int step)
    {
        List<string> foundText = infoTexts.FindText(LO, step);
        //Debug.Log(foundText);
        if (foundText!=null){
            
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
        else if(LO==10 &&step == 3)
        {
            buttonForward.SetActive(false);
        }
        else
        {
            if(buttonBackward.activeSelf|| buttonForward.activeSelf)
            {
                buttonBackward.SetActive(true);
                buttonForward.SetActive(true);
            }
        }
    }
}
