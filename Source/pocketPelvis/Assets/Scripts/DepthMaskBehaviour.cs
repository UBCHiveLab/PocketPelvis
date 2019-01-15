using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMaskBehaviour : MonoBehaviour {

    //Controls renderer of GO with depthmask / any other GO not named in .txt file but you still want it to appear/disappear when Vuforia lost/found model

    Renderer thisRenderer;
    enum TRACKINGSTATE { NO, YES }

    // Use this for initialization
    void Start () {
        thisRenderer = this.gameObject.GetComponent<Renderer>();
        EventManager.Instance.RecognitionStateChangedEvent += OnRecognitionStateChanged;
	}

    private void OnRecognitionStateChanged(string foundOrLost)
    {
        if (foundOrLost == "NO")
        {
            thisRenderer.enabled = false;
        } else if (foundOrLost == "YES")
        {
            thisRenderer.enabled = true;
        }
    }
}
