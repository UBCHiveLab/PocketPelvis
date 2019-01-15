using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBehaviour_19092018 : MonoBehaviour {

    private float waitTime = 4.0f;
    private float timeStep = 0.01f;

    Renderer thisObjectRenderer;
    float timeElapsed;
    GameObject[] arObjects;

    int ARObjectState;
    enum hasActiveARObject { no, justFoundFirstTime, justFound, yes, justLost};
    float lastRecogActiveARObject;
    float firstRecogActiveARObject;
    GameObject activeARObject;

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
        arObjects = GameObject.FindGameObjectsWithTag("arObject");

        ARObjectState = (int)hasActiveARObject.no;
        lastRecogActiveARObject = 0f;
        
        InvokeRepeating("AddValueEveryTimeStep", 0f, timeStep);
    }
	
	// Update is called once per frame
	void Update () {

        //check and save active AR object
        bool foundActive = false;

        foreach (GameObject arObject in arObjects) {
            if (arObject.gameObject.GetComponent<Renderer>().enabled == true)
            {
                foundActive = true;

                activeARObject = arObject;
                lastRecogActiveARObject = timeElapsed;

                if (ARObjectState == (int)hasActiveARObject.justLost)
                {
                    ARObjectState = (int)hasActiveARObject.justFound;
                    firstRecogActiveARObject = timeElapsed;
                }
                else if (ARObjectState == (int)hasActiveARObject.no)
                {
                    ARObjectState = (int)hasActiveARObject.justFoundFirstTime;
                    firstRecogActiveARObject = timeElapsed;
                }
                else if (ARObjectState == (int)hasActiveARObject.justFound && timeElapsed - firstRecogActiveARObject >= waitTime)
                {
                    ARObjectState = (int)hasActiveARObject.yes;
                } 
            }
        }

        if (foundActive == false && timeElapsed - lastRecogActiveARObject <= waitTime)
        {
            ARObjectState = (int)hasActiveARObject.justLost;
        } else if (foundActive == false)
        {
            ARObjectState = (int)hasActiveARObject.no;
        }

        //apply rot/pos to model according to state

        if (ARObjectState == (int)hasActiveARObject.yes || ARObjectState == (int)hasActiveARObject.justFoundFirstTime)
        {
            //ChangeAlpha(activeARObject.GetComponent<Renderer>().material, 0f);
            thisObjectRenderer.enabled = true;
            this.gameObject.transform.rotation = activeARObject.transform.rotation;
            this.gameObject.transform.position = activeARObject.transform.position;
        } else if (ARObjectState == (int)hasActiveARObject.justLost)
        {
            lastPosX = this.gameObject.transform.position.x;
            lastPosY = this.gameObject.transform.position.y;
            lastPosZ = this.gameObject.transform.position.z;
            lastRotX = this.gameObject.transform.eulerAngles.x;
            lastRotY = this.gameObject.transform.eulerAngles.y;
            lastRotZ = this.gameObject.transform.eulerAngles.z;
        } else if (ARObjectState == (int)hasActiveARObject.no)
        {
            thisObjectRenderer.enabled = false;
        } else if (ARObjectState == (int)hasActiveARObject.justFound)
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
        if (ARObjectState == (int)hasActiveARObject.no)
        {
            return "Object lost.";
        } else if (ARObjectState == (int)hasActiveARObject.justFoundFirstTime || ARObjectState == (int)hasActiveARObject.justFound || ARObjectState == (int)hasActiveARObject.yes)
        {
            return "Object found.";
        }
        else if (ARObjectState == (int)hasActiveARObject.justLost)
        {
            float timeToCompleteLost = waitTime - (timeElapsed - lastRecogActiveARObject);
            timeToCompleteLost = (float)Math.Round(Convert.ToDecimal(timeToCompleteLost), 0);
            return "Target lost. \n Object lost in " + timeToCompleteLost.ToString() + " second(s).";
        }
        return " ";
    }
}
