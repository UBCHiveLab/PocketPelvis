using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractNavigationButtonBehaviour : MonoBehaviour
{
    private Button navigationButton;
    protected SaveDataManager saveDataManager;

    void Awake()
    {
        // initialize the class' fields and add set the onclick listener to the navigation button
        navigationButton.GetComponent<Button>();
        saveDataManager = SaveDataManager.Instance;

        navigationButton.onClick.AddListener(OnClickButton);
    }

    protected abstract void OnClickButton();

    protected void GoToStep(int lo, int step)
    {
        // update the save data to reflect the user's progress
        saveDataManager.UpdateUserProgress(lo, step);
    }
}
