/// <summary>
/// Created by Silver Xu, 2020
/// Scene singleton that stores all delegate classes
/// </summary>
public class GuideModeEventManager : SceneSingleton<GuideModeEventManager>
{
    public delegate void ModelTrackingDelegate(bool trackingStatus);
    public event ModelTrackingDelegate OnModelTrackingStatusChanged;

    public delegate void UpdateProgressDelegate(UserProgressData updateData);
    public event UpdateProgressDelegate OnUserProgressUpdated;

    public delegate void StepAchievedDelegate();
    public event StepAchievedDelegate OnAllStepsAchieved;

    public void PublishModelTrackingChangedEvent(bool trackingStatus)
    {
        OnModelTrackingStatusChanged(trackingStatus);
    }
    public void PublishUpdateUserProgress(UserProgressData updatedData)
    {
        OnUserProgressUpdated(updatedData);
    }
    public void PublishAllStepsAchieved()
    {
        OnAllStepsAchieved();
    }
}
