using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LearningObject
{
    public bool isNewUser;
    public int currentLO;
    public int currentStep;
    public int furthestLO;
    public int furthestStep;
    public List<LOs> learningObjects = new List<LOs>();

}

[System.Serializable]
public class LOs
{
    public int id;
    public string objective;
    public List<bool> learningObjectAchievement = new List<bool>();
}

public class LearningObjectives : MonoBehaviour
{
   

    private LearningObject learningObject = new LearningObject();
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            ResetLOs();
            SaveLOs();
        }
    }

    private void SaveLOs()
    {
        string save = JsonUtility.ToJson(learningObject);

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
        
        learningObject= JsonUtility.FromJson<LearningObject>(load);
    }

    public void ResetLOs()
    {
        foreach(LOs lobject in learningObject.learningObjects)
        {
            for(int i = 0; i < lobject.learningObjectAchievement.Count; i++)
            {
                lobject.learningObjectAchievement[i] = false;
            }
        }
        learningObject.isNewUser = true;
        learningObject.currentLO = 0;
        learningObject.currentStep = 0;
        learningObject.furthestLO = 0;
        learningObject.furthestStep = 0;
        SaveLOs();
    }

    public void UpdateLOProgress(int currentLO, int currentStep)
    {
        // when the user makes progress, they shouldn't be considered a new user
        learningObject.isNewUser = false;

        learningObject.currentLO = currentLO;
        learningObject.currentStep = currentStep;

        if (currentLO > learningObject.furthestLO)
        {
            // if currently on a further lo, make this lo and the step the furthest we have been to.
            // if the current step is the intro step, make the furthest step the first step of the lo
            learningObject.furthestLO = currentLO;
            learningObject.furthestStep = currentStep == INTRO_STEP ? INTRO_STEP + 1 : currentStep;

        } else if (currentLO == learningObject.furthestLO &&  currentStep > learningObject.furthestStep)
        {
            // if on the same lo as the furthest one and we have gone to a further step, make this step the furthest.
            learningObject.furthestStep = currentStep;
        }

        SaveLOs();
    }

    public void AchieveLOStep(int loIndex, int stepIndex)
    {
        if (!IsValidStepIndex(loIndex, stepIndex))
        {
            return;
        }
        learningObject.learningObjects[loIndex].learningObjectAchievement[stepIndex] = true;
        SaveLOs();
    }

    public bool HaveBeenToStep(int lo, int step)
    {
        // either, we've been to all the steps of this lo before or we've been to this step before
        return lo < learningObject.furthestLO || (lo == learningObject.furthestLO && step <= learningObject.furthestStep);
    }

    public int GetLearningObjectiveId(int loIndex)
    {
        return IsValidLOIndex(loIndex) ? learningObject.learningObjects[loIndex].id : 0;
    }

    public int GetNumberOfLearningObjectives()
    {
        return learningObject.learningObjects.Count;
    }

    public int GetCurrentLearningObjective()
    {
        return learningObject.currentLO;
    }

    public int GetCurrentStep()
    {
        return learningObject.currentStep;
    }

    public int GetFurthestLearningObjective()
    {
        return learningObject.furthestLO;
    }

    public int GetFurthestStep()
    {
        return learningObject.furthestStep;
    }

    public int GetNumberOfSteps(int loIndex)
    {
        return IsValidLOIndex(loIndex) ? learningObject.learningObjects[loIndex].learningObjectAchievement.Count : 0;
    }

    public bool IsNewUser()
    {
        return learningObject.isNewUser;
    }

    public bool HaveAchievedStep(int loIndex, int stepIndex)
    {
        return IsValidStepIndex(loIndex, stepIndex) ? learningObject.learningObjects[loIndex].learningObjectAchievement[stepIndex] : false;
    }

    private bool IsValidLOIndex(int loIndex)
    {
        return loIndex > -1 && learningObject.learningObjects.Count > loIndex;
    }

    private bool IsValidStepIndex(int loIndex, int stepIndex)
    {
        if (IsValidLOIndex(loIndex))
        {
            return stepIndex > -1 && learningObject.learningObjects[loIndex].learningObjectAchievement.Count > stepIndex;
        }
        return false;
    }
}
