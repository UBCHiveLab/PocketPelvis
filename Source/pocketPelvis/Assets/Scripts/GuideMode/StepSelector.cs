using UnityEngine;

public class StepSelector : AbstractNavigationButtonBehaviour
{
    [SerializeField]
    private int selectedLearningObjective;
    [SerializeField]
    private int selectedStep;

    protected override void OnClickButton()
    {
        GoToStep(selectedLearningObjective, selectedStep);
    }
}
