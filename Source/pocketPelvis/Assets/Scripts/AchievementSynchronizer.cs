using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSynchronizer : MonoBehaviour
{
    public Sprite trueImage,falseImage;
    private LearningObject LO;
    // Start is called before the first frame update
    void Start()
    {
        LO = LearningObjectives.instance.learningObject;
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < LO.learningObjects.Count; i++)
        {
            Debug.Log(LO.learningObjects[i]);
            for(int j=0;j< LO.learningObjects[i].learningObjectAchievement.Count; j++)
            {
                if (LO.learningObjects[i].learningObjectAchievement[j])
                {
                    this.transform.GetChild(i).GetChild(j).GetComponent<Image>().sprite = trueImage;
                    //this.transform.Find((i+1).ToString() + '-' + (j+1).ToString()).GetComponent<Image>().sprite = trueImage;
                }
                else
                {
                    this.transform.GetChild(i).GetChild(j).GetComponent<Image>().sprite = falseImage;
                }
            }
        }
        
    }
}
