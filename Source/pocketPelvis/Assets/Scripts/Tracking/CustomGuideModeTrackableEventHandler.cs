
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class CustomGuideModeTrackableEventHandler : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        //set progress to win
        ChangeTrackingStatus(true);
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        ChangeTrackingStatus(false);
    }
    #region CUSTOM_METHODS
    private void ChangeTrackingStatus(bool trackingStatus)
    {
        GuideModeEventManager.Instance.PublishModelTrackingChangedEvent(trackingStatus);
    }

    #endregion
}

