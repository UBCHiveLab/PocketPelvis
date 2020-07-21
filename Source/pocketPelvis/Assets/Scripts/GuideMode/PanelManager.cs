using System.Collections.Generic;
using System.Linq;

public enum PanelType
{
    Menu,
    Info,
    FitInstructions,
    IsTrackingModel,
    Introduction,
    User,
    Tutorial
}

public class PanelManager : SceneSingleton<PanelManager>
{
    private List<PanelController> panelControllers;
    private PageManager pageManager;
    private PanelType defaultPanel;

    private void Awake()
    {
        //get all panel controllers component in children including inactive ones
        panelControllers = GetComponentsInChildren<PanelController>(true).ToList();
        pageManager = PageManager.Instance;
        defaultPanel = PanelType.FitInstructions;
    }

    /// <summary> Set the panel to show when no panels are being shown on the main page </summary>
    public void SetDefaultPanelType(PanelType type)
    {
        defaultPanel = type;
    }

    public void HideAllPanels()
    {
        panelControllers.ForEach(controller => controller.gameObject.SetActive(false));
    }

    public void ShowPanel(PanelType _panelType)
    {
        HideAllPanels();

        PanelController foundPanel= FindPanelWithType(_panelType);
        if (foundPanel!=null)
        {
            foundPanel.gameObject.SetActive(true);
        }
    }

    public void TogglePanel(PanelType _panelType)
    {
        PanelController foundPanel = FindPanelWithType(_panelType);

        if (foundPanel == null)
        {
            return;
        }

        bool panelIsVisible = foundPanel.gameObject.activeSelf;

        HideAllPanels();

        // set the panel's visibilty to the opposite of what it was before
        foundPanel.gameObject.SetActive(!panelIsVisible);

        if (panelIsVisible && PageType.Main == pageManager.GetActivePageType())
        {
            // if we are on the main page and no panel is visible, then make the default panel visible.
            ShowPanel(defaultPanel);
        }
    }

    private PanelController FindPanelWithType(PanelType type)
    {
        return panelControllers.Find(panel => panel.panelType == type);
    }
}
