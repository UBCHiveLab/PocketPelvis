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
                nextLO = --currentLO;
                nextStep = saveDataManager.GetNumStepsInLO(nextLO);
            } else
            {
                // go to the previous step in the current learning objective
                nextStep = --currentStep;
            }
        } else if (buttonControl == StepControl.Forward)
        {
            if (currentStep == saveDataManager.GetNumStepsInLO(currentLO))
            {
                // if the user is currently on the last step of the current lo, go to the intro step of the next lo
                nextLO = ++currentLO;
                nextStep = SaveDataManager.INTRO_STEP;
            } else
            {
                // go to the next step in the current learning objective
                nextStep = ++currentStep;
            }
        }

        saveDataManager.UpdateUserProgress(nextLO, nextStep);
    }
}
