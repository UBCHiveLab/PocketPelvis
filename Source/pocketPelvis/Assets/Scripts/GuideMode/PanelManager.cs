using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Panel
{
    Menu,
    Info,
    AllDone,
    WellDone,
    Fit,
    Introduction
}

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;

    public void HideAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    public void ShowPanel(Panel panel)
    {
        int panelIndex = GetPanelIndex(panel);
        if (panelIndex < 0)
        {
            return;
        }

        HideAllPanels();

        panels[panelIndex].SetActive(true);
    }

    // used by buttons in the Unity editor to toggle the visiblity of a panel
    public void TogglePanel(GameObject panel)
    {
        if (panel == null)
        {
            return;
        }

        bool panelIsVisible = panel.activeSelf;

        HideAllPanels();

        // set the panel's visibilty to the opposite of what it was before
        panel.SetActive(!panelIsVisible);

        if (panelIsVisible)
        {
            // if no panel is visible, make the fit panel visible
            ShowPanel(Panel.Fit);
        }
    }

    private int GetPanelIndex(Panel panel)
    {
        int panelIndex = (int) panel;
        if (panelIndex >= panels.Length)
        {
            panelIndex = -1;
        }
        return panelIndex;
    }
}
