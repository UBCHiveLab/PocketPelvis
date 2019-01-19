using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelStatePanelUpdate : MonoBehaviour {

    //Updates status updater on the screen. Tell user if tracking is found or not.

    Text modelState;
    enum TRACKINGSTATE { NO, YES }
    Color noColor;
    Color yesColor;

    // Use this for initialization
    void Start () {
        modelState = this.gameObject.GetComponentInChildren<Text>();
        instantiateColor();

        EventManager.Instance.RecognitionStateChangedEvent += OnModelChanged;
    }

    private void instantiateColor()
    {
        noColor = new Color(238f / 255f, 82f / 255f, 83f / 255f, 1.0f); //red
        yesColor = new Color(46f / 255f, 134f / 255f, 222f / 255f, 1.0f); //blue
    }

    private void OnModelChanged(string update)
    {
        modelState.text = "Tracking Status: " + update;

        if (update == "YES")
        {
            modelState.color = yesColor;
        } else
        {
            modelState.color = noColor;
        }
        
    }
}
