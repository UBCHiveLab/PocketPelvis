using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InfoText
{
    public int LO;
    public List<string> stepInfoText;
}
[System.Serializable]
public class InfoTexts
{
    public List<InfoText> infoTexts;

    public string FindText(int LO,int step)
    {
        foreach(InfoText infotext in infoTexts)
        {
            if (infotext.LO == LO&&step<= infotext.stepInfoText.Count)
            {
                return infotext.stepInfoText[step - 1];
            }
        }
        return null;
    }
}