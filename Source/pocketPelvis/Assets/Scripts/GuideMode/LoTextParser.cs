using UnityEngine;

public class LOTextParser
{
    public LOTexts loTexts;

    public LOTextParser()
    {
        loTexts = PareseLoText();
    }

    private LOTexts PareseLoText()
    {
        TextAsset load;
        load = Resources.Load<TextAsset>("GuideModeData/LOTexts");
        LOTexts loadTexts = null;
        
        if (load != null)
        {
            loadTexts = JsonUtility.FromJson<LOTexts>(load.text);
       
        }
        return loadTexts;
    }

    public static GuideViewOrientation ParseGuideViewOrientation(string text)
    {
        // determine if the string can be parsed
        // could use Enum.TryParse when using .NET4
        // default guideview will be frontal view
        if (System.Enum.IsDefined(typeof(GuideViewOrientation), text))
            return (GuideViewOrientation)System.Enum.Parse(typeof(GuideViewOrientation), text);
        else return GuideViewOrientation.Frontal;

    }
    
}
