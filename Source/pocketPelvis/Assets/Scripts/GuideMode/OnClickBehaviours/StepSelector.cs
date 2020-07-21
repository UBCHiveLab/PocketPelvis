using UnityEngine;

[RequireComponent(typeof(StepProperties))]
public class StepSelector : AbstractOnClickButtonBehaviour
{
    private int selectedLearningObjective;
    private int selectedStep;

    protected override void Awake()
    {
        base.Awake();
        StepProperties stepProperties = GetComponent<StepProperties>();
        selectedLearningObjective = stepProperties.GetLearningObjective();
        selectedStep = stepProperties.GetStep();
    }

    protected override void OnClickButton()
    {
        if (selectedStep == saveDataManager.GetCurrentStep())
        {
            // if we have already selected this step, do not allow it to be selected again
            return;
        }

        // some steps aren't associated with any LO. In this case, get the current LO.
        int loToGoTo = selectedLearningObjective < SaveDataManager.FIRST_LO ? saveDataManager.GetCurrentLO() : selectedLearningObjective;

        saveDataManager.UpdateUserProgress(loToGoTo, selectedStep);
    }
}
