using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Silver Xu, 2020
/// Scene singleton that stores all delegate classes
/// </summary>
public class GuideModeEventManager : SceneSingleton<GuideModeEventManager>
{
    public delegate void ModelTrackingDelegate(bool trackingStatus);
    public event ModelTrackingDelegate ModelTrackingEvent;
    
    //Todo: Define User Progress Data
    //public delegate void UpdateProgressDelegate(UserProgressData updateData);
    //public event UpdateProgressDelegate UpdateProgressEvent;

    public delegate void StepAchievedDelegate();
    public event StepAchievedDelegate StepAchievedEvent;

    public void PublishModelTraackingEvent(bool trackingStatus)
    {
        ModelTrackingEvent(trackingStatus);
    }
    //public void PublishUpdateProgress(UserProgressData updateData)
    //{
    //    UpdateProgressEvent(updateData);
    //}
    public void PublishAllStepAchieved()
    {
        StepAchievedEvent();
    }
}
