using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionToggleRecolor : MonoBehaviour {

    //Used to control color of buttons. Grey out buttons when recognition is not found.

    Image buttonImage;
    enum TRACKINGSTATE { NO, YES }
    Color noColor;
    Color yesColor;

    // Use this for initialization
    void Start () {

        buttonImage = this.gameObject.GetComponent<Image>();
        instantiateColor();
        EventManager.Instance.RecognitionStateChangedEvent += OnRecognitionStateChanged;
        buttonImage.color = noColor;
    }

    private void instantiateColor()
    {
        noColor = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1.0f); //grey
        yesColor = new Color(245f / 255f, 245f / 255f, 245f / 255f, 1.0f); //white
    }

    private void OnRecognitionStateChanged(string foundOrLost)
    {
        if (foundOrLost == "YES")
        {
            buttonImage.color = yesColor;
        }
        else
        {
            buttonImage.color = noColor;
        }
    }
    
}
