using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PanelType
{
    Menu,
    Info,
    AllDone,
    WellDone,
    Fit,
    Introduction
}

public class PanelManager : Singleton<PanelManager>
{
    
    private List<PanelController> panelControllers;

    private void Awake()
    {
        //get all panel controllers component in children including inactive ones
        panelControllers = GetComponentsInChildren<PanelController>(true).ToList();
    }

    public void HideAllPanels()
    {
        panelControllers.ForEach(x => x.gameObject.SetActive(false));
    }

    public void ShowPanel(PanelType _panelType)
    {
        HideAllPanels();

        PanelController foundPanel= FindPanelWithType(_panelType);

        if (foundPanel!=null)
        foundPanel.gameObject.SetActive(true);
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

        if (panelIsVisible)
        {
            // if no panel is visible, make the fit panel visible
            ShowPanel(PanelType.Fit);
        }
    }

    private PanelController FindPanelWithType(PanelType type)
    {
        return panelControllers.Find(panel => panel.panelType == type);
    }

}
