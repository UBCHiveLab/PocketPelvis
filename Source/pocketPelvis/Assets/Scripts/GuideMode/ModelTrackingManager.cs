
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public enum GuideViewOrientation
{
    Back,
    Back_BottomUp,
    Back_TilledUp,
    BottomUp,
    Front_TilledUp,
    Frontal,
    Side,
    TopDown,
    NoGuideView
}

public class ModelTrackingManager : SceneSingleton<ModelTrackingManager>
{

    private ModelTargetBehaviour modelTargetBehaviour;
    private ModelTarget modelTarget;
    private ITrackerManager trackerManager;
    private DeviceTracker deviceTracker;
    private PositionalDeviceTracker positionalDeviceTracker;
    private ObjectTracker objectTracker;
    bool deviceTrackerEnabled;

    private void Start()
    {
        modelTargetBehaviour = FindObjectOfType<ModelTargetBehaviour>();
        trackerManager = TrackerManager.Instance;
        if (trackerManager != null)
        {
            LoadTrackers();
        }
       
        // Stop Tracking when the app just initialized
        StopTracking();
    }

    public void SetGuideView(GuideViewOrientation guideViewOrientation)
    {
        
        modelTarget = modelTarget != null? modelTarget: modelTargetBehaviour.ModelTarget;

        // stop tracking before set up guide view
        StopTracking();


        if (guideViewOrientation != GuideViewOrientation.NoGuideView)
        {
            int guideViewID = (int)guideViewOrientation;
            modelTarget.SetActiveGuideViewIndex(guideViewID);
            modelTargetBehaviour.GuideViewMode = ModelTargetBehaviour.GuideViewDisplayMode.GuideView2D;
            // start tracking if there is guide view
            StartTracking();

        }
        else
        {
            modelTargetBehaviour.GuideViewMode = ModelTargetBehaviour.GuideViewDisplayMode.NoGuideView;
        }
    }

    //stop all ar trackers
    public void StopTracking()
    {

        trackerManager = trackerManager != null ? trackerManager : TrackerManager.Instance;
        if (trackerManager != null)
        {
            if (deviceTracker == null  || positionalDeviceTracker == null)
            {
                LoadTrackers();
            }

            if (deviceTracker != null)
            {

                deviceTracker.Stop();

            }

            if (objectTracker != null)
            {
                objectTracker.Stop();
            }
            if (positionalDeviceTracker != null)
            {
                //Debug.Log(positionalDeviceTracker.IsActive);
                positionalDeviceTracker.Stop();
                //positionalDeviceTracker.Reset();
                //positionalDeviceTracker.ResetAnchors();

            }

        }
        

    }
   //start all ar trackers
    public void StartTracking()
    {

        trackerManager = trackerManager != null ? trackerManager : TrackerManager.Instance;
        if (trackerManager != null)
        {
            if (deviceTracker == null || positionalDeviceTracker == null)
            {
                LoadTrackers();
            }
            if (deviceTracker != null)
            {
                
                deviceTracker.Start();
                
            }
            
            if (objectTracker != null)
            {
                objectTracker.Start();
            }

            if (positionalDeviceTracker != null)
            {
                
                positionalDeviceTracker.Start();
                positionalDeviceTracker.Reset();
                positionalDeviceTracker.ResetAnchors();
            }


        }
    }



    private void LoadTrackers()
    {
        deviceTracker = trackerManager.GetTracker<DeviceTracker>();
        positionalDeviceTracker = trackerManager.GetTracker<PositionalDeviceTracker>();
        objectTracker = trackerManager.GetTracker<ObjectTracker>();
    }
}
