using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class to be attached as components to buttons that
// need to show and hide panels on click
[RequireComponent(typeof(Button))]
public class PanelToggler : MonoBehaviour
{
    public PanelType panelToToggle;

    private PanelManager panelManager;
    private Button togglePanelButton;

    public void Start()
    {
        togglePanelButton = GetComponent<Button>();
        togglePanelButton.onClick.AddListener(OnButtonClicked);
        panelManager = PanelManager.Instance;
    }

    private void OnButtonClicked()
    {
        panelManager.TogglePanel(panelToToggle);
    }
}
