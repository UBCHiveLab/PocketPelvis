using UnityEngine;

public class ToggleTutorial : PanelToggler
{
    [SerializeField]
    private GameObject trackingIndicator;

    protected override void OnClickButton()
    {
        base.OnClickButton();
        trackingIndicator.SetActive(!trackingIndicator.activeSelf);
    }
}
