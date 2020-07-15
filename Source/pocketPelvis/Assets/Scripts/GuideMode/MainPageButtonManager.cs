/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPageButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button infoButton, labelButton;
    private ButtonInteractivityController interactivityController;

    // Start is called before the first frame update
    void Start()
    {
        interactivityController = GetComponent<ButtonInteractivityController>();

        LoNavigator.SetProgress += ChangeBasedOnProgress;
        interactivityController.DisableButton(infoButton);
        interactivityController.DisableButton(labelButton);
    }
    private void OnDisable()
    {
        LoNavigator.SetProgress -= ChangeBasedOnProgress;
    }
    public void ChangeBasedOnProgress(Progress progress)
    {
        // when tracking the pelvis model, allow the info and label buttons to be interacted with
        if (progress == Progress.win)
        {
            interactivityController.EnableButton(infoButton);
            interactivityController.EnableButton(labelButton);

        }
        else
        {
            interactivityController.DisableButton(infoButton);
            interactivityController.DisableButton(labelButton);
        }
    }
}
*/