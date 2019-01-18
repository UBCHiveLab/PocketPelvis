using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StructureManager {

    //Get list of structures from Parser and use StructureFactory to create all structures and store them in a list

    List<GroupedStructure> allStructures;

    private static readonly StructureManager INSTANCE = new StructureManager();

    private StructureManager()
    {
        allStructures = GetAllStructures(ParserForAll.Instance.SortGroupsByStructureNames);
    }

    public static StructureManager Instance
    {
        get
        {
            return INSTANCE;
        }
    }

    private List<GroupedStructure> GetAllStructures(Dictionary<string, List<string>> sortGroupsByStructureNames)
    {
        List<GroupedStructure> allStructures = new List<GroupedStructure>();

        string[] structureGroups = new string[ParserForAll.Instance.SortStructureNamesByGroups.Keys.Count];
        ParserForAll.Instance.SortStructureNamesByGroups.Keys.CopyTo(structureGroups, 0);

        foreach (KeyValuePair<string, List<string>> entry in sortGroupsByStructureNames)
        {
            if (!(Array.IndexOf(structureGroups, entry.Key) > -1))
            {
                GroupedStructure gs = StructureFactory.Instance.GenerateStructure(entry.Key, entry.Value);
                allStructures.Add(gs);
            }
        }
        return allStructures;
    }
}