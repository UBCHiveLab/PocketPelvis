using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelManager : SceneSingleton<LabelManager>
{
    [SerializeField]
    private LabelScript LabelScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "labelDot")
                {
                    var labelHit = hit.transform.GetComponentInParent<LabelTextManager>();
                    labelHit.toggleLabel();
                }
            }
        }
        
    }
    public void ToggleAllLabels()
    {
        LabelScript.ToggleAllLabels();
    }
    public void EnableLabelsByText(SearchingTextType textType, params string[] texts)
    {
        LabelScript.EnableLabelsByText(textType, texts);
    }
}
