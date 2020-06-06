using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSynchronizer : MonoBehaviour
{
    public Sprite achievedSprite, notDoneSprite, inProgressSprite, inProgressAndAchievedSprite;
    private LearningObject LO;
    private const int INTRO_STEP = 0;

    // Start is called before the first frame update
    void Start()
    {
        LO = LearningObjectives.instance.learningObject;
    }

    // Update is called once per frame
    void Update()
    {
        // update the sprites indicating the user's progress through the learning objectives
        // the learning objective step that the user last selected will be highlighted with an
        // 'inProgress' or 'inProgressAndAchieved' sprite
        for(int i = 0; i < LO.learningObjects.Count; i++)
        {
            Transform learningObjectTransform = transform.GetChild(i);
            LOs learingObject = LO.learningObjects[i];
            int learningObjective = learingObject.id;
            List<bool> achievmentForSteps = learingObject.learningObjectAchievement;

            for (int stepIndex = 0; stepIndex < achievmentForSteps.Count; stepIndex++)
            {
                Image currentImg = learningObjectTransform.GetChild(stepIndex).GetComponent<Image>();
                int step = stepIndex + 1;

                if (achievmentForSteps[stepIndex])
                {
                    // the step of the LO has been achieved. Check if the step is 'inProgress' or not
                    currentImg.sprite = StepIsInProgress(learningObjective, step) ? inProgressAndAchievedSprite : achievedSprite;
                }
                else
                {
                    // the step of the LO hasn't been achieved. Check if the step is 'inProgress' or not
                    currentImg.sprite = StepIsInProgress(learningObjective, step) ? inProgressSprite : notDoneSprite;
                }
            }
        }
    }

    private bool StepIsInProgress(int learningObjective, int step)
    {
        // There is no icon in the menu for the learning objective introduction. When the user is on the introduction,
        // mark their progress as the first step of that learning objective
        bool currentStepIsIntro = step == 1 && LO.lastStep == INTRO_STEP;
        bool currentStepIsSelected = step == LO.lastStep;
        return (currentStepIsIntro || currentStepIsSelected) && learningObjective == LO.lastLO;
    }
}
