using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StepButtonSpriteUpdater : MonoBehaviour
{
    [SerializeField]
    private Sprite currentStepSprite, stepSprite;
    [SerializeField]
    private int step = SaveDataManager.INTRO_STEP;

    private GuideModeEventManager eventManager;
    private Button stepButton;
    private Image buttonImage;

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
        stepButton = GetComponent<Button>();
        buttonImage = stepButton.GetComponent<Image>();

        // watch for changes to the user's progress so that the button's sprite is updated accordingly
        eventManager.OnUserProgressUpdated += UpdateSprite;

        // updates may be sent right before the step button updater was awoken. Make sure that everything is correct by updating with the most rescent data
        UserProgressData currentProgress = SaveDataManager.Instance.GetCurrentSaveState().userProgress;
        UpdateSprite(currentProgress);
    }

    private void OnDestroy()
    {
        // stop watching for changes to the user's progress
        if (eventManager != null)
        {
            eventManager.OnUserProgressUpdated -= UpdateSprite;
        } 
    }

    private void UpdateSprite(UserProgressData currentProgress)
    {
        stepButton.gameObject.SetActive(step <= currentProgress.stepsInCurrentLO);
        buttonImage.sprite = step == currentProgress.currentStep ? currentStepSprite : stepSprite;

        if (
            currentProgress.currentLO < currentProgress.furthestLO ||
            (currentProgress.furthestLO == currentProgress.currentLO && step <= currentProgress.furthestStep)
        )
        {
            // we've been to this step before; make this step's button interactable
            ButtonInteractivityController.EnableButton(stepButton);
        } 
        else
        {
            // we've never been to this step before or this step is the current step; make it so you can't interact with this step's button
            ButtonInteractivityController.DisableButton(stepButton);
        }
    }
}
