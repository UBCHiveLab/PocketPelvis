using System.Collections.Generic;

[System.Serializable]
public struct UserSaveData
{
    public UserProgressData userProgress;
    public List<LOAchievementData> loAchievements;
}

[System.Serializable]
public struct UserProgressData
{
    public bool isNewUser;
    public int currentLO;
    public int currentStep;
    public int furthestLO;
    public int furthestStep;
    public int stepsInCurrentLO;
}

[System.Serializable]
public struct LOAchievementData
{
    public int learningObjective;

    // tracks whether have achieved every step in the lo, except the introduction step, which can never be achieved
    public List<bool> stepAchievementStatus; 
}
