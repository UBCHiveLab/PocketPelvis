// Class to be attached as components to buttons that need to show and hide panels on click
public class PanelToggler : AbstractOnClickButtonBehaviour
{
    public PanelType panelToToggle;

    private PanelManager panelManager;

    protected override void Awake()
    {
        base.Awake();
        panelManager = PanelManager.Instance;
    }

    protected override void OnClickButton()
    {
        panelManager.TogglePanel(panelToToggle);
    }
}
