using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LOText
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
public class LOTexts
{
    public List<LOText> loTexts;

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
        LOText loText = loTexts.FirstOrDefault(lo => lo.lOindex == LO);
        if (loText != null)
            return loText.introductionText;
        return "";
    }
    public int GetLastLO()
    {
        // return the number of LO in the list
        return loTexts.Count();
    }

}