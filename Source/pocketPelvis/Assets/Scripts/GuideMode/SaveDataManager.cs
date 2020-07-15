using UnityEngine;

public class SaveDataManager : SceneSingleton<SaveDataManager>
{
    private string saveDataPath;
    private UserSaveData saveData;
    private GuideModeEventManager eventManager;

    private const string SAVE_DATA_PATH = "/GuideMode/userSaveData.json";
    private const string EMPTY_SAVE_DATA_PATH = "GuideModeData/EmptySaveData";
    private const int LO_INDEX = 0;
    private const int STEP_INDEX = 1;
    public const int FIRST_LO = 1;
    public const int INTRO_STEP = 0;

    #region PRIVATE_METHODS
    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;

        #if UNITY_EDITOR
            saveDataPath = Application.dataPath + "/SaveData/" + SAVE_DATA_PATH;
        #elif UNITY_ANDROID || UNITY_IOS
            saveDataPath = Application.persistentDataPath + SAVE_DATA_PATH;
        #endif

        LoadSaveData();
    }

    private void OnEnable()
    {
        // watch for changes to the model tracking status
        eventManager.OnModelTrackingStatusChanged += AchieveCurrentStep;
    }

    private void OnDisable()
    {
        if (eventManager != null)
        {
            // if the event manager and all references to its events haven't been destroyed already,
            // stop watching for changes to the model tracking status
            eventManager.OnModelTrackingStatusChanged -= AchieveCurrentStep;
        }
    }

    private void LoadSaveData()
    {
        string jsonSaveData;

        if (System.IO.File.Exists(saveDataPath))
        {

            // Load learning objects from saved json file
            jsonSaveData = System.IO.File.ReadAllText(saveDataPath);

        }
        else
        {
            // Load empty save data from resources folder
            TextAsset loadedData = Resources.Load<TextAsset>(EMPTY_SAVE_DATA_PATH);
            jsonSaveData = loadedData.text;
        }

        saveData = JsonUtility.FromJson<UserSaveData>(jsonSaveData);
    }

    private void SaveData()
    {
        string jsonSaveData = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(saveDataPath, jsonSaveData);
    }

    private void AchieveCurrentStep(bool achievedStep)
    {
        if (!achievedStep)
        {
            // the step was not achieved, so leave the current step's achievement status as "unachieved"
            return;
        }

        int[] loIndices = GetLOIndices(saveData.userProgress.currentLO, saveData.userProgress.currentStep);
        int loIndex = loIndices[LO_INDEX];
        int stepIndex = loIndices[STEP_INDEX];
        saveData.loAchievements[loIndex].stepAchievementStatus[stepIndex] = achievedStep;
        SaveData();
    }

    private int GetLOIndex(int lo)
    {
        return saveData.loAchievements.FindIndex(loData => loData.learningObjective == lo);
    }

    private int[] GetLOIndices(int lo, int step)
    {
        int loIndex = GetLOIndex(lo);
        int stepIndex = loIndex < 0 || step <= INTRO_STEP || step > saveData.loAchievements[loIndex].stepAchievementStatus.Count ?
            -1 : // if the lo or the lo's step cannot be found in the save data, set the step index to -1
            step - 1; // steps that can be achieved: 1, 2, ..., but stepAchievementStatus is 0-base indexed. So, step 1 index = 0, step 2 index = 1, ...

        return new int[] { loIndex, stepIndex };
    }
    #endregion PRIVATE_METHODS

    #region PUBLIC_GETTER_METHODS
    public bool AreAllStepsAchieved()
    {
        bool allStepsAchieved = true;
        bool allStepsVisited = false;
        int loIndex = 0;
        int stepIndex = 0;
        int stepsInLO = saveData.loAchievements[loIndex].stepAchievementStatus.Count;

        while (allStepsAchieved && !allStepsVisited)
        {
            // set the achievement status to the achievement status of the current step
            allStepsAchieved = saveData.loAchievements[loIndex].stepAchievementStatus[stepIndex];
            if (stepIndex == stepsInLO)
            {
                // we checked the achievement status of all the steps in the current learning objective; go to the next lo
                loIndex++;
                stepIndex = 0;
                stepsInLO = saveData.loAchievements[loIndex].stepAchievementStatus.Count;

                // if we've seen all the steps in all the learning objectives, then the loIndex == number of learning objectives in the save data
                allStepsVisited = loIndex == saveData.loAchievements.Count;
            }
        }

        return allStepsAchieved;
    }

    public int GetCurrentLO()
    {
        return saveData.userProgress.currentLO;
    }

    public int GetCurrentStep()
    {
        return saveData.userProgress.currentStep;
    }

    public int GetNumStepsInLO(int lo)
    {
        int loIndex = GetLOIndex(lo);
        return loIndex < 0 ? 0 : saveData.loAchievements[loIndex].stepAchievementStatus.Count;
    }

    public UserSaveData GetCurrentSaveState()
    {
        return saveData;
    }
    #endregion PUBLIC_GETTER_METHODS

    #region EVENT_TRIGGERS
    public void ResetSaveData()
    {
        saveData.userProgress.isNewUser = true;

        // put the user on the first step of the first LO
        saveData.userProgress.currentLO = FIRST_LO;
        saveData.userProgress.currentStep = INTRO_STEP + 1;

        // the user has never seen any step of any LO yet, so make no LO the furthest
        saveData.userProgress.furthestLO = FIRST_LO - 1;
        saveData.userProgress.furthestStep = INTRO_STEP;

        // make it so that the user has achieved no LO steps
        saveData.loAchievements.ForEach(
            loData => loData.stepAchievementStatus.ForEach(
                achievementStatus => achievementStatus = false
            )
        );

        SaveData();
        eventManager.PublishUpdateUserProgress(saveData.userProgress);
    }

    public void UpdateUserProgress(int currentLO, int currentStep)
    {
        int[] loIndices = GetLOIndices(currentLO, currentStep);
        if (loIndices[STEP_INDEX] < 0)
        {
            // if the step index is negative, then either the currentLO or currentStep is not in the save data. Don't update progress
            return;
        }

        // if the user has updated their save data before, then they shouldn't be considered a new user
        saveData.userProgress.isNewUser = saveData.userProgress.furthestLO < FIRST_LO;

        saveData.userProgress.currentLO = currentLO;
        saveData.userProgress.currentStep = currentStep;

        if (currentLO > saveData.userProgress.furthestLO)
        {
            // if currently on a further lo, make this lo and the step the furthest we have been to.
            saveData.userProgress.furthestLO = currentLO;

            // if the current step is the intro step, make the furthest step the first step of the lo
            saveData.userProgress.furthestStep = currentStep == INTRO_STEP ? INTRO_STEP + 1 : currentStep;

        }
        else if (currentLO == saveData.userProgress.furthestLO && currentStep > saveData.userProgress.furthestStep)
        {
            // if on the same lo as the furthest one and we have gone to a further step, make this step the furthest.
            saveData.userProgress.furthestStep = currentStep;
        }

        SaveData();
        eventManager.PublishUpdateUserProgress(saveData.userProgress);
    }
    #endregion EVENT_TRIGGERS
}