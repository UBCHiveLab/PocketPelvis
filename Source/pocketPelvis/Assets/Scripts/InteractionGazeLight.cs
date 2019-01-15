using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGazeLight : MonoBehaviour {

    //Controls gazelight. Currrently disabled since colliders are takes up a lot of CPU and causes major lags.

    enum INTERACTION { STRUCTURE, GROUP, NONE };

    List<string> currentCollisions = new List<string>();
    Collider thisCollider;

    // Use this for initialization
    void Start () {
        currentCollisions = new List<string>();
        EventManager.Instance.InteractionEvent += OnStructureInteractionEvent;
        thisCollider = this.GetComponent<MeshCollider>();
        //Debug.Log("started gaze light");
    }
	
	// Update is called once per frame
	void Update () {
		//
	}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("collided with " + col.gameObject.name);
        if (!currentCollisions.Contains(col.gameObject.name)) {
            currentCollisions.Add(col.gameObject.name);
        }
        if (thisCollider.enabled == true)
        {
            EventManager.Instance.publishCollisionEvent(currentCollisions);
        }
    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log("exited with " + col.gameObject.name);
        if (currentCollisions.Contains(col.gameObject.name)) {
            currentCollisions.Remove(col.gameObject.name);
        }
        if (thisCollider.enabled == true)
        {
            EventManager.Instance.publishCollisionEvent(currentCollisions);
        }
    }

    public void OnStructureInteractionEvent(string interaction, List<string> groupings)
    {
        if (interaction == "GAZELIGHT")
        {
            gazeLightObjectToggle(true);
        } else
        {
            gazeLightObjectToggle(false);
        }
    }
    

    private void gazeLightObjectToggle(bool tf)
    {
        thisCollider.enabled = tf;
        this.GetComponent<Renderer>().enabled = tf;
        foreach (MeshRenderer mr in this.GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = tf;
        }
    }
}
