using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupedStructure : BasicStructure {

    //Interative class used to add tags to a structure.

    BasicStructure structure = null;
    string group;

    public GroupedStructure(string name) : base(name)
    {
        //
    }

    public GroupedStructure(BasicStructure gStructure, string g, string name) : base(name)
    {
        structure = gStructure;
        group = g;
    }

    public override bool checkForName(string name)
    {
        if (structure != null)
        {
            return group == name || structure.checkForName(name) || base.checkForName(name);
        } else
        {
            return group == name || base.checkForName(name);
        }
        
    }

}
