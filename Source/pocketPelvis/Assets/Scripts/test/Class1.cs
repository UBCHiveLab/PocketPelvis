using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//class attached to UI, used to yell at console to test stuff
//feel free to edit anything
public class Class1 : MonoBehaviour {
    List<string> nums;
    List<string> seg;

    public void Start()
    {
        nums = new List<string> {"0000","0001","0010","0011",
            "0100","0101","0110","0111","1000","1001" };
        seg = new List<string> { "0000001", "1001111","0010010","0000110","1001100",
            "0100100","0100000","0001111","0000000","0001100" };

        string table = "";

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                table = table + "when " + nums[i] + nums[j] + "=> Hex1Temp <= " + seg[i] + "; Hex0Temp <= " + seg[j] + "a \n";
            }
        }

        Debug.Log(table);
    }
}