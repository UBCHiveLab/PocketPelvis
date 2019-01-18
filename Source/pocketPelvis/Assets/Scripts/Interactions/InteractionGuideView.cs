using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class InteractionGuideView : MonoBehaviour {

    //Attached to guideview model. Model needs a separate thing to make it show only outline.

    GameObject guideViewModel;
    GameObject guideViewPanel;
    enum TRACKINGSTATE { NO, YES }

    // Use this for initialization
    void Start () {
        guideViewModel = GameObject.Find("GuideViewModel"); //model is parented to AR camera
        guideViewModel.SetActive(true);
        guideViewPanel = this.gameObject.transform.Find("Panel").gameObject;
        guideViewPanel.SetActive(true);

        EventManager.Instance.RecognitionStateChangedEvent += OnModelChanged;
    }
    

    private void OnModelChanged(string update)
    {
        if (update == "YES")
        {
            guideViewModel.SetActive(false);
            guideViewPanel.SetActive(false);
        }
        else
        {
            guideViewModel.SetActive(true);
            guideViewPanel.SetActive(true);
        }
    }
}
