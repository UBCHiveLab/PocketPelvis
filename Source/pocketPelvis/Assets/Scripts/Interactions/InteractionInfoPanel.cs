using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionInfoPanel : MonoBehaviour
{
    Dictionary<string, string> infos;
    Text info;

    // Start is called before the first frame update
    void Start()
    {
        infos = ParserForAll.Instance.SortTextInfoByStructure;
        EventManager.Instance.InfoEvent += OnInfoEvent;
        info = GameObject.Find("infoPanel").GetComponentInChildren<Text>();
        GameObject.Find("clearInfoPanel").GetComponent<Button>().onClick.AddListener(clearInfoPanel);
        info.text = "";
    }

    private void clearInfoPanel()
    {
        info.text = "";
    }

    private void OnInfoEvent(string name)
    {
        if (infos.ContainsKey(name))
        {
            info.text = infos[name];
        } else
        {
            Debug.Log("don't have text info for: " + name);
            info.text = "";
        }
    }
    
}
