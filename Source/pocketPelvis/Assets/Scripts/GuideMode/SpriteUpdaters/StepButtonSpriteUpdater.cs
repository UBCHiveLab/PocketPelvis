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
    private bool haveBeenToStep;

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
        stepButton = GetComponent<Button>();
        buttonImage = stepButton.GetComponent<Image>();

        StepProperties stepProperties = GetComponent<StepProperties>();
        step = stepProperties.GetStep();
        haveBeenToStep = false;

        // watch for changes to the user's progress so that the button's sprite is updated accordingly
        eventManager.OnUserProgressUpdated += UpdateSprite;
        eventManager.OnModelTrackingStatusChanged += UpdateButtonInteractivityWithTrackingStatus;
    }

    private void OnDestroy()
    {
        // stop watching for changes to the pelvis model's tracking status and the user's progress
        if (eventManager != null)
        {
            eventManager.OnUserProgressUpdated -= UpdateSprite;
            eventManager.OnModelTrackingStatusChanged -= UpdateButtonInteractivityWithTrackingStatus;
        } 
    }

    private void UpdateSprite(UserProgressData currentProgress)
    {
        stepButton.gameObject.SetActive(step <= currentProgress.stepsInCurrentLO); // show the step button if the step is in the current lo
        buttonImage.sprite = step == currentProgress.currentStep ? currentStepSprite : stepSprite;

        haveBeenToStep = currentProgress.currentLO < currentProgress.furthestLO ||
            (currentProgress.furthestLO == currentProgress.currentLO && step <= currentProgress.furthestStep);

        // if we've been to this step before, make the step's button interactable. Otherwise, disable it
        SetStepButtonInteractivity(haveBeenToStep);
    }

    private void UpdateButtonInteractivityWithTrackingStatus(bool isTrackingModel)
    {
        // while the model is being tracked, prevent the user from going to a new step by disabling the step button.
        // thus, the button will be interactable when the model isn't being tracked and the user has been to the step
        SetStepButtonInteractivity(!isTrackingModel && haveBeenToStep);
    }

    private void SetStepButtonInteractivity(bool isInteractable)
    {
        ButtonInteractivityController.SetButtonInteractivity(stepButton, isInteractable);
    }
}
