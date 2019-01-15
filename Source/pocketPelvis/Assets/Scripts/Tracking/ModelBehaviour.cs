using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ModelBehaviour : MonoBehaviour {

    //Super outdated. Don't use this.

    private float waitTime = 4.0f;
    private float timeStep = 0.01f;

    Renderer thisObjectRenderer;
    float timeElapsed;
    GameObject[] arObjects_model;
    GameObject[] arObjects_image;
    GameObject[] arObjects_mount;
    int ARsource;
    enum ARsources { model, image, mount, none};

    int ARObjectState;
    enum ARObjectStates { no, justFoundFirstTime, justFound, yes, justLost};
    float lastRecogActiveARObject;
    float firstRecogActiveARObject;
    GameObject activeARObject;

    StringBuilder update;

    float lastPosX = 0f;
    float lastPosY = 0f;
    float lastPosZ = 0f;
    float lastRotX = 0f;
    float lastRotY = 0f;
    float lastRotZ = 0f;

    // Use this for initialization
    void Start () {

        thisObjectRenderer = this.gameObject.GetComponent<Renderer>();
        thisObjectRenderer.enabled = false;
        timeElapsed = 0f;
        arObjects_model = GameObject.FindGameObjectsWithTag("arObject_model");
        arObjects_image = GameObject.FindGameObjectsWithTag("arObject_image");
        arObjects_mount = GameObject.FindGameObjectsWithTag("arObject_mount");

        ARsource = (int)ARsources.none;
        ARObjectState = (int)ARObjectStates.no;
        lastRecogActiveARObject = 0f;

        update = new StringBuilder("");
        
        InvokeRepeating("AddValueEveryTimeStep", 0f, timeStep);
    }
	
	// Update is called once per frame
	void Update () {

        //check and save active AR object
        bool foundActive = false;

        foreach (GameObject arObject in arObjects_model) {
            if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
            {
                foundActive = true;
                ARsource = (int)ARsources.model;

                activeARObject = arObject;
                lastRecogActiveARObject = timeElapsed;

                if (ARObjectState == (int)ARObjectStates.justLost)
                {
                    ARObjectState = (int)ARObjectStates.justFound;
                    firstRecogActiveARObject = timeElapsed;
                }
                else if (ARObjectState == (int)ARObjectStates.no)
                {
                    ARObjectState = (int)ARObjectStates.justFoundFirstTime;
                    firstRecogActiveARObject = timeElapsed;
                }
                else if (ARObjectState == (int)ARObjectStates.justFound && timeElapsed - firstRecogActiveARObject >= waitTime)
                {
                    ARObjectState = (int)ARObjectStates.yes;
                } 
            }
        }

        if (foundActive == false)
        {
            foreach (GameObject arObject in arObjects_image)
            {
                if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
                {
                    foundActive = true;
                    ARsource = (int)ARsources.image;

                    activeARObject = arObject;
                    lastRecogActiveARObject = timeElapsed;

                    if (ARObjectState == (int)ARObjectStates.justLost)
                    {
                        ARObjectState = (int)ARObjectStates.justFound;
                        firstRecogActiveARObject = timeElapsed;
                    }
                    else if (ARObjectState == (int)ARObjectStates.no)
                    {
                        ARObjectState = (int)ARObjectStates.justFoundFirstTime;
                        firstRecogActiveARObject = timeElapsed;
                    }
                    else if (ARObjectState == (int)ARObjectStates.justFound && timeElapsed - firstRecogActiveARObject >= waitTime)
                    {
                        ARObjectState = (int)ARObjectStates.yes;
                    }
                }
            }
        }

        if (foundActive == false)
        {
            foreach (GameObject arObject in arObjects_mount)
            {
                if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
                {
                    foundActive = true;
                    ARsource = (int)ARsources.mount;

                    activeARObject = arObject;
                    lastRecogActiveARObject = timeElapsed;

                    if (ARObjectState == (int)ARObjectStates.justLost)
                    {
                        ARObjectState = (int)ARObjectStates.justFound;
                        firstRecogActiveARObject = timeElapsed;
                    }
                    else if (ARObjectState == (int)ARObjectStates.no)
                    {
                        ARObjectState = (int)ARObjectStates.justFoundFirstTime;
                        firstRecogActiveARObject = timeElapsed;
                    }
                    else if (ARObjectState == (int)ARObjectStates.justFound && timeElapsed - firstRecogActiveARObject >= waitTime)
                    {
                        ARObjectState = (int)ARObjectStates.yes;
                    }
                }
            }
        }

        if (foundActive == false && timeElapsed - lastRecogActiveARObject <= waitTime)
        {
            ARObjectState = (int)ARObjectStates.justLost;
            ARsource = (int)ARsources.none;
        } else if (foundActive == false)
        {
            ARObjectState = (int)ARObjectStates.no;
            ARsource = (int)ARsources.none;
        }

        //apply rot/pos to model according to state

        if (ARObjectState == (int)ARObjectStates.yes || ARObjectState == (int)ARObjectStates.justFoundFirstTime)
        {
            //ChangeAlpha(activeARObject.GetComponent<Renderer>().material, 0f);
            thisObjectRenderer.enabled = true;
            this.gameObject.transform.rotation = activeARObject.transform.rotation;
            this.gameObject.transform.position = activeARObject.transform.position;
        } else if (ARObjectState == (int)ARObjectStates.justLost)
        {
            lastPosX = this.gameObject.transform.position.x;
            lastPosY = this.gameObject.transform.position.y;
            lastPosZ = this.gameObject.transform.position.z;
            lastRotX = this.gameObject.transform.eulerAngles.x;
            lastRotY = this.gameObject.transform.eulerAngles.y;
            lastRotZ = this.gameObject.transform.eulerAngles.z;
        } else if (ARObjectState == (int)ARObjectStates.no)
        {
            thisObjectRenderer.enabled = false;
        } else if (ARObjectState == (int)ARObjectStates.justFound)
        {
            thisObjectRenderer.enabled = true;

            float timeDifferenceRatio = (timeElapsed - firstRecogActiveARObject)/waitTime;
            /*
            float currentPosX = lastPosX * (1.0f - timeDifferenceRatio) + activeARObject.transform.position.x * timeDifferenceRatio;
            float currentPosY = lastPosY * (1.0f - timeDifferenceRatio) + activeARObject.transform.position.y * timeDifferenceRatio;
            float currentPosZ = lastPosZ * (1.0f - timeDifferenceRatio) + activeARObject.transform.position.z * timeDifferenceRatio;
            float currentRotX = lastRotX * (1.0f - timeDifferenceRatio) + activeARObject.transform.eulerAngles.x * timeDifferenceRatio;
            float currentRotY = lastRotY * (1.0f - timeDifferenceRatio) + activeARObject.transform.eulerAngles.y * timeDifferenceRatio;
            float currentRotZ = lastRotZ * (1.0f - timeDifferenceRatio) + activeARObject.transform.eulerAngles.z * timeDifferenceRatio;
            this.gameObject.transform.position = new Vector3(currentPosX, currentPosY, currentPosZ);
            this.gameObject.transform.eulerAngles = new Vector3(currentRotX, currentRotY, currentRotZ);
            */
            Vector3 oldPos = new Vector3(lastPosX, lastPosY, lastPosZ);
            //Vector3 oldRot = new Vector3(lastRotX, lastRotY, lastRotZ);
            this.gameObject.transform.position = Vector3.Lerp(oldPos, activeARObject.transform.position, timeDifferenceRatio);

            float currentRotX = Mathf.LerpAngle(lastRotX, activeARObject.transform.eulerAngles.x, timeDifferenceRatio);
            float currentRotY = Mathf.LerpAngle(lastRotY, activeARObject.transform.eulerAngles.y, timeDifferenceRatio);
            float currentRotZ = Mathf.LerpAngle(lastRotZ, activeARObject.transform.eulerAngles.z, timeDifferenceRatio);
            this.gameObject.transform.eulerAngles = new Vector3(currentRotX, currentRotY, currentRotZ);
        }
    }

    private void AddValueEveryTimeStep()
    {
        timeElapsed = timeElapsed + timeStep;
    }

    private void ChangeAlpha(Material mat, float alphaValue)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        mat.SetColor("_Color", newColor);
    }

    public string updates()
    {
        update = new StringBuilder("");
        
        if (ARObjectState == (int)ARObjectStates.no)
        {
            update.AppendLine("Object Lost");
        } else if (ARObjectState == (int)ARObjectStates.justFoundFirstTime || ARObjectState == (int)ARObjectStates.justFound || ARObjectState == (int)ARObjectStates.yes)
        {
            update.AppendLine("Object found");
        }
        else if (ARObjectState == (int)ARObjectStates.justLost)
        {
            float timeToCompleteLost = waitTime - (timeElapsed - lastRecogActiveARObject);
            timeToCompleteLost = (float)Math.Round(Convert.ToDecimal(timeToCompleteLost), 0);
            update.AppendLine("Target lost \n Object lost in " + timeToCompleteLost.ToString() + " second(s)");
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
