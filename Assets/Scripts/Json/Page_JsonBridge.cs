using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_JsonBridge 
{
    public int pageNum;

    public List<Section_JsonBridge> Section_JsonBridges = new List<Section_JsonBridge>();

    public Page_JsonBridge(int _pageNum, List<Section_JsonBridge> _Section_JsonBridges)
    {
        pageNum = _pageNum;

        Section_JsonBridges = _Section_JsonBridges;
    }
}
