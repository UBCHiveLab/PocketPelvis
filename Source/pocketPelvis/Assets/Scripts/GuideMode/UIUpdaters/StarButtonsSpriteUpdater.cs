using UnityEngine;
using UnityEngine.UI;

public class StarButtonsSpriteUpdater : MonoBehaviour
{
    public Sprite achievedSprite, inProgressAndAchievedSprite, inProgressSprite, notDoneSprite;
    private SaveDataManager saveDataManager;

    private void Awake()
    {
        saveDataManager = SaveDataManager.Instance;
    }

    private void OnEnable()
    {
        UpdateSprites();
    }

    private void UpdateSprites()
    {
        // get the latest user data to ensure that the sprites are updated correctly
        UserSaveData userData = saveDataManager.GetCurrentSaveState();
        UserProgressData userProgress = userData.userProgress;

        int loIndex = 0;
        userData.loAchievements.ForEach((loData) =>
        {
            Transform learningObjectiveTransform = transform.GetChild(loIndex);
            int lo = loData.learningObjective;
            int stepIndex = 0;

            loData.stepAchievementStatus.ForEach((stepAchieved) =>
            {
                Transform loStepTransform = learningObjectiveTransform.GetChild(stepIndex);
                Image loStepImg = loStepTransform.GetComponent<Image>();
                Button loStepButton = loStepTransform.GetComponent<Button>();
                int step = stepIndex + 1;

                // update the step's sprite to match the user's latest progress through the learning objectives
                loStepImg.sprite = StepIsInProgress(userProgress, lo, step) ?
                    stepAchieved ? inProgressAndAchievedSprite : inProgressSprite :
                    stepAchieved ? achievedSprite : notDoneSprite;

                // allow the button for the learning objective be interacted with only if we've been to the step before
                bool haveSeenStep = lo < userProgress.furthestLO || (lo == userProgress.furthestLO && step <= userProgress.furthestStep);
                ButtonInteractivityController.SetButtonInteractivity(loStepButton, haveSeenStep);

                stepIndex++;
            });

            loIndex++;
        });
    }

    private bool StepIsInProgress(UserProgressData userProgress, int learningObjective, int step)
    {
        // There's no sprite for the lo introduction. When the user is on the introduction, mark their progress as the lo's first step
        bool stepIsIntro = userProgress.currentStep == SaveDataManager.INTRO_STEP && step == SaveDataManager.INTRO_STEP + 1;

        bool stepIsSelected = step == userProgress.currentStep;
        return (stepIsIntro || stepIsSelected) && learningObjective == userProgress.currentLO;
    }
}
