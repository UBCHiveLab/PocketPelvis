using UnityEngine;

public abstract class AbstractPageController : MonoBehaviour
{
    public PageType pageType;

    /// <summary> Update the UI to reflect the user's current progress </summary>
    public abstract void UpdateUI(UserProgressData currentProgress, LOTexts loTexts);

    /// <summary> Update the UI to show whether the pelvis model is currently being tracked or not </summary>
    public abstract void UpdateUI(bool isTrackingModel);
}
