using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainPageButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button backButton, forwardButton, infoButton, labelButton;
    [SerializeField]
    private Text startButtonTextV, startButtonTextH;
    [SerializeField]
    private GameObject stepButtonContainer;

    private ButtonInteractivityController interactivityController;
    private LearningObjectives loData;
    private List<Button> stepButtons;

    private const string START_LEARNING_TEXT = "START LEARNING";
    private const string RESUME_LEARNING_TEXT = "RESUME LEARNING";

    // Start is called before the first frame update
    private void Start()
    {

        loData = LearningObjectives.instance;
        stepButtons = stepButtonContainer.GetComponentsInChildren<Button>(true).ToList();
        interactivityController.GetComponent<ButtonInteractivityController>();

        startButtonTextH.text = loData.IsNewUser() ? START_LEARNING_TEXT : RESUME_LEARNING_TEXT;
        startButtonTextV.text = loData.IsNewUser() ? START_LEARNING_TEXT : RESUME_LEARNING_TEXT;

        interactivityController.DisableButton(infoButton, infoButton.GetComponent<Image>());
        interactivityController.DisableButton(labelButton, labelButton.GetComponent<Image>());

        LoNavigator.setCurrentLO += UpdateStepControls;
        LoNavigator.displayLOUI += DisplayStepButtons;
        LoNavigator.SetProgress += UpdateControlsWithProgress;
        LoNavigator.SetProgress += DisplayWinMessage;

        // set listeners for the buttons that enable navigation through the LOs
        backButton.onClick.AddListener(() => LoNavigator.instance.GoToNextStep(StepControl.Backward));
        forwardButton.onClick.AddListener(() => LoNavigator.instance.GoToNextStep(StepControl.Forward));
    }

    private void OnDisable()
    {
        LoNavigator.setCurrentLO -= UpdateStepControls;
        LoNavigator.displayLOUI -= DisplayStepButtons;
        LoNavigator.SetProgress -= UpdateControlsWithProgress;
        LoNavigator.SetProgress -= DisplayWinMessage;
        StopAllCoroutines();
    }

    public void OnClickStepButton(Button clickedButton)
    {
        // since arrays are 0-base indexed, the step of the clicked buttton will be the index of the button plus 1
        int step = stepButtons.IndexOf(clickedButton) + 1;
        loData.UpdateLOProgress(loData.GetCurrentLearningObjective(), step);
    }

    public void OnClickResetUser()
    {
        loData.ResetLOs();
        startButtonTextV.text = START_LEARNING_TEXT;
        startButtonTextH.text = START_LEARNING_TEXT;
    }

    private void PressDownStepButton(int step, int prevStep)
    {
        if (step == LearningObjectives.INTRO_STEP)
        {
            // there's no step buttons to press down in the introduction step
            return;
        }

        int stepIndex = GetStepButtonIndex(step);

        if (prevStep != LearningObjectives.INTRO_STEP)
        {
            // stop pressing down on the previous step button
            int prevStepIndex = GetStepButtonIndex(prevStep);
            interactivityController.EnableButton(stepButtons[prevStepIndex]);
        }

        // make sure that the current step button looks like it is interactable
        interactivityController.EnableButton(stepButtons[stepIndex], stepButtons[stepIndex].GetComponent<Image>());
        // give the button the pressed down graphic
        interactivityController.DisableButton(stepButtons[stepIndex]);
    }

    private void UpdateStepControls(int LO, int step)
    {
        GameObject backBttnGameObj = backButton.gameObject;
        GameObject forwardBttnGameObj = forwardButton.gameObject;

        // when not on the intro of the first LO, show the back navigation button. Otherwise, hide it.
        bool showBackButton = step != LearningObjectives.INTRO_STEP || LO != 1;

        // when not on the last step of the last LO, show the forward navigation button. Otherwise, hide it.
        int lastLO = loData.GetNumberOfLearningObjectives();
        bool showForwardButton = LO != lastLO || step != loData.GetNumberOfSteps(lastLO);

        backBttnGameObj.SetActive(showBackButton);
        forwardBttnGameObj.SetActive(showForwardButton);

        // Make sure the step's button has the pressed down graphic
        PressDownStepButton(step, loData.GetCurrentStep());
    }

    private void UpdateControlsWithProgress(Progress progress)
    {
        if (progress == Progress.win)
        {
            // allow the info and label buttons to be interacted with when the pelvis is being tracked
            interactivityController.EnableButton(infoButton, infoButton.GetComponent<Image>());
            interactivityController.EnableButton(labelButton, labelButton.GetComponent<Image>());

        }
        else
        {
            // otherwise, disable the info and label buttons
            interactivityController.DisableButton(infoButton, infoButton.GetComponent<Image>());
            interactivityController.DisableButton(labelButton, labelButton.GetComponent<Image>());
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

        int currentLO = loData.GetCurrentLearningObjective();
        int numStepsInLO = loData.GetNumberOfSteps(currentLO);

        for (int stepIndex = 0; stepIndex < stepButtons.Count; stepIndex++)
        {
            if (stepIndex < numStepsInLO)
            {
                // the step is in the lo. Make that step's button visible
                stepButtons[stepIndex].gameObject.SetActive(true);

                if (stepIndex == GetStepButtonIndex(loData.GetCurrentStep()))
                {
                    // this step is the current step, which has the pressed down graphic applied. Thus, nothing needs to be done
                    continue;
                }
                else if (loData.HaveBeenToStep(currentLO, stepIndex + 1))
                {
                    // We've never been to this step before. So, make this step's button interactable
                    interactivityController.EnableButton(stepButtons[stepIndex], stepButtons[stepIndex].GetComponent<Image>());
                }
                else
                {
                    // we've never been to this step before. So, make the this step's button non-interactable
                    interactivityController.DisableButton(stepButtons[stepIndex], stepButtons[stepIndex].GetComponent<Image>());
                }
            }
            else
            {
                // the step is not in the lo. Hide the button
                stepButtons[stepIndex].gameObject.SetActive(false);
            }
        }
    }

    private int GetStepButtonIndex(int step)
    {
        // since stepButton array's indexes are 0-based, the index will be one less than the step number
        return step - 1;
    }

    public void DisplayWinMessage(Progress progress)
    {
        if (progress == Progress.win)
        {
            StartCoroutine(WinMessage());
        }
        else if (progress == Progress.inProgress)
        {
            StopCoroutine(WinMessage());
            PanelManager.Instance.ShowPanel(PanelType.Fit);
        }
        else
        {
            StopCoroutine(WinMessage());
        }
    }
    IEnumerator WinMessage()
    {
        PanelManager.Instance.ShowPanel(PanelType.WellDone);
        //display win panel and close it after 1 second
        yield return new WaitForSeconds(1f);
        PanelManager.Instance.ShowPanel(PanelType.Info);
    }

}