using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PageType
{
    LOVertial,
    LOHorizontal,
    Main
}

public class PageManager : SceneSingleton<PageManager>
{
    private PageController activePage;
    private List<PageController> pageControllers;
    private LOTexts loTexts;
    private GuideModeEventManager eventManager;

    private void Awake()
    {
        eventManager = GuideModeEventManager.Instance;
        loTexts = new LOTextParser().loTexts;
        pageControllers = GetComponentsInChildren<PageController>(true).ToList();

        // make sure that the only active page is activePage
        pageControllers.ForEach(controller => controller.gameObject.SetActive(false));
        MakePageActive(PageType.LOVertial);
    }

    private void OnEnable()
    {
        // watch for changes to data that requires the active page to be modified
        eventManager.OnModelTrackingStatusChanged += UpdateActivePageUI;
        eventManager.OnUserProgressUpdated += UpdateActivePageUI;
    }

    private void OnDisable()
    {
        if (eventManager != null)
        {
            // if the event manager and any references to it's events haven't already been destroyed, unsubscribe to all events
            eventManager.OnModelTrackingStatusChanged -= UpdateActivePageUI;
            eventManager.OnUserProgressUpdated -= UpdateActivePageUI;
        }
    }

    private void Update()
    {
        if (activePage.pageType == PageType.LOVertial || activePage.pageType == PageType.LOHorizontal)
        {
            PageType pageToActivate;
            if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown || Input.deviceOrientation == DeviceOrientation.Portrait)
            {
                pageToActivate = PageType.LOVertial;
            }
            else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            {
                pageToActivate = PageType.LOHorizontal;
            }
            else
            {
                //do not change the page type if orientation is face up or down
                pageToActivate = activePage.pageType;
            }

            MakePageActive(pageToActivate);
        }
    }

    private void UpdateActivePageUI(UserProgressData currentProgress)
    {
        activePage.UpdateUI(currentProgress, loTexts);
    }

    private void UpdateActivePageUI(bool isTrackingModel)
    {
        activePage.UpdateUI(isTrackingModel);
    }

    public void MakePageActive(PageType pageType)
    {
        PageController pageToActivate = pageControllers.Find(page => page.pageType == pageType);

        if (pageToActivate == null)
        {
            return;
        }

        if (activePage != null)
        {
            if (activePage.pageType == pageType)
            {
                return;
            }

            // Deactivate previous page
            activePage.gameObject.SetActive(false);
        }

        // Activate new page
        pageToActivate.gameObject.SetActive(true);
        activePage = pageToActivate;
    }
}
