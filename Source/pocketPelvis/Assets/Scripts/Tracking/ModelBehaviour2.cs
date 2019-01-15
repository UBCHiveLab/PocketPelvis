using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class ModelBehaviour2 : MonoBehaviour {

    //Works with defaulttrackableeventhandler.
    //This code is outdated. Use ModelBehaviour3. It's faster.

    Renderer[] modelObjectsRenderer;
    Collider[] modelObjectsCollider;

    GameObject[] arObjects_model;
    GameObject[] arObjects_image;
    //GameObject[] arObjects_mount;
    GameObject activeARObject;

    int ARsource;
    enum ARsources { model, image, mount, none };
    int ARObjectState;
    enum ARObjectStates { no, yes };

    StringBuilder update;

    public UnityEvent stateChanged = new UnityEvent();

    // Use this for initialization
    void Start () {
        modelObjectsCollider = this.gameObject.GetComponentsInChildren<Collider>();
        modelObjectsRenderer = this.gameObject.GetComponentsInChildren<Renderer>();
        disableRendererAndCollider();
        arObjects_model = GameObject.FindGameObjectsWithTag("arObject_model");
        arObjects_image = GameObject.FindGameObjectsWithTag("arObject_image");
        //arObjects_mount = GameObject.FindGameObjectsWithTag("arObject_mount");

        ARsource = (int)ARsources.none;
        ARObjectState = (int)ARObjectStates.no;

        update = new StringBuilder("");
    }

    // Update is called once per frame
    void Update()
    {

        bool foundActive = false;

        //check model target
        foreach (GameObject arObject in arObjects_model)
        {
            if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
            {
                foundActive = true;
                ARsource = (int)ARsources.model;
                ARObjectState = (int)ARObjectStates.yes;

                activeARObject = arObject;
            }
        }
        
        
        //if still haven't found active ar source, check image target
        if (foundActive == false)
        {
            foreach (GameObject arObject in arObjects_image)
            {
                if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
                {
                    foundActive = true;
                    ARsource = (int)ARsources.image;
                    ARObjectState = (int)ARObjectStates.yes;

                    activeARObject = arObject;
                }
            }
        }

        /*
        //if still haven't found active ar source, check mount target
        if (foundActive == false)
        {
            foreach (GameObject arObject in arObjects_mount)
            {
                if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
                {
                    foundActive = true;
                    ARsource = (int)ARsources.mount;
                    ARObjectState = (int)ARObjectStates.yes;

                    activeARObject = arObject;
                }
            }
        }
        */

        //if still haven't found active ar source, set state as no
        if (foundActive == false)
        {
            ARsource = (int)ARsources.none;
            ARObjectState = (int)ARObjectStates.no;
        }

        // Turn model on / off depending on AR source
        if (ARObjectState == (int)ARObjectStates.yes)
        {
            enabledRendererAndCollider();
            this.gameObject.transform.rotation = activeARObject.transform.rotation;
            this.gameObject.transform.position = activeARObject.transform.position;
            stateChanged.Invoke();
        }
        else if (ARObjectState == (int)ARObjectStates.no)
        {
            disableRendererAndCollider();
            stateChanged.Invoke();
        }
    }

    private void disableRendererAndCollider()
    {
        foreach (Renderer r in modelObjectsRenderer)
        {
            r.enabled = false;
        }

        foreach (Collider c in modelObjectsCollider)
        {
            c.enabled = false;
        }
    }

    private void enabledRendererAndCollider()
    {
        foreach (Renderer r in modelObjectsRenderer)
        {
            r.enabled = true;
        }

        foreach (Collider c in modelObjectsCollider)
        {
            c.enabled = true;
        }
    }

    public string updates()
    {
        update = new StringBuilder("");

        if (ARObjectState == (int)ARObjectStates.no)
        {
            update.AppendLine("AR Object Lost");
        }
        else if (ARObjectState == (int)ARObjectStates.yes)
        {
            update.AppendLine("AR Object found");
        }
        
        if (ARsource == (int)ARsources.none)
        {
            update.AppendLine("Target source: none");
        }
        else if (ARsource == (int)ARsources.model)
        {
            update.AppendLine("Target source: model");
        }
        else if (ARsource == (int)ARsources.image)
        {
            update.AppendLine("Target source: image");
        }
        else if (ARsource == (int)ARsources.mount)
        {
            update.AppendLine("Target source: mount");
        }
        
        return update.ToString();
    }
}
