using UnityEngine;

enum StepControl
{
    Backward,
    Forward,
    Current
}

public class StepControlNavigator : AbstractOnClickButtonBehaviour
{
    [SerializeField]
    private StepControl buttonControl;

    protected override void OnClickButton()
    {
        int currentLO = saveDataManager.GetCurrentLO();
        int currentStep = saveDataManager.GetCurrentStep();

        int nextLO = currentLO;
        int nextStep = currentStep;

        if (buttonControl == StepControl.Backward)
        {
            if (currentStep == SaveDataManager.INTRO_STEP)
            {
                // if the user is currently on the intro step, then go to the last step of the previous lo
                nextLO--;
                nextStep = saveDataManager.GetNumStepsInLO(nextLO);
            }
            else
            {
                // go to the previous step in the current learning objective
                nextStep--;
            }
        }
        else if (buttonControl == StepControl.Forward)
        {
            if (currentStep == saveDataManager.GetNumStepsInLO(currentLO))
            {
                // if the user is currently on the last step of the current lo, go to the intro step of the next lo
                nextLO++;
                nextStep = SaveDataManager.INTRO_STEP;
            }
            else
            {
                // go to the next step in the current learning objective
                nextStep++;
            }
        }
        else
        {
           // if resuming the user's progress from the current lo and step, don't make the user see the intro step again. Instead, go to the first step of the lo
            nextStep = nextStep == SaveDataManager.INTRO_STEP ? nextStep + 1 : nextStep;
        }

        // when using the navigation buttons, we want to go to the main page and put the user on the lo and step that they navigated to
        PageManager.Instance.MakePageActive(PageType.Main);
        saveDataManager.UpdateUserProgress(nextLO, nextStep);
    }
}
