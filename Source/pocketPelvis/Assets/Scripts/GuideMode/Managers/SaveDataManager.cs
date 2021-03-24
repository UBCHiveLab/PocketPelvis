using UnityEngine;
using System.IO;

public class SaveDataManager : SceneSingleton<SaveDataManager>
{
    private string saveDataPath;
    private UserSaveData saveData;
    private GuideModeEventManager eventManager;

    private const string SAVE_DATA_PATH = "/GuideMode/UserSaveData.json";
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
            saveDataPath = Application.persistentDataPath + "SAVE_DATA_PATH";
            //saveDataPath = Path.Combine(Application.persistantDataPath，“SAVE_DATA_PATH”);
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
        string jsonSaveData = System.IO.File.Exists(saveDataPath) ?
            System.IO.File.ReadAllText(saveDataPath) : // Load learning objects from saved json file
            GetEmptySaveData(); // Load empty save data from resources folder

        saveData = JsonUtility.FromJson<UserSaveData>(jsonSaveData);

        // let all observers know that the save data has been loaded
        eventManager.PublishUpdateUserProgress(saveData.userProgress);
    }

    private void SaveData()
    {
        string jsonSaveData = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(saveDataPath, jsonSaveData);
    }

    private string GetEmptySaveData()
    {
        TextAsset loadedData = Resources.Load<TextAsset>(EMPTY_SAVE_DATA_PATH) as TextAsset;
        return loadedData.text;
    }

    private void AchieveCurrentStep(bool achievedStep)
    {
        if (!achievedStep)
        {
            // the current step was not achieved. So, leave the current step's achievement status as "unachieved"
            return;
        }

        int[] loIndices = GetLOIndices(saveData.userProgress.currentLO, saveData.userProgress.currentStep);
        int loIndex = loIndices[LO_INDEX];
        int stepIndex = loIndices[STEP_INDEX];

        if (loIndex >= 0 && stepIndex >= 0)
        {
            // if the lo and step indicies are valid indices, then update the achievement status of the current step
            saveData.loAchievements[loIndex].stepAchievementStatus[stepIndex] = achievedStep;
            SaveData();
        }
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

    public bool IsStepAchieved(int lo, int step)
    {
        int[] loIndicies = GetLOIndices(lo, step);
        int loIndex = loIndicies[LO_INDEX];
        int stepIndex = loIndicies[STEP_INDEX];
        return loIndex < 0 || stepIndex < 0 ? false : saveData.loAchievements[loIndex].stepAchievementStatus[stepIndex];
    }

    public UserProgressData GetCurrentUserProgress()
    {
        return saveData.userProgress;
    }
    #endregion PUBLIC_GETTER_METHODS

    #region EVENT_TRIGGERS
    public void ResetSaveData()
    {
        // overwrite the existing saveData object with all the values of empty data
        saveData = JsonUtility.FromJson<UserSaveData>(GetEmptySaveData());

        SaveData();
        eventManager.PublishUpdateUserProgress(saveData.userProgress);
    }

    public void UpdateUserProgress(int currentLO, int currentStep)
    {
        int[] loIndices = GetLOIndices(currentLO, currentStep);
        int loIndex = loIndices[LO_INDEX];
        if (loIndex < 0 || (loIndices[STEP_INDEX] < 0 && currentStep != INTRO_STEP))
        {
            // if the lo or step index is negative, then there is no save data for either the currentLO or currentStep.
            // There is no save data for the intro step, so if the step index is negative and the current step is not the intro step, then the step is invalid.
            return;
        }

        // if the user has never updated their save data before, then they should be considered a new user
        saveData.userProgress.isNewUser = saveData.userProgress.isNewUser && currentLO == FIRST_LO && currentStep == INTRO_STEP + 1;

        saveData.userProgress.currentLO = currentLO;
        saveData.userProgress.currentStep = currentStep;
        saveData.userProgress.stepsInCurrentLO = saveData.loAchievements[loIndex].stepAchievementStatus.Count;

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