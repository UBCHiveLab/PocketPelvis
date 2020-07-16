using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LoText
{
    public int lOindex;
    public string introductionText;
    public List<StepText> stepTexts;

}
[System.Serializable]
public class StepText
{
    public int stepIndex;
    public string stepInfoText;
    public string fitInfoText;
    public string guideViewOrientation;
    public List<string> labelTexts;
}

[System.Serializable]
public class LoTexts
{
    public List<LoText> loTexts;

    public StepText GetStepText(int LO, int step)
    {
        // look for lo index and step index, if exists return the step text
        StepText stepText = loTexts.FirstOrDefault(lo => lo.lOindex == LO).stepTexts.FirstOrDefault(st => st.stepIndex == step);
        if (stepText != null)
        {
            return stepText;
        }
        return null;
    }

    public string GetIntroductionForLO(int LO)
    {
        LoText loText = loTexts.FirstOrDefault(lo => lo.lOindex == LO);
        if (loText != null)
            return loText.introductionText;
        return "";
    }
    //public GuideViewOrientation GetGuideViewOrientation(int LO, int step)
    //{
    //    GuideViewOrientation result;
    //    LoText foundLO = infoTexts[LO - 1];
    //    if (foundLO != null && step <= foundLO.guideViewOrientation.Count && step != 0)
    //    {
    //        if (foundLO.guideViewOrientation[step - 1] != null)
    //        {
    //            result = ParseGuideViewOrientation(foundLO.guideViewOrientation[step - 1]);
    //            Debug.Log("Current Guide View:" + result.ToString());

    //            return result;
    //        }

    //    }
    //    return GuideViewOrientation.NoGuideView;


    //}
    //private GuideViewOrientation ParseGuideViewOrientation(string text)
    //{
    //    //determine if the string can be parsed
    //    if (System.Enum.IsDefined(typeof(GuideViewOrientation), text))
    //        return (GuideViewOrientation)System.Enum.Parse(typeof(GuideViewOrientation), text);
    //    else return GuideViewOrientation.NoGuideView;
    //}

}