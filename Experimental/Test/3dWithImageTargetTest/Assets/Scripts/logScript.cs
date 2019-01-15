using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<Renderer>().enabled == true)
        {
            Debug.Log("found thing");
        }
	}
}
