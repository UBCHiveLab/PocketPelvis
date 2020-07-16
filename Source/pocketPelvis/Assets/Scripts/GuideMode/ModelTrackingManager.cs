
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
/*
public class ModelTrackingManager : SceneSingleton<ModelTrackingManager>
{

    private ModelTargetBehaviour modelTargetBehaviour;
    private ModelTarget modelTarget;
    private ITrackerManager trackerManager;
    private DeviceTracker deviceTracker;
    private RotationalDeviceTracker rotationalDeviceTracker;
    private PositionalDeviceTracker positionalDeviceTracker;
    private ObjectTracker objectTracker;

    private void Start()
    {
        modelTargetBehaviour = FindObjectOfType<ModelTargetBehaviour>();
        //reset vuforia tracking
        trackerManager = TrackerManager.Instance;
        if (trackerManager != null)
        {
            deviceTracker = trackerManager.GetTracker<DeviceTracker>();
            rotationalDeviceTracker = trackerManager.GetTracker<RotationalDeviceTracker>();
            positionalDeviceTracker = trackerManager.GetTracker<PositionalDeviceTracker>();
            objectTracker = trackerManager.GetTracker<ObjectTracker>();

        }
    }
    private void OnEnable()
    {
        LoNavigator.SetProgress += SetTrackingStatus;
    }
    private void OnDisable()
    {
        LoNavigator.SetProgress -= SetTrackingStatus;
    }
    public void SetGuideView(GuideViewOrientation guideViewOrientation)
    {
        if (modelTargetBehaviour != null)
            modelTarget = modelTargetBehaviour.ModelTarget;

        //restart tracking before set up guide view


        //ReseTracking();



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
    void SetTrackingStatus(Progress progress)
    {
        if (progress == Progress.notStarted)
        {
            StopTracking();
        }
        else
        {
            StartTracking();
        }
    }
    //stop all ar trackers
    public void StopTracking()
    {
        if (trackerManager == null)
            trackerManager = TrackerManager.Instance;
        if (trackerManager != null)
        {
            if (deviceTracker == null || rotationalDeviceTracker == null || positionalDeviceTracker == null)
            {
                deviceTracker = trackerManager.GetTracker<DeviceTracker>();
                rotationalDeviceTracker = trackerManager.GetTracker<RotationalDeviceTracker>();
                positionalDeviceTracker = trackerManager.GetTracker<PositionalDeviceTracker>();
                objectTracker = trackerManager.GetTracker<ObjectTracker>();
            }

            if (deviceTracker != null)
            {
                deviceTracker.Stop();

            }

            if (rotationalDeviceTracker != null)
            {
                rotationalDeviceTracker.Stop();
            }

            if (positionalDeviceTracker != null)
            {

                positionalDeviceTracker.Stop();
                positionalDeviceTracker.Reset();
                positionalDeviceTracker.ResetAnchors();

            }
            if (objectTracker != null)
            {
                objectTracker.Stop();
            }

        }

    }
   //start all ar trackers
    public void StartTracking()
    {

        if (trackerManager == null)
            trackerManager = TrackerManager.Instance;
        if (trackerManager != null)
        {
            if (deviceTracker == null || rotationalDeviceTracker == null || positionalDeviceTracker == null)
            {
                deviceTracker = trackerManager.GetTracker<DeviceTracker>();
                rotationalDeviceTracker = trackerManager.GetTracker<RotationalDeviceTracker>();
                positionalDeviceTracker = trackerManager.GetTracker<PositionalDeviceTracker>();
                objectTracker = trackerManager.GetTracker<ObjectTracker>();
            }

            if (deviceTracker != null)
            {
                deviceTracker.Start();

            }

            if (rotationalDeviceTracker != null)
            {
                rotationalDeviceTracker.Start();
            }

            if (positionalDeviceTracker != null)
            {
                positionalDeviceTracker.Start();

            }
            if (objectTracker != null)
            {
                objectTracker.Start();
            }

        }
    }
}
*/
