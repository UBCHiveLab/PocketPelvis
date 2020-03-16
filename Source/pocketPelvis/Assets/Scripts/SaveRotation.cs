using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRotation : MonoBehaviour
{
    public int learningObjectiveIndex;
    public int stepIndex;

    public Quaternion rotationData
    {
        get { return this.transform.rotation; }
    }
    public string SaveRotationData()
    {
       string jsonSavePath = Application.dataPath + "/SaveData/saveRotationData.json";
       string load;
        RotationDataList _dataList;
        if(learningObjectiveIndex==0 || stepIndex == 0)
        {
            return "Index number starting from 1";
        }
        if (System.IO.File.Exists(jsonSavePath))
        {
            load = System.IO.File.ReadAllText(jsonSavePath);
            _dataList= JsonUtility.FromJson<RotationDataList>(load);
        }
        else
        {
            _dataList = new RotationDataList();
        }
        _dataList.AddToList(learningObjectiveIndex, stepIndex, this.transform.rotation);

        string save = JsonUtility.ToJson(_dataList);
        System.IO.File.WriteAllText(jsonSavePath, save);

        return "Successfully saved";
    }

}

[System.Serializable]
public class RotationDataList
{
    public List<RotationData> rotations = new List<RotationData>();

    public void AddToList(int loIndex,int stepIndex,Quaternion rotationData)
    {
        RotationData _data= new RotationData();

        _data.loIndex = loIndex;
        _data.stepIndex = stepIndex;
        _data.serializeQuaternion(rotationData);

        bool isFound = false;

        foreach(RotationData rotation in rotations)
        {
            if(rotation.loIndex== _data.loIndex && rotation.stepIndex== _data.stepIndex)
            {
                rotation.rotationx = _data.rotationx;
                rotation.rotationy = _data.rotationy;
                rotation.rotationz = _data.rotationz;
                rotation.rotationw = _data.rotationw;
                isFound = true;
            }
        }
        if (!isFound)
        {
            rotations.Add(_data);
        }

    }
}

[System.Serializable]
public class RotationData
{
    public int loIndex;
    public int stepIndex;
    public float rotationx,rotationy,rotationz,rotationw;

    public void serializeQuaternion(Quaternion rotation)
    {
        rotationx = rotation.x;
        rotationy = rotation.y;
        rotationz = rotation.z;
        rotationw = rotation.w;
    }

}