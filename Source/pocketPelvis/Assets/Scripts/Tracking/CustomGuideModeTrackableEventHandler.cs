public class CustomGuideModeTrackableEventHandler : DefaultTrackableEventHandler
{
    GuideModeEventManager eventManager;

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        ChangeTrackingStatus(true);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        ChangeTrackingStatus(false);
    }

    #region CUSTOM_METHODS
    private void ChangeTrackingStatus(bool isTrackingModel)
    {
        if (eventManager != null)
        {
            // when the program quits while the model is being tracked, then the tracking status will change, but the event manager may already be destroyed
            // only alert all subscribers that the tracking status has changed if the event manager and all of it's events have not been destroyed
            eventManager.PublishModelTrackingChangedEvent(isTrackingModel);
        }
    }
    #endregion
}

