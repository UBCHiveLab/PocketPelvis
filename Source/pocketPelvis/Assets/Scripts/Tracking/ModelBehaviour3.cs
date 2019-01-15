using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class ModelBehaviour3 : MonoBehaviour {

    //Most updated ModelBehaviour. Attach to surface level GO that has all relevant GOs as children.
    //works with customtrackabledeventhandler
    
    Transform modelObjectTransform;

    Transform refModelTransform;
    Transform refImageTransform;
    Transform refMountTransform;
    bool modelState;
    bool imageState;
    bool mountState;
    TRACKINGTYPE currentTrackingType;
    enum TRACKINGTYPE { MODEL, IMAGE, MOUNT, NONE }
    TRACKINGSTATE currentTrackingState;
    enum TRACKINGSTATE { NO, YES }

    enum SFXTYPE { CLICKYES, CLICKNO, RECOGYES, RECOGNO }

    StringBuilder update;

    // Use this for initialization
    void Start()
    {
        modelObjectTransform = this.GetComponent<Transform>();

        modelState = false;
        imageState = false;
        mountState = false;

        currentTrackingType = TRACKINGTYPE.NONE;
        currentTrackingState = TRACKINGSTATE.NO;
        
        EventManager.Instance.VuforiaModelEvent += OnVuforiaModelEvent;
    }

    public void OnVuforiaModelEvent(string foundOrLost, string modelType, Transform updatedParentTransform)
    {
        //Debug.Log("found?: " + foundOrLost + " , type: " + modelType);

        TRACKINGTYPE updatedTrackingType = (TRACKINGTYPE)Enum.Parse(typeof(TRACKINGTYPE), modelType);
        TRACKINGSTATE updatedTrackingState = (TRACKINGSTATE)Enum.Parse(typeof(TRACKINGSTATE), foundOrLost);

        if (updatedTrackingState == TRACKINGSTATE.YES)
        {
            switch (updatedTrackingType)
            {
                case TRACKINGTYPE.MODEL:
                    modelState = true;
                    refModelTransform = updatedParentTransform;
                    parent(refModelTransform);
                    currentTrackingType = updatedTrackingType;
                    break;
                case TRACKINGTYPE.IMAGE:
                    imageState = true;
                    refImageTransform = updatedParentTransform;
                    if (!modelState)
                    {
                        parent(refImageTransform);
                        currentTrackingType = updatedTrackingType;
                    }
                    break;
                case TRACKINGTYPE.MOUNT:
                    mountState = true;
                    refMountTransform = updatedParentTransform;
                    if (!modelState && !imageState)
                    {
                        parent(refMountTransform);
                        currentTrackingType = updatedTrackingType;
                    }
                    break;
            }

            if (currentTrackingState == TRACKINGSTATE.NO)
            {
                currentTrackingState = updatedTrackingState;
                EventManager.Instance.publishRecognitionStateChangedEvent(foundOrLost);
            }
        }
        else if (updatedTrackingState == TRACKINGSTATE.NO)
        {
            switch (updatedTrackingType)
            {
                case TRACKINGTYPE.MODEL:
                    modelState = false;
                    if (imageState)
                    {
                        parent(refImageTransform);
                        currentTrackingType = TRACKINGTYPE.IMAGE;
                    }
                    else if (mountState)
                    {
                        parent(refMountTransform);
                        currentTrackingType = TRACKINGTYPE.MOUNT;
                    }
                    else
                    {
                        unparent();
                        EventManager.Instance.publishRecognitionStateChangedEvent(foundOrLost);
                        currentTrackingState = updatedTrackingState;
                        currentTrackingType = TRACKINGTYPE.NONE;
                    }
                    break;
                case TRACKINGTYPE.IMAGE:
                    imageState = false;
                    if (modelState)
                    {
                        parent(refModelTransform);
                        currentTrackingType = TRACKINGTYPE.MODEL;
                    }
                    else if (mountState)
                    {
                        parent(refMountTransform);
                        currentTrackingType = TRACKINGTYPE.MOUNT;
                    }
                    else
                    {
                        unparent();
                        EventManager.Instance.publishRecognitionStateChangedEvent(foundOrLost);
                        currentTrackingState = updatedTrackingState;
                        currentTrackingType = TRACKINGTYPE.NONE;
                    }
                    break;
                case TRACKINGTYPE.MOUNT:
                    imageState = false;
                    if (modelState)
                    {
                        parent(refModelTransform);
                        currentTrackingType = TRACKINGTYPE.MODEL;
                    }
                    else if (imageState)
                    {
                        parent(refImageTransform);
                        currentTrackingType = TRACKINGTYPE.IMAGE;
                    }
                    else
                    {
                        unparent();
                        EventManager.Instance.publishRecognitionStateChangedEvent(foundOrLost);
                        currentTrackingState = updatedTrackingState;
                        currentTrackingType = TRACKINGTYPE.NONE;
                    }
                    break;
            }
        }
    }

    private void parent(Transform parentTransform)
    {
        modelObjectTransform.position = parentTransform.position;
        modelObjectTransform.rotation = parentTransform.rotation;
        modelObjectTransform.SetParent(parentTransform);
    }

    private void unparent()
    {
        modelObjectTransform.SetParent(null);
        modelObjectTransform.position = new Vector3(0f, 0f, -1f);
    }
}
