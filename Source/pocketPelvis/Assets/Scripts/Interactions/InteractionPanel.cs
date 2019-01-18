using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel {

    //Superclass extended by InteractionGroup and InteractionStructure. Barebone class that holds each interaction button panel.

    public GameObject thisInteraction;
    protected string name;

    protected enum STATE { DEFAULT, HIGHLIGHT, FADE, HIDE };
    /*
    public List<Image> buttonImages;
    enum TRACKINGSTATE { NO, YES }
    Color noColor;
    Color yesColor;
    */
    public InteractionPanel(string name)
    {
        this.name = name;
    }
    /*
    //setupbuttonrecolor should be called in subclass when thisinteraction is initialized
    public void SetUpButtonRecolor()
    {
        Button[] buttons = thisInteraction.GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            buttonImages.Add(b.gameObject.GetComponent<Image>());
        }
        
        instantiateColor();
        EventManager.Instance.RecognitionStateChangedEvent += OnRecognitionStateChanged;
        ChangeButtonsColor(noColor);
    }

    protected void instantiateColor()
    {
        noColor = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1.0f); //grey
        yesColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 1.0f); //white
    }

    protected void OnRecognitionStateChanged(string foundOrLost)
    {
        if (foundOrLost == "YES")
        {
            ChangeButtonsColor(yesColor);
        }
        else
        {
            ChangeButtonsColor(noColor);
        }
    }

    protected void ChangeButtonsColor(Color c)
    {
        foreach (Image i in buttonImages)
        {
            i.color = c;
        }
    }
    */
}
