using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PageSwitcher : MonoBehaviour
{
    public PageType desiredPage;

    private PageManager pageManager;
    private Button switchPageButton;

    public void Start()
    {
        switchPageButton = GetComponent<Button>();
        switchPageButton.onClick.AddListener(OnButtonClicked);
        pageManager = PageManager.Instance;
    }

    private void OnButtonClicked()
    {
        pageManager.MakePageActive(desiredPage);
    }
}
