using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InfoText
{
    public int LO;
    public List<string> stepInfoText;
    public List<string> fitInfo;
}
[System.Serializable]
public class InfoTexts
{
    public List<InfoText> infoTexts;

    public List<string> FindText(int LO,int step)
    {
        List<string> result = new List<string>();
        foreach(InfoText infotext in infoTexts)
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
}