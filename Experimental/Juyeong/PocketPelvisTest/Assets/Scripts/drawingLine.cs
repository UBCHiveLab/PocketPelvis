﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingLine : MonoBehaviour {

    // code ripped directly from stack overflow

    GameObject partPelvis;
    GameObject namePartPelvis;

    public bool sphereHasGravity = false;
    private Collider coll;
    private Renderer rend;
    private SpringJoint springJoint;
    public Material lines;

    LineRenderer lineRenderer0_2;

    // Use this for initialization
    public void Start () {
        // this is the part you have to change. match name of 2 objects to the Find methods below
        partPelvis = GameObject.Find("BezierCurve");
        namePartPelvis = GameObject.Find("pedendalNerve");
        // Spawn a line and set it up
        GameObject line0_2 = new GameObject();
        lineRenderer0_2 = line0_2.AddComponent<LineRenderer>();
        lineRenderer0_2.material = lines;
        lineRenderer0_2.widthMultiplier = 0.0482773661501f;
        lineRenderer0_2.SetPosition(0, partPelvis.transform.position);
        lineRenderer0_2.SetPosition(1, namePartPelvis.transform.position);
        float alpha0_2 = .9f;
        Gradient gradient0_2 = new Gradient();
        gradient0_2.SetKeys(
            new GradientColorKey[] { new GradientColorKey(new Color32(171, 166, 164, 255), 0.0f), new GradientColorKey(new Color32(105, 150, 187, 255), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha0_2, 0.0f), new GradientAlphaKey(alpha0_2, 1.0f) }
        );
        lineRenderer0_2.colorGradient = gradient0_2;
        lineRenderer0_2.useWorldSpace = true;

    }

    // Update is called once per frame
    public void Update () {
        lineRenderer0_2.SetPosition(0, partPelvis.transform.position);
        lineRenderer0_2.SetPosition(1, namePartPelvis.transform.position);

    }
}