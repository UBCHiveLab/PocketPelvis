using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomImageTrackableEventHandler : DefaultTrackableEventHandler
{
    enum TRACKINGTYPE { MODEL, IMAGE, MOUNT, NONE}
    enum TRACKINGSTATE { NO, YES }

    protected override void OnTrackingFound()
    {
        //base.OnTrackingFound();
        if (null == this.transform.Find("arPosRef"))
        {
            Debug.Log("cant find arPosRef image");
        }
        EventManager.Instance.publishVuforiaModelEvent(Enum.GetName(typeof(TRACKINGSTATE), TRACKINGSTATE.YES), System.Enum.GetName(typeof(TRACKINGTYPE), TRACKINGTYPE.IMAGE), this.transform.Find("arPosRef"));
    }

    protected override void OnTrackingLost()
    {
        //base.OnTrackingLost();
        EventManager.Instance.publishVuforiaModelEvent(Enum.GetName(typeof(TRACKINGSTATE), TRACKINGSTATE.NO), System.Enum.GetName(typeof(TRACKINGTYPE), TRACKINGTYPE.IMAGE), this.transform.Find("arPosRef"));
    }
}
