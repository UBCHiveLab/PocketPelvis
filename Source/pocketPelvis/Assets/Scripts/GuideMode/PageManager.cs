using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PageType
{
    HomeVertical,
    HomeHorizontal,
    LOVertial,
    LOHorizontal,
    Main,
    Tutorial
}

public class PageManager : Singleton<PageManager>
{
    private PageController activePage;
    private List<PageController> pageControllers;

    private void Awake()
    {
        pageControllers = GetComponentsInChildren<PageController>(true).ToList();
        MakePageActive(PageType.LOVertial);
    }

    private void Update()
    {
        if (activePage.pageType == PageType.LOVertial || activePage.pageType == PageType.LOHorizontal)
        {
            PageType pageToActivate = PageType.LOVertial;

            if(Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
            {
                pageToActivate = PageType.LOHorizontal;
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
