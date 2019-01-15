using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScreenText : MonoBehaviour {

    Text thisText;
    public GameObject model;

	// Use this for initialization
	void Start () {
        thisText = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        thisText.text = model.GetComponent<ModelBehaviour>().updates();
	}
}
