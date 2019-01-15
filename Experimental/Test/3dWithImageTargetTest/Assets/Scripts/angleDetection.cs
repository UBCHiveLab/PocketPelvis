using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class angleDetection : MonoBehaviour {
    public float tolerance;
    public GameObject yeet;

    Transform cameraTransform;
    Transform objectTransform;

    float xOffset;
    float yOffset;
    float zOffset;

    StringBuilder screenUpdate;

	// Use this for initialization
	void Start () {
        cameraTransform = yeet.gameObject.transform; //VuforiaManager.Instance.ARCameraTransform;
        objectTransform = this.gameObject.transform;

        findOffset();

        screenUpdate = new StringBuilder("");
	}
	
	// Update is called once per frame
	void Update () {
        findOffset();
	}

    public string screenUpdates()
    {
        screenUpdate = new StringBuilder("");
        if (xOffset == 0)
        {
            screenUpdate.AppendLine("Your x is perfect!");
        } else {
            screenUpdate.AppendLine("Your x is off by " + xOffset.ToString());
        }

        if (yOffset == 0)
        {
            screenUpdate.AppendLine("Your y is perfect!");
        }
        else
        {
            screenUpdate.AppendLine("Your y is off by " + yOffset.ToString());
        }

        if (zOffset == 0)
        {
            screenUpdate.AppendLine("Your z is perfect!");
        }
        else
        {
            screenUpdate.AppendLine("Your z is off by " + zOffset.ToString());
        }
        
        return screenUpdate.ToString();
    }

    private void findOffset()
    {
        xOffset = findAngle(cameraTransform.eulerAngles.x, objectTransform.eulerAngles.x);
        yOffset = findAngle(cameraTransform.eulerAngles.y, objectTransform.eulerAngles.y);
        zOffset = findAngle(cameraTransform.eulerAngles.z, objectTransform.eulerAngles.z);
    }

    // havent differentiate left/right error yet
    private float findAngle(float angle1, float angle2)
    {
        float value;
        float fullRot = 360;

        if (fullRot - Mathf.Abs(angle1 - angle2) > Mathf.Abs(angle1 - angle2))
        {
            value = Mathf.Abs(angle1 - angle2);
            if (value < tolerance)
            {
                return 0f;
            } else
            {
                return Mathf.Round(value);
            }
        } else
        {
            value = fullRot - Mathf.Abs(angle1 - angle2);
            if (value < tolerance)
            {
                return 0f;
            }
            else
            {
                return Mathf.Round(value);
            }
        }
    }
}
