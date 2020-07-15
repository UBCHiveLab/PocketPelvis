using UnityEngine;

public class StepSelector : AbstractOnClickButtonBehaviour
{
    [SerializeField]
    private int selectedLearningObjective = SaveDataManager.FIRST_LO;
    [SerializeField]
    private int selectedStep = SaveDataManager.INTRO_STEP;

    protected override void OnClickButton()
    {
        if (selectedLearningObjective < SaveDataManager.FIRST_LO)
        {
            // if an invalid learning objective is specified, make the selected lo the current lo
            selectedLearningObjective = saveDataManager.GetCurrentLO();
        }

        saveDataManager.UpdateUserProgress(selectedLearningObjective, selectedStep);
    }
}
