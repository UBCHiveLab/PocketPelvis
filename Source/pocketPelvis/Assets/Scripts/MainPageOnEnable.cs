using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageOnEnable : MonoBehaviour
{
   
    private void OnEnable()
    {
       
        LoNavigator.instance.DisplayStepButtons();
        LoNavigator.instance.DisplayLoInfo();
    }
}
