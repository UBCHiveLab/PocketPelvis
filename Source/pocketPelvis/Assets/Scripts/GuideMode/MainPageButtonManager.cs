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
        InfoButton.interactable = false;
        LabelButton.interactable = false;
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

    
}
