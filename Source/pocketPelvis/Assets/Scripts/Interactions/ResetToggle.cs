using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResetToggle : MonoBehaviour {

    //Toggle with show everything / hide everything. It's named reset button because it used to only hide everything. The name kinda stuck.

    bool defaultOrHide;
    enum STATE { DEFAULT, HIGHLIGHT, FADE, HIDE };
    Text buttonName;

    // Use this for initialization
    void Start () {
        defaultOrHide = false;
        this.gameObject.GetComponent<Button>().onClick.AddListener(resetAll);
        buttonName = this.gameObject.GetComponentInChildren<Text>();
    }
    
    void resetAll()
    {
        if (defaultOrHide)
        {
            EventManager.Instance.publishStateEvent("All", Enum.GetName(typeof(STATE), STATE.HIDE));
            defaultOrHide = false;
            buttonName.text = "Show All";
        } else
        {
            EventManager.Instance.publishStateEvent("All", Enum.GetName(typeof(STATE), STATE.DEFAULT));
            defaultOrHide = true;
            buttonName.text = "Hide All";
        }
        
    }
}
