using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public string SectionName;

    public List<Node> node_JsonBridges = new List<Node>();

    public Transform btnParent;

    public void INI(string _SectionName, List<Node> _node_JsonBridges)
    {
        SectionName = _SectionName;

        node_JsonBridges = _node_JsonBridges;
    }
}
