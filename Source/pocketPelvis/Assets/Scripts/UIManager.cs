using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject LOv, LOh;

    private void Update()
    {
        if(LOv.activeInHierarchy|| LOh.activeInHierarchy)
        {
            Debug.Log(Input.deviceOrientation);
            if(Input.deviceOrientation==DeviceOrientation.Portrait|| Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
            {
                LOv.SetActive(false);
                LOh.SetActive(true);
            }
            else
            {
                LOv.SetActive(true);
                LOh.SetActive(false);
            }
        }
    }
}
