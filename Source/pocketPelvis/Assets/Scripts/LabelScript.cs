using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using TMPro;
using System;
using System.Linq;



public enum SearchingTextType
{
    upperText,
    bottomText
}



[RequireComponent(typeof(MeshCollider))]
public class LabelScript : MonoBehaviour
{
    
    public Color textColor=Color.black;
    
    public string upperText, bottomText;
    public bool showAllLabel=true;

    public float dotSize=0.29f, textWindowSize=0.65f, lineWidthMultiplier=0.1f;

    public int index=0;
    public Vector3 dotPosition, textWindowPosition;

    
    public List<LabelTextManager> labels;
    private GameObject labelPrefab;

    public bool toggleLabel = true;

    
    //Set default value for label maker
    private void Reset()
    {

        labelPrefab = Resources.Load<GameObject>("Prefabs/Label") as GameObject;
        labels = new List<LabelTextManager>();
        upperText = "";
        bottomText = "";
    }

    public void ChangeLabelPrefab()
    {

#if UNITY_EDITOR
        //set prefab dirty
        if (labelPrefab == null)
        {
            labelPrefab = Resources.Load<GameObject>("Prefabs/Label") as GameObject;
        }
        LabelTextManager prefabLabelManager = labelPrefab.GetComponent<LabelTextManager>();


        Undo.RecordObject(labelPrefab.transform, "make change to the line width, txetwindow and dot size");
        prefabLabelManager.SetDotSize(dotSize);
        prefabLabelManager.SetTextWindowSize(textWindowSize);
        prefabLabelManager.SetLineWidth(lineWidthMultiplier);
        prefabLabelManager.SetTextColor(textColor);
        PrefabUtility.RecordPrefabInstancePropertyModifications(labelPrefab.transform);

        //change line width, color, window size and text size in exsisting labels
        if (labels.Count > 0)
        {
            labels.ForEach(x => {
                x.SetDotSize(dotSize);
                x.SetTextWindowSize(textWindowSize);
                x.SetLineWidth(lineWidthMultiplier);
                x.SetTextColor(textColor);
            });

        }
#endif
    }


    public void AddLabel(Vector3 dotPosition, Vector3 surfaceNormal)
    {

        if (!string.IsNullOrEmpty(bottomText))
        {
            if (labelPrefab == null)
                labelPrefab = Resources.Load<GameObject>("Prefabs/Label") as GameObject;
            GameObject newlabel = Instantiate(labelPrefab, this.transform);
            LabelTextManager newLabelManager = newlabel.GetComponent<LabelTextManager>();

            if (index == 0)
                index = labels.Count+1;

            textWindowPosition = dotPosition + surfaceNormal * 0.1f;
            //textWindowPosition = Vector3.Reflect(dotPosition, surfaceNormal * 0.05f);
            newLabelManager.NewLabel(index, upperText, bottomText,
                dotPosition, textWindowPosition, showAllLabel);
            labels.Add(newLabelManager);
        }

    }

    public void DeleteLastLabel()
    {

        if (labels.Count > 0)
        {
            LabelTextManager lastLabel = labels[labels.Count - 1];
            lastLabel.DeleteLabel();
            
        }
        
    }
    public void ReloadAllLabelInChildren()
    {
        labels = GetComponentsInChildren<LabelTextManager>(true).ToList();
        labels.ForEach(x => x.ReloadLabel());
        Debug.Log(labels.Count + " labels found");
        
    }
    public void ChangePosition(int i)
    {

        labels[i].SetTextWindowPosition(textWindowPosition);
        labels[i].SetDotPosition(dotPosition);

    }
    public void showAllLabelText(bool value)
    {
        
        if(labels.Count>0)
        labels.ForEach(x => x.GetComponent<LabelTextManager>().showLabel(value));
        
    }
    public void ToggleAllLabels()
    {

        //if (labels.Count > 0)
        //    labels.ForEach(x => x.GetComponent<LabelTextManager>().toggleLabel());
        toggleLabel = !toggleLabel;
        if (labels.Count > 0)
            labels.ForEach(x => x.GetComponent<LabelTextManager>().showLabel(toggleLabel));
    }
    // enable all the corresponding labels and change their index number
    // might need a better algorithm 
    public void EnableLabelsByText(SearchingTextType textType,params string[] texts)
    {
        labels.ForEach(x => x.gameObject.SetActive(false));
        if (texts == null)
            return;
        var textList = texts.ToList();
        List<LabelTextManager> foundLabels = new List<LabelTextManager>();
        switch (textType)
        {
            case SearchingTextType.upperText:
                foundLabels = labels.FindAll(a => textList.Any(b => b == a.thisLabel.upperText));
                foundLabels.ForEach(x =>
                {
                    x.SetIndexNumber(textList.IndexOf(x.thisLabel.upperText));
                    x.gameObject.SetActive(true);
                });


                break;
            case SearchingTextType.bottomText:
                foundLabels = labels.FindAll(a => textList.Any(b => b == a.thisLabel.bottomText));
                foundLabels.ForEach(x => {
                    x.SetIndexNumber(textList.IndexOf(x.thisLabel.bottomText));
                    x.gameObject.SetActive(true);
                });
                break;
        }
        
    }
}
