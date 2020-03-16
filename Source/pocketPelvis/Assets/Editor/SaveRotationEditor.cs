using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveRotation))]
public class SaveRotationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SaveRotation mytarget = (SaveRotation)target;
        string saveMessage = "";

        /*EditorGUILayout.IntField("Learning Objectives Index", mytarget.learningObjectiveIndex);
        EditorGUILayout.IntField("Step Index", mytarget.stepIndex);*/
        DrawDefaultInspector();
        EditorGUILayout.LabelField("Rotation", QuaternionToV4(mytarget.rotationData).ToString());
        if (saveMessage.Length>0) {
            EditorGUILayout.HelpBox(saveMessage, MessageType.Info);
        }
        if (GUILayout.Button("Save Rotation Data",GUILayout.Height(80)))
        {
            saveMessage=mytarget.SaveRotationData();
        }
    }

    Vector4 QuaternionToV4(Quaternion rot)
    {
        return new Vector4(rot.x, rot.y, rot.z, rot.w);
    }
}
