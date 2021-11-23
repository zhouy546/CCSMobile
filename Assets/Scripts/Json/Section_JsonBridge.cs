using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_JsonBridge 
{
    public string SectionName;

    public List<Node_JsonBridge> node_JsonBridges = new List<Node_JsonBridge>();

    public Section_JsonBridge(string _SectionName,List<Node_JsonBridge> _node_JsonBridges)
    {
        SectionName = _SectionName;

        node_JsonBridges = _node_JsonBridges;
    }
}
