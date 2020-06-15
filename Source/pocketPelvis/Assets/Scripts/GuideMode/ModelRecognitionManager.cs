using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public enum GuideViewOrientation
{
    Back,
    Frontal,
    TopDown,
    BottomUp,
    Frontal_TilledUp,
    Back_BottomUp,
    Back_TilledUp,
    Side,
    MidSaggital,
    AngledSide
}
public class ModelRecognitionManager : Singleton<ModelRecognitionManager>
{
    [SerializeField]
    private ModelTargetBehaviour modelTargetBehaviour;
    private ModelTarget modelTarget;


 
    public void SetGuideView(GuideViewOrientation guideViewOrientation)
    {
        //reset vuforia tracking
        ITrackerManager trackerManager = TrackerManager.Instance;
        if (trackerManager != null)
        {
            DeviceTracker deviceTracker = trackerManager.GetTracker<DeviceTracker>();
            RotationalDeviceTracker rotationalDeviceTracker = trackerManager.GetTracker<RotationalDeviceTracker>();
            PositionalDeviceTracker positionalDeviceTracker = trackerManager.GetTracker<PositionalDeviceTracker>();
            if (deviceTracker != null)
            {
                deviceTracker.Stop();
                deviceTracker.Start();
            }
            if (rotationalDeviceTracker != null)
            {
                rotationalDeviceTracker.Stop();
                rotationalDeviceTracker.Start();
            }
            if (positionalDeviceTracker != null)
            {
                positionalDeviceTracker.Stop();
                positionalDeviceTracker.Start();
            }
        }
        
        
        modelTarget = modelTargetBehaviour.ModelTarget;
        modelTarget.SetActiveGuideViewIndex((int)guideViewOrientation);

        
    }
}
