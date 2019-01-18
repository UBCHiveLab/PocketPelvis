using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialToggle : MonoBehaviour {

    //Show/hide tutorial panel

    bool onoff;
    GameObject tutorialPanel;

	// Use this for initialization
	void Start () {
        onoff = true;
        tutorialPanel = GameObject.Find("TutorialPanel");
        tutorialOnOff();
        this.gameObject.GetComponent<Button>().onClick.AddListener(tutorialOnOff);
    }

    private void tutorialOnOff()
    {
        if (onoff)
        {
            onoff = false;
            tutorialPanel.SetActive(onoff);
        } else
        {
            onoff = true;
            tutorialPanel.SetActive(onoff);
        }
    }
}
