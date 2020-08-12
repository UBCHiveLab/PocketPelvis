using UnityEngine;

[RequireComponent(typeof(StepProperties))]
public class StepSelector : AbstractOnClickButtonBehaviour
{
    private PageManager pageManager;
    private int selectedLearningObjective;
    private int selectedStep;

    protected override void Awake()
    {
        base.Awake();
        pageManager = PageManager.Instance;

        StepProperties stepProperties = GetComponent<StepProperties>();
        selectedLearningObjective = stepProperties.GetLearningObjective();
        selectedStep = stepProperties.GetStep();
    }

    protected override void OnClickButton()
    {
        // some steps aren't associated with any LO. In this case, get the current LO.
        int loToGoTo = selectedLearningObjective < SaveDataManager.FIRST_LO ? saveDataManager.GetCurrentLO() : selectedLearningObjective;

        // when selecting a step, we want to go to the main page and put the user on the selected step
        pageManager.MakePageActive(PageType.Main);
        saveDataManager.UpdateUserProgress(loToGoTo, selectedStep);
    }
}
