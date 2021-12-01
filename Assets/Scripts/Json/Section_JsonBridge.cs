using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_JsonBridge 
{
    public string SectionName;

    public int sectionType;

    public List<Node_JsonBridge> node_JsonBridges = new List<Node_JsonBridge>();


    public Section_JsonBridge(string _SectionName,int _sectionType,List<Node_JsonBridge> _node_JsonBridges)
    {
        SectionName = _SectionName;

        sectionType = _sectionType;

        node_JsonBridges = _node_JsonBridges;
    }
}
