using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoText
{
    public int LO;
    public string introductionText;
    public List<string> stepInfoText;
    public List<string> fitInfo;
}
[System.Serializable]
public class LoTexts
{
    public List<LoText> infoTexts;

    public List<string> FindInfoText(int LO,int step)
    {
        List<string> result = new List<string>();
        foreach(LoText infotext in infoTexts)
        {
            if (infotext.LO == LO&&step<= infotext.stepInfoText.Count)
            {
                //return a list of string that has the texts of corresponding step
                result.Add(infotext.stepInfoText[step - 1]);
                result.Add(infotext.fitInfo[step - 1]);
                return result;
            }
        }
        return null;
    }

    public string GetIntroductionForLO(int learningObjective)
    {
        foreach(LoText loTextContent in infoTexts)
        {
            if (loTextContent.LO == learningObjective)
            {
                return loTextContent.introductionText;
            }
        }

        return "";
    }
}