/*
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
    public List<string> guideViewOrientation;
    public List<LabelTexts> labelTexts;

}
[System.Serializable]
public class LabelTexts
{
    public string[] labelText;
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
            int infoTextIndex = step - 1;
            if (infotext.LO == LO && infoTextIndex >= 0 && infoTextIndex < infotext.stepInfoText.Count)
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
    public GuideViewOrientation GetGuideViewOrientation(int LO, int step)
    {
        GuideViewOrientation result;
        LoText foundLO = infoTexts[LO - 1];
        if (foundLO != null && step <= foundLO.guideViewOrientation.Count && step != 0)
        {
            if (foundLO.guideViewOrientation[step - 1] != null)
            {
                result = ParseGuideViewOrientation(foundLO.guideViewOrientation[step - 1]);
                Debug.Log("Current Guide View:" + result.ToString());

                return result;
            }

        }
        return GuideViewOrientation.NoGuideView;


    }
    private GuideViewOrientation ParseGuideViewOrientation(string text)
    {
        //determine if the string can be parsed
        if (System.Enum.IsDefined(typeof(GuideViewOrientation), text))
            return (GuideViewOrientation)System.Enum.Parse(typeof(GuideViewOrientation), text);
        else return GuideViewOrientation.NoGuideView;
    }
    public string[] GetLabelText(int LO, int step)
    {
        string[] labelText;
        LoText infoText = infoTexts.Find(x => x.LO == LO);

        if (infoText != null)
        {
            if (infoText.labelTexts != null && infoText.labelTexts.Count >= step && step != 0)
            {
                labelText = infoText.labelTexts[step - 1].labelText;

                return labelText;
            }

        }

        return null;

    }
}
*/