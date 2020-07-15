using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractOnClickButtonBehaviour : MonoBehaviour
{
    private Button button;
    protected SaveDataManager saveDataManager;

    void Awake()
    {
        // initialize the class' fields and add set the onclick listener to the button
        button = GetComponent<Button>();
        saveDataManager = SaveDataManager.Instance;

        button.onClick.AddListener(OnClickButton);
    }

    protected abstract void OnClickButton();
}
