using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBack : MonoBehaviour
{

    //This is script is for controlling the model's back side

    private ModelTrackingManager modelTrackingManager;

    bool isBack = false;

    // Start is called before the first frame update
    void Start()
    {
        modelTrackingManager = FindObjectOfType<ModelTrackingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCheckBack()
    {

        modelTrackingManager.StopTracking();
        Debug.Log("clicked");
        isBack = !isBack;

        //condition: if current state is frontal, change it to back and vice versa
        if (isBack) {
            modelTrackingManager.SetGuideViewOrientation(GuideViewOrientation.Back);
        }
        else
        {
            modelTrackingManager.SetGuideViewOrientation(GuideViewOrientation.Frontal);
        }

        
        modelTrackingManager.StartTracking();
        
    }
}
