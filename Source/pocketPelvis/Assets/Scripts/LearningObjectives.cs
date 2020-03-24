using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningObjectives : MonoBehaviour
{
   

    public LearningObject learningObject = new LearningObject();
    private string jsonSavePath;
    public static LearningObjectives instance; 

    private void Awake()
    {

        #if UNITY_EDITOR
                jsonSavePath = Application.dataPath + "/SaveData/saveAchievements.json";
        #elif UNITY_ANDROID || UNITY_IOS
                jsonSavePath = Application.persistentDataPath + "/saveAchievements.json";
        #endif
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
        LoadLOs();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ResetLOs();
            SaveLOs();
        }
        Debug.Log("Current lo step:" + learningObject.lastLO + "-" + learningObject.lastStep);
    }
    public void SaveLOs()
    {
        string save = JsonUtility.ToJson(learningObject);

        System.IO.File.WriteAllText(jsonSavePath, save);
    }
    /// <summary>
    /// Load learning objects from saved json file
    /// </summary>
    public void LoadLOs()
    {
        string load;
        if (System.IO.File.Exists(jsonSavePath))
        {
            load = System.IO.File.ReadAllText(jsonSavePath);
        }
        else
        {
            load = System.IO.File.ReadAllText(Application.dataPath + "/SaveData/emptyData.json");
        }
        
        learningObject= JsonUtility.FromJson<LearningObject>(load);
    }
    public void ResetLOs()
    {
        foreach(LOs lobject in learningObject.learningObjects)
        {
            for(int i = 0; i < lobject.learningObjectAchievement.Count; i++)
            {
                lobject.learningObjectAchievement[i] = false;
            }
        }
        learningObject.isNewUser = true;
        learningObject.lastLO = 0;
        learningObject.lastStep = 0;
        SaveLOs();
    }
}
[System.Serializable]
public class LearningObject
{
    public bool isNewUser;
    public int lastLO;
    public int lastStep;
    public List<LOs> learningObjects = new List<LOs>();
    
}

[System.Serializable]
public class LOs
{
    public string objective;
    public List<bool> learningObjectAchievement = new List<bool>();
}
