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

        PanelController foundPanel= panelControllers.Find(x => x.panelType == _panelType);

        if (foundPanel!=null)
        foundPanel.gameObject.SetActive(true);
    }

    // used by buttons in the Unity editor to toggle the visiblity of a panel
    public void TogglePanel(PanelController panel)
    {

        bool panelIsVisible = panel.gameObject.activeSelf;

        HideAllPanels();

        // set the panel's visibilty to the opposite of what it was before
        panel.gameObject.SetActive(!panelIsVisible);

        if (panelIsVisible)
        {
            // if no panel is visible, make the fit panel visible
            ShowPanel(PanelType.Fit);
        }
    }


}
