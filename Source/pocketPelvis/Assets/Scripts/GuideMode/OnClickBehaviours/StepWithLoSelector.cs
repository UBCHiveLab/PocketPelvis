using UnityEngine;

public class StepWithLoSelector : StepSelector
{
    [SerializeField] 
    private int selectedLO = SaveDataManager.FIRST_LO;

    protected override void OnClickButton()
    {
        saveDataManager.UpdateUserProgress(selectedLO, selectedStep);
    }
}
