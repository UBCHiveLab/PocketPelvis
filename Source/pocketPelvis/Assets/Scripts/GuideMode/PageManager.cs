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

    private void Awake()
    {
        pageControllers = GetComponentsInChildren<PageController>(true).ToList();

        // make sure that the only active page is activePage
        pageControllers.ForEach(controller => controller.gameObject.SetActive(false));
        MakePageActive(PageType.LOVertial);
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
                pageToActivate = GetActivePageType();
            }

            MakePageActive(pageToActivate);
        }
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

    public PageType GetActivePageType()
    {
        return activePage.pageType;
    }
}
