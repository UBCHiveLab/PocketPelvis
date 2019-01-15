using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMountTrackableEventHandler : DefaultTrackableEventHandler
{
    enum TRACKINGTYPE { MODEL, IMAGE, MOUNT, NONE }
    enum TRACKINGSTATE { NO, YES }

    protected override void OnTrackingFound()
    {
        //base.OnTrackingFound();
        EventManager.Instance.publishVuforiaModelEvent(Enum.GetName(typeof(TRACKINGSTATE), TRACKINGSTATE.YES), Enum.GetName(typeof(TRACKINGTYPE), TRACKINGTYPE.MODEL), this.gameObject.transform.Find("arPosRef"));
    }

    protected override void OnTrackingLost()
    {
        //base.OnTrackingLost();
        EventManager.Instance.publishVuforiaModelEvent(Enum.GetName(typeof(TRACKINGSTATE), TRACKINGSTATE.NO), Enum.GetName(typeof(TRACKINGTYPE), TRACKINGTYPE.MODEL), this.gameObject.transform.Find("arPosRef"));
    }
}
