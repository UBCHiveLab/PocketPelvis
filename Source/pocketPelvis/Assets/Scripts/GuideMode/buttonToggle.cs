using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonToggle : MonoBehaviour
{
    public void toggleItem(GameObject item)
    {
        item.SetActive(!item.activeSelf);
    }
}
