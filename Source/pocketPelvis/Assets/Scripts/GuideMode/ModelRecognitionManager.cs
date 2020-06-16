using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// due to model target guide view behaviour, the enum has to be sorted by alphabetic order
public enum GuideViewOrientation
{
    Back ,
    Back_BottomUp,
    Back_TilledUp,
    BottomUp,
    Front_TilledUp,
    Frontal,
    Side,
    TopDown,
    NoGuideView
}
public class ModelRecognitionManager : Singleton<ModelRecognitionManager>
{
    
    private ModelTargetBehaviour modelTargetBehaviour;
    private ModelTarget modelTarget;

    private void Start()
    {
        modelTargetBehaviour = FindObjectOfType<ModelTargetBehaviour>();
    }

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
        
        if(modelTargetBehaviour != null)
        modelTarget = modelTargetBehaviour.ModelTarget;
        if (guideViewOrientation != GuideViewOrientation.NoGuideView)
        {
            int guideViewID = (int)guideViewOrientation;
            modelTarget.SetActiveGuideViewIndex(guideViewID);
            modelTargetBehaviour.GuideViewMode = ModelTargetBehaviour.GuideViewDisplayMode.GuideView2D;
            
        }
        else
        {
            modelTargetBehaviour.GuideViewMode = ModelTargetBehaviour.GuideViewDisplayMode.NoGuideView;
        }
    }
}
