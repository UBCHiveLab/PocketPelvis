/*
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
        SetCurrentProgress(Progress.win);
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        SetCurrentProgress(Progress.inProgress);
    }
    #region CUSTOM_METHODS
    void SetCurrentProgress(Progress progress)
    {
        if (LoNavigator.Instance.currentProgress == Progress.notStarted)
            return;
        LoNavigator.SetProgress(progress);
    }

    #endregion
}
*/
