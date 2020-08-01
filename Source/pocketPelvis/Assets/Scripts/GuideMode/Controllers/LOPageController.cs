using UnityEngine;
using UnityEngine.UI;

public class LOPageController : PageController
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
        startButtonTxt.text = currentProgress.isNewUser ? START_TXT : RESUME_TXT;
        panelManager.SetDefaultPanelType(null); // when there are no panels visible, make no panel appear as the default panel
    }

    public override void UpdateUI(bool isTrackingModel)
    {
        // make sure that the isTrackingModel panel does not appear on the page
        panelManager.HideAllPanels();
    }
}
