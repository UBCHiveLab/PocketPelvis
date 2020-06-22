using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractivityController : MonoBehaviour
{
    private readonly Color DISABLED_TINT = new Color(106.0f / 255.0f, 106.0f / 255.0f, 106.0f / 255.0f, 105 / 255.0f);
    private readonly Color ENABLED_TINT = new Color(1, 1, 1, 1);

    public void DisableButton(Button button, Image buttonImage = null)
    {
        button.interactable = false;
        if (buttonImage != null)
        {
            buttonImage.color = DISABLED_TINT;
        }
    }

    public void EnableButton(Button button, Image buttonImage = null)
    {
        button.interactable = true;
        if (buttonImage != null)
        {
            buttonImage.color = ENABLED_TINT;
        }
    }
}
