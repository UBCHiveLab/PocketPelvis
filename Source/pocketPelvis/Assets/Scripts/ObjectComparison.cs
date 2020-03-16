using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectComparison : MonoBehaviour
{
    public GameObject a, b;
    public float angleDifference, positionDifference;
    private Vector3 positiondiff;
    // Start is called before the first frame update
    void Start()
    {
        positiondiff = new Vector3(positionDifference, positionDifference, positionDifference);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(a.transform.position, b.transform.position) < positionDifference)
        {
            Debug.Log("Position similar");
            if (Quaternion.Angle(a.transform.rotation, b.transform.rotation) < angleDifference)
            {
                Debug.Log("Well done");
            }
        }
    }
}
