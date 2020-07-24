using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(StepProperties))]
public class StarButtonSpriteUpdater : MonoBehaviour
{
    [SerializeField]
    private Sprite achievedSprite, inProgressAndAchievedSprite, inProgressSprite, notDoneSprite;

    private SaveDataManager saveDataManager;
    private GuideModeEventManager eventManager;

    private Button starButton;
    private Image buttonImage;

    private int step;
    private int learningObjective;

    private void Awake()
    {
        saveDataManager = SaveDataManager.Instance;
        eventManager = GuideModeEventManager.Instance;

        starButton = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        StepProperties stepProperties = GetComponent<StepProperties>();
        step = stepProperties.GetStep();
        learningObjective = stepProperties.GetLearningObjective();
    }

    private void OnEnable()
    {
        eventManager.OnUserProgressUpdated += UpdateSprite;

        // updates may be sent while the sprite updater was not enabled. Make sure that the sprite is correct by updating with the latest data
        UserProgressData userProgress = saveDataManager.GetCurrentUserProgress();

        if (!userProgress.Equals(default(UserProgressData))) {
            // userProgress contains loaded save data, update the sprites. Otherwise, do nothing, as we don't know the user's current progress
            UpdateSprite(userProgress);
        }
    }

    private void OnDisable()
    {
        // if the event manager and all refernces to it's events haven't already been destroyed, unsubscribe to all events
        if (eventManager != null)
        {
            eventManager.OnUserProgressUpdated -= UpdateSprite;
        }
    }

    private void UpdateSprite(UserProgressData userProgress)
    {
        Func<bool> StepIsInProgress = () =>
        {
            // There's no sprite for the lo introduction. When the user is on the introduction, mark their progress as the lo's first step
            bool stepIsIntro = userProgress.currentStep == SaveDataManager.INTRO_STEP && step == SaveDataManager.INTRO_STEP + 1;

            bool stepIsSelected = step == userProgress.currentStep;
            return (stepIsIntro || stepIsSelected) && learningObjective == userProgress.currentLO;
        };

        bool stepAchieved = saveDataManager.IsStepAchieved(learningObjective, step);

        // update the step's sprite to match the user's latest progress through the learning objectives
        buttonImage.sprite = StepIsInProgress() ?
            stepAchieved ? inProgressAndAchievedSprite : inProgressSprite :
            stepAchieved ? achievedSprite : notDoneSprite;

        // allow the star button to be interacted with only if we've been to the star's step before
        bool haveBeenToStep = learningObjective < userProgress.furthestLO || (learningObjective == userProgress.furthestLO && step <= userProgress.furthestStep);
        ButtonInteractivityController.SetButtonInteractivity(starButton, haveBeenToStep);
    }
}
