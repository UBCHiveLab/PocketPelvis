using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoTextParser
{
    public LoTexts infoTexts;

    private LoTexts PareseLoText()
    {
        TextAsset load;
        load = Resources.Load<TextAsset>("GuideModeData/LOText");
        LoTexts loadTexts = null;
        if (load != null)
        {
            loadTexts = JsonUtility.FromJson<LoTexts>(load.text);
        }
        return loadTexts;
    }

    public static GuideViewOrientation ParseGuideViewOrientation(string text)
    {
        //determine if the string can be parsed
        if (System.Enum.IsDefined(typeof(GuideViewOrientation), text))
            return (GuideViewOrientation)System.Enum.Parse(typeof(GuideViewOrientation), text);
        else return GuideViewOrientation.NoGuideView;
    }
    
}
