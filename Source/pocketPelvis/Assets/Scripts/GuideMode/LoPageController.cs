using UnityEngine;
using UnityEngine.UI;

public class LoPageController : AbstractPageController
{
    [SerializeField]
    private Text startButtonTxt;

    private PanelManager panelManager;

    private const string START_TXT = "START LEARNING";
    private const string RESUME_TXT = "RESUME LEARNING";

    private void Awake()
    {
        panelManager = PanelManager.Instance;
    }

    public override void UpdateUI(UserProgressData currentProgress, LOTexts loTexts)
    {
        panelManager.SetDefaultPanelType(null); // when no panels are visible, make no panel appear as the default panel
        startButtonTxt.text = currentProgress.isNewUser ? START_TXT : RESUME_TXT;
    }

    public override void UpdateUI(bool isTrackingModel)
    {
        // for now, the lo page does not update when the tracking status of the model changes
        return;
    }
}
