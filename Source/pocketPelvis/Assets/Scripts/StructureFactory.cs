using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureFactory {

    //Initialize all structures.

    private static readonly StructureFactory INSTANCE = new StructureFactory();

    private StructureFactory()
    {
        //
    }

    public static StructureFactory Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    public GroupedStructure GenerateStructure(string name, List<string> groups)
    {
        GroupedStructure structure = new GroupedStructure(name);
        foreach (string group in groups)
        {
            structure = new GroupedStructure(structure, group, name);
        }
        return structure;
    }
}
