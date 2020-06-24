using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserSaveData
{
    public bool isNewUser;
    public int currentLO;
    public int currentStep;
    public int furthestLO;
    public int furthestStep;
    public List<LearningObjectiveData> learningObjectivesData = new List<LearningObjectiveData>();

}

[System.Serializable]
public class LearningObjectiveData
{
    public int learningObjective;
    public string objective;
    public List<bool> stepAchievementStatus = new List<bool>(); // tracks whether have achieved every step in the lo, except the introduction step, which can never be achieved
}

public class LearningObjectives : MonoBehaviour
{


    private UserSaveData saveData = new UserSaveData();
    private string jsonSavePath;
    public static LearningObjectives instance;
    public const int INTRO_STEP = 0;

    private void Awake()
    {

        #if UNITY_EDITOR
                jsonSavePath = Application.dataPath + "/SaveData/saveAchievements.json";
        #elif UNITY_ANDROID || UNITY_IOS
                jsonSavePath = Application.persistentDataPath + "/saveAchievements.json";
        #endif
        instance = this;
        LoadLOs();
    }

    private void Update()
    {
        //Debug.Log("Current lo step:" + learningObject.lastLO + "-" + learningObject.lastStep);
    }

    private void SaveLOs()
    {
        string save = JsonUtility.ToJson(saveData);

        System.IO.File.WriteAllText(jsonSavePath, save);
    }

    private void LoadLOs()
    {
        // Load learning objects from saved json file
        string load;
        if (System.IO.File.Exists(jsonSavePath))
        {
            load = System.IO.File.ReadAllText(jsonSavePath);
        }
        else
        {
            load = System.IO.File.ReadAllText(Application.dataPath + "/SaveData/emptyData.json");
        }

        saveData = JsonUtility.FromJson<UserSaveData>(load);
    }

    public void ResetLOs()
    {
        foreach(LearningObjectiveData loData in saveData.learningObjectivesData)
        {
            for(int stepIndex = 0; stepIndex < loData.stepAchievementStatus.Count; stepIndex++)
            {
                loData.stepAchievementStatus[stepIndex] = false;
            }
        }
        saveData.isNewUser = true;
        saveData.currentLO = 0;
        saveData.currentStep = 0;
        saveData.furthestLO = 0;
        saveData.furthestStep = 0;
        SaveLOs();
    }

    public void UpdateLOProgress(int currentLO, int currentStep)
    {
        // when the user makes progress, they shouldn't be considered a new user
        saveData.isNewUser = false;

        saveData.currentLO = currentLO;
        saveData.currentStep = currentStep;

        if (currentLO > saveData.furthestLO)
        {
            // if currently on a further lo, make this lo and the step the furthest we have been to.
            // if the current step is the intro step, make the furthest step the first step of the lo
            saveData.furthestLO = currentLO;
            saveData.furthestStep = currentStep == INTRO_STEP ? INTRO_STEP + 1 : currentStep;

        } else if (currentLO == saveData.furthestLO &&  currentStep > saveData.furthestStep)
        {
            // if on the same lo as the furthest one and we have gone to a further step, make this step the furthest.
            saveData.furthestStep = currentStep;
        }

        SaveLOs();
    }

    public void AchieveLOStep(int lo, int step)
    {
        int loIndex = GetLOIndex(lo);
        int stepIndex = GetStepIndex(step);
        if (!IsValidStepIndex(loIndex, stepIndex))
        {
            return;
        }
        saveData.learningObjectivesData[loIndex].stepAchievementStatus[stepIndex] = true;
        SaveLOs();
    }

    public bool HaveBeenToStep(int lo, int step)
    {
        // either, we've been to all the steps of this lo before or we've been to this step before
        return lo < saveData.furthestLO || (lo == saveData.furthestLO && step <= saveData.furthestStep);
    }

    public int GetNumberOfLearningObjectives()
    {
        // the save data should contain data for each learning objective. Thus, loData count == lo count
        return saveData.learningObjectivesData.Count;
    }

    public int GetCurrentLearningObjective()
    {
        return saveData.currentLO;
    }

    public int GetCurrentStep()
    {
        return saveData.currentStep;
    }

    public int GetFurthestLearningObjective()
    {
        return saveData.furthestLO;
    }

    public int GetFurthestStep()
    {
        return saveData.furthestStep;
    }

    public int GetNumberOfSteps(int lo)
    {
        int loIndex = GetLOIndex(lo);
        // there should be achievement save data for each step. Thus, stepAchievementStatus count == step count
        return IsValidLOIndex(loIndex) ? saveData.learningObjectivesData[loIndex].stepAchievementStatus.Count : 0;
    }

    public bool IsNewUser()
    {
        return saveData.isNewUser;
    }

    public bool HaveAchievedStep(int lo, int step)
    {
        int loIndex = GetLOIndex(lo);
        int stepIndex = GetStepIndex(step);
        return IsValidStepIndex(loIndex, stepIndex) ? saveData.learningObjectivesData[loIndex].stepAchievementStatus[stepIndex] : false;
    }

    private bool IsValidLOIndex(int loIndex)
    {
        return loIndex > -1 && saveData.learningObjectivesData.Count > loIndex;
    }

    private bool IsValidStepIndex(int loIndex, int stepIndex)
    {
        if (IsValidLOIndex(loIndex))
        {
            return stepIndex > -1 && saveData.learningObjectivesData[loIndex].stepAchievementStatus.Count > stepIndex;
        }
        return false;
    }

    private int GetLOIndex(int lo)
    {
        return saveData.learningObjectivesData.FindIndex(loData => loData.learningObjective == lo);
    }

    private int GetStepIndex(int step)
    {
        // stepAchievmentStatus records the status of every step, except the intro step
        // thus, step 1 = index 0, step 2 = index 1, ...
        return step - 1;
    }
}
