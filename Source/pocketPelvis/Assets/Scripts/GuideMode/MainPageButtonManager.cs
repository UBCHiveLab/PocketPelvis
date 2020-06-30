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
        LoNavigator.SetProgress += DisplayWinMessage;
        interactivityController.DisableButton(infoButton);
        interactivityController.DisableButton(labelButton);
    }
    private void OnDisable()
    {
        LoNavigator.SetProgress -= ChangeBasedOnProgress;
        LoNavigator.SetProgress -= DisplayWinMessage;
        StopAllCoroutines();
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
    public void DisplayWinMessage(Progress progress)
    {
        if (progress == Progress.win)
        {
            StartCoroutine(WinMessage());
        }
        else if (progress == Progress.inProgress)
        {
            StopCoroutine(WinMessage());
            PanelManager.Instance.ShowPanel(PanelType.Fit);
        }
        else
        {
            StopCoroutine(WinMessage());
        }
    }
    IEnumerator WinMessage()
    {
        PanelManager.Instance.ShowPanel(PanelType.WellDone);
        //display win panel and close it after 1 second
        yield return new WaitForSeconds(1f);
        PanelManager.Instance.ShowPanel(PanelType.Info);
    }

}