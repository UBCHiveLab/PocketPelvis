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
    Introduction,
    User,
    Tutorial
}

public class PanelManager : SceneSingleton<PanelManager>
{
    
    private List<PanelController> panelControllers;
    private PageManager pageManager;
    private LearningObjectives loData;

    private void Awake()
    {
        //get all panel controllers component in children including inactive ones
        panelControllers = GetComponentsInChildren<PanelController>(true).ToList();
        pageManager = PageManager.Instance;
        loData = LearningObjectives.instance;
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

        if (panelIsVisible && PanelIsOnMainPage())
        {
            // if we are on the main page and no panel is visible, then make the default panel visible.
            // When on an LO introduction, default panel == intro panel, otherwise default panel == fit panel
            ShowPanel(
                loData.GetCurrentStep() == LearningObjectives.INTRO_STEP ? PanelType.Introduction : PanelType.Fit
            );
        }
    }

    private bool PanelIsOnMainPage()
    {
        // if the main page is currently active, then the panel will
        // be displayed on the main page
        return pageManager.GetActivePageType() == PageType.Main;
    }

    private PanelController FindPanelWithType(PanelType type)
    {
        return panelControllers.Find(panel => panel.panelType == type);
    }

}
