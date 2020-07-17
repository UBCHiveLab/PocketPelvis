using UnityEngine;

public class StepSelector : AbstractOnClickButtonBehaviour
{
    [SerializeField]
    protected int selectedStep = SaveDataManager.INTRO_STEP;

    protected override void OnClickButton()
    {
        if (selectedStep == saveDataManager.GetCurrentStep())
        {
            // if we have already selected this step, do not allow it to be selected again
            return;
        }

        saveDataManager.UpdateUserProgress(saveDataManager.GetCurrentLO(), selectedStep);
    }
}
