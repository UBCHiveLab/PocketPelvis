using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomGuideModeTrackingHandler : DefaultTrackableEventHandler
{
    
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        //set progress to win
        SetCurrentProgress(Progress.win);
        FinishCurrentStep();
    }
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        SetCurrentProgress(Progress.inProgress);
    }
    #region CUSTOM_METHODS
    void SetCurrentProgress(Progress progress)
    {
        if (LoNavigator.instance.currentProgress == Progress.notStarted)
            return;
        LoNavigator.SetProgress(progress);
    }
    void FinishCurrentStep()
    {
        //save the progress of current step to finished
        LoNavigator.instance.saveProgress();
        
    }

    #endregion
}
