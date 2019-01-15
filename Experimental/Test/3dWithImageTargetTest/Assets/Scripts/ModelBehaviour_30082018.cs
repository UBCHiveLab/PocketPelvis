using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBehaviour_30082018 : MonoBehaviour
{

    int waitTime = 5;
    float transitionStep = 0.01f;

    Renderer thisObjectRenderer;
    int timeElapsed;
    float timeElapsed_transition;
    GameObject[] arObjects;

    int ARObjectState;
    enum hasActiveARObject { no, justFoundFirstTime, justFound, yes, justLost };
    int lastRecogActiveARObject;
    int firstRecogActiveARObject;
    GameObject activeARObject;

    float lastPosX = 0f;
    float lastPosY = 0f;
    float lastPosZ = 0f;
    float lastRotX = 0f;
    float lastRotY = 0f;
    float lastRotZ = 0f;

    // Use this for initialization
    void Start()
    {

        thisObjectRenderer = this.gameObject.GetComponent<Renderer>();
        thisObjectRenderer.enabled = false;
        timeElapsed = 0;
        arObjects = GameObject.FindGameObjectsWithTag("arObject");

        ARObjectState = (int)hasActiveARObject.no;
        lastRecogActiveARObject = 0;

        InvokeRepeating("AddValueEverySecond", 1f, 1f);
        InvokeRepeating("AddValueTransition", 1f, transitionStep);
    }

    // Update is called once per frame
    void Update()
    {

        //check and save active AR object
        bool foundActive = false;

        foreach (GameObject arObject in arObjects)
        {
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
        }
        else if (foundActive == false)
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
        }
        else if (ARObjectState == (int)hasActiveARObject.justLost)
        {
            lastPosX = this.gameObject.transform.position.x;
            lastPosY = this.gameObject.transform.position.y;
            lastPosZ = this.gameObject.transform.position.z;
            lastRotX = this.gameObject.transform.eulerAngles.x;
            lastRotY = this.gameObject.transform.eulerAngles.y;
            lastRotZ = this.gameObject.transform.eulerAngles.z;
        }
        else if (ARObjectState == (int)hasActiveARObject.no)
        {
            thisObjectRenderer.enabled = false;
        }
        else if (ARObjectState == (int)hasActiveARObject.justFound)
        {
            thisObjectRenderer.enabled = true;
            float timeDifferenceRatio = ((float)timeElapsed_transition - (float)firstRecogActiveARObject) / (float)waitTime;
            float currentPosX = lastPosX * (1.0f - timeDifferenceRatio) + activeARObject.transform.position.x * timeDifferenceRatio;
            float currentPosY = lastPosY * (1.0f - timeDifferenceRatio) + activeARObject.transform.position.y * timeDifferenceRatio;
            float currentPosZ = lastPosZ * (1.0f - timeDifferenceRatio) + activeARObject.transform.position.z * timeDifferenceRatio;
            float currentRotX = lastRotX * (1.0f - timeDifferenceRatio) + activeARObject.transform.eulerAngles.x * timeDifferenceRatio;
            float currentRotY = lastRotY * (1.0f - timeDifferenceRatio) + activeARObject.transform.eulerAngles.y * timeDifferenceRatio;
            float currentRotZ = lastRotZ * (1.0f - timeDifferenceRatio) + activeARObject.transform.eulerAngles.z * timeDifferenceRatio;
            this.gameObject.transform.position = new Vector3(currentPosX, currentPosY, currentPosZ);
            this.gameObject.transform.eulerAngles = new Vector3(currentRotX, currentRotY, currentRotZ);

        }
    }

    private void AddValueEverySecond()
    {
        timeElapsed++;
    }

    private void AddValueTransition()
    {
        timeElapsed_transition = timeElapsed_transition + transitionStep;
    }

    private void ChangeAlpha(Material mat, float alphaValue)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        mat.SetColor("_Color", newColor);
    }
}
