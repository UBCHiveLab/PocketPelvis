using UnityEngine;

public class StepProperties : MonoBehaviour
{
    [Header("If there is no specific learning objective associated with this step, set Learning Objective to 0")]
    [SerializeField]
    private int learningObjective = SaveDataManager.FIRST_LO;
    [SerializeField]
    private int step = SaveDataManager.INTRO_STEP;

    public int GetLearningObjective()
    {
        return learningObjective;
    }

    public int GetStep()
    {
        return step;
    }
}
