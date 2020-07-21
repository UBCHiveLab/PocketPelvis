using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(StepProperties))]
public class StepButtonSpriteUpdater : MonoBehaviour
{
    [SerializeField]
    private Sprite currentStepSprite, stepSprite;

    private GuideModeEventManager eventManager;
    private Button stepButton;
    private Image buttonImage;

    private int step;

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
        stepButton = GetComponent<Button>();
        buttonImage = stepButton.GetComponent<Image>();

        StepProperties stepProperties = GetComponent<StepProperties>();
        step = stepProperties.GetStep();

        // watch for changes to the user's progress so that the button's sprite is updated accordingly
        eventManager.OnUserProgressUpdated += UpdateSprite;

        // updates may be sent right before the step button updater was awoken. Make sure that everything is correct by updating with the most rescent data
        UserProgressData currentProgress = SaveDataManager.Instance.GetCurrentUserProgress();
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
        stepButton.gameObject.SetActive(step <= currentProgress.stepsInCurrentLO); // show the step button if the step is in the current lo
        buttonImage.sprite = step == currentProgress.currentStep ? currentStepSprite : stepSprite;

        bool haveBeenToStep = currentProgress.currentLO < currentProgress.furthestLO ||
            (currentProgress.furthestLO == currentProgress.currentLO && step <= currentProgress.furthestStep);

        // if we've been to this step before, make the step's button interactable. Otherwise, disable it
        ButtonInteractivityController.SetButtonInteractivity(stepButton, haveBeenToStep);
    }
}
