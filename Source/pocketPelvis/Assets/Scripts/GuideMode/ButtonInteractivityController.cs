using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractivityController : MonoBehaviour
{
    private readonly Color DISABLED_TINT = new Color(106.0f / 255.0f, 106.0f / 255.0f, 106.0f / 255.0f, 105 / 255.0f);
    private readonly Color ENABLED_TINT = new Color(1, 1, 1, 1);

    public void DisableButton(Button button, bool applyTint = true)
    {
        button.interactable = false;
        if (applyTint)
        {
            button.targetGraphic.color = DISABLED_TINT;
        }
    }

    public void EnableButton(Button button, bool applyTint = true)
    {
        button.interactable = true;
        if (applyTint)
        {
            button.targetGraphic.color = ENABLED_TINT;
        }
    }
}
