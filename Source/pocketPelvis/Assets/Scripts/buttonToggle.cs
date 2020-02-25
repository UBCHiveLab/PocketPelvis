using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonToggle : MonoBehaviour
{
    public void toggleItem(GameObject item)
    {
        item.SetActive(!item.activeSelf);
    }
}
