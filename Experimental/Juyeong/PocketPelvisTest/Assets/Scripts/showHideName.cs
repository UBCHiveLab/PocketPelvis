using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHideName : MonoBehaviour {

    public GameObject[] names;
    private bool active = true;

	// Use this for initialization
	void Start () {
        // fill in array with objects that are parts name
        names = GameObject.FindGameObjectsWithTag("partsName");
    }
    
    public void TaskOnClick()
    {
        // activate/deactivate all part names 
        foreach (GameObject name in names)
        {
            if (active)
            {
                name.SetActive(false);               
            } else
            {
                name.SetActive(true);
            }

        }

        // change accumalator value so the nxt btn click can deactivate/activate accordingly
        if (names[0] != null)
        {
            active = names[0].activeSelf;
        }
    }

    // Update is called once per frame
    // void Update () {
	//	
	// }
}
