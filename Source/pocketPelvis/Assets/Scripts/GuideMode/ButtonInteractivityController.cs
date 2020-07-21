using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractivityController
{
    private static readonly Color DISABLED_TINT = new Color(106.0f / 255.0f, 106.0f / 255.0f, 106.0f / 255.0f, 105.0f / 255.0f);
    private static readonly Color ENABLED_TINT = new Color(1, 1, 1, 1);

    public static void SetButtonInteractivity(Button button, bool enableButton)
    {
        button.interactable = enableButton;
        button.targetGraphic.color = enableButton ? ENABLED_TINT : DISABLED_TINT;
    }
}
