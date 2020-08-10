/// <summary>
/// Created by Silver Xu, 2020
/// Scene singleton that stores all delegate classes
/// </summary>
public class GuideModeEventManager : SceneSingleton<GuideModeEventManager>
{
    public delegate void ModelTrackingDelegate(bool isTrackingModel);
    public event ModelTrackingDelegate OnModelTrackingStatusChanged;

    public delegate void UpdateProgressDelegate(UserProgressData updatedData);
    public event UpdateProgressDelegate OnUserProgressUpdated;

    public void PublishModelTrackingChangedEvent(bool isTrackingModel)
    {
        if (OnModelTrackingStatusChanged != null)
        {
            // if there are subscribers to the event, tell the subscribers that the event has occurred
            OnModelTrackingStatusChanged(isTrackingModel);
        }
    }
    public void PublishUpdateUserProgress(UserProgressData updatedData)
    {
        if (OnUserProgressUpdated != null)
        {
            // if there are subscribers to the event, tell the subscribers that the event has occurred
            OnUserProgressUpdated(updatedData);
        }
    }
}
