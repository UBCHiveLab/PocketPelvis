/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSynchronizer : MonoBehaviour
{
    public Sprite achievedSprite, notDoneSprite, inProgressSprite, inProgressAndAchievedSprite;
    private LearningObjectives loData;
    private ButtonInteractivityController buttonInteractivityController;

    // Start is called before the first frame update
    void Start()
    {
        loData = LearningObjectives.instance;
        buttonInteractivityController = GetComponentInParent<ButtonInteractivityController>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the sprites indicating the user's progress through the learning objectives. The learning objective
        // step that the user last selected will be highlighted with an 'inProgress' or 'inProgressAndAchieved' sprite
        for (int lo = 1; lo <= loData.GetNumberOfLearningObjectives(); lo++)
        {
            // transform children are 0-base indexed
            Transform learningObjectiveTransform = transform.GetChild(lo - 1);

            // the introduction step does not have an achievement associated with it, so start from step 1
            for (int step = 1; step <= loData.GetNumberOfSteps(lo); step++)
            {
                Transform loStepTransform = learningObjectiveTransform.GetChild(step - 1);
                Image currentImg = loStepTransform.GetComponent<Image>();
                Button currentButton = loStepTransform.GetComponent<Button>();

                if (loData.HaveAchievedStep(lo, step))
                {
                    // the step of the LO has been achieved. Check if the step is 'inProgress' or not
                    currentImg.sprite = StepIsInProgress(lo, step) ? inProgressAndAchievedSprite : achievedSprite;
                    // we've been to this step before, so we can interact with the step's button
                    buttonInteractivityController.EnableButton(currentButton);
                }
                else
                {
                    // the step of the LO hasn't been achieved. Check if the step is 'inProgress' or not
                    currentImg.sprite = StepIsInProgress(lo, step) ? inProgressSprite : notDoneSprite;

                    // allow the button for the learning objective be interacted with only if we've been to the step before
                    if (loData.HaveBeenToStep(lo, step))
                    {
                        buttonInteractivityController.EnableButton(currentButton);
                    } else
                    {
                        buttonInteractivityController.DisableButton(currentButton);
                    }
                }
            }
        }
    }

    private bool StepIsInProgress(int learningObjective, int step)
    {
        // There is no icon in the menu for the learning objective introduction. When the user is on the introduction,
        // mark their progress as the first step of that learning objective
        bool stepIsIntro = step == 1 && loData.GetCurrentStep() == LearningObjectives.INTRO_STEP;
        bool stepIsSelected = step == loData.GetCurrentStep();
        return (stepIsIntro || stepIsSelected) && learningObjective == loData.GetCurrentLearningObjective();
    }
}
*/