using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public struct LOText
{
    public int lOindex;
    public string introductionText;
    public List<StepText> stepTexts;

}
[System.Serializable]
public struct StepText
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
        // look for lo index and step index, if exists return the step text; otherwise, return StepText's default value
        List<StepText> stepTexts = loTexts.FirstOrDefault(lo => lo.lOindex == LO).stepTexts;
        return stepTexts != null ? stepTexts.FirstOrDefault(st => st.stepIndex == step) : default(StepText);
    }

    public string GetIntroductionForLO(int LO)
    {
        LOText loText = loTexts.FirstOrDefault(lo => lo.lOindex == LO);
        return !loText.Equals(default(LOText)) ? loText.introductionText : "";
    }

    public int GetLastLO()
    {
        // return the number of LO in the list
        return loTexts.Count();
    }

}