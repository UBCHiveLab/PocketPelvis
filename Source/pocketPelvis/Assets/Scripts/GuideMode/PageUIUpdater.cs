using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageUIUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject stepButtonContainer;
    [SerializeField]
    private GameObject toolbarButtonContainer;
    [SerializeField]
    private Button backwardButton, forwardButton, startButtonHorizontal, startButtonVertical;
    // TODO: add loText field

    private void OnEnable()
    {
        // watch for changes to data that requires the UI to be modified
        GuideModeEventManager eventManager = GuideModeEventManager.Instance;
        eventManager.OnModelTrackingStatusChanged += UpdateUI;
        eventManager.OnUserProgressUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        GuideModeEventManager eventManager = GuideModeEventManager.Instance;
        if (eventManager != null)
        {
            // if the event manager and any references to it's events haven't already been destroyed, unsubscribe to all events
            eventManager.OnModelTrackingStatusChanged -= UpdateUI;
            eventManager.OnUserProgressUpdated -= UpdateUI;
        }
    }

    // TODO: possibily think of better names for these methods, to allow ppl to distinguish between them better
    private void UpdateUI(UserProgressData currentProgress)
    {
        // TODO: update the UI to reflect the user's current progress
        Debug.Log("TODO: update UI to show current user progress");
    }

    private void UpdateUI(bool trackingState)
    {
        // TODO: update the UI to show whether the pelvis model is currently being tracked or not
        Debug.Log("TODO: update UI to reflect model tracking status changed");
    }
}
