using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPageButtonManager : MonoBehaviour
{
    [SerializeField]
    Button InfoButton, LabelButton;
    // Start is called before the first frame update
    void Start()
    {
        LoNavigator.SetProgress += ChangeBasedOnProgress;
        LoNavigator.SetProgress += DisplayWinMessage;
        InfoButton.interactable = false;
        LabelButton.interactable = false;
    }
    private void OnDisable()
    {
        LoNavigator.SetProgress -= ChangeBasedOnProgress;
        LoNavigator.SetProgress -= DisplayWinMessage;
        StopAllCoroutines();
    }
    public void ChangeBasedOnProgress(Progress progress)
    {
        if (progress == Progress.win)
        {
            InfoButton.interactable = true;
            LabelButton.interactable = true;

        }
        else
        {
            InfoButton.interactable = false;
            LabelButton.interactable = false;
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