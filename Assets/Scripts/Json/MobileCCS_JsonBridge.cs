using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCCS_JsonBridge 
{
    public string CCSNAME;

    public List<Page_JsonBridge> page_JsonBridges = new List<Page_JsonBridge>();

    public MobileCCS_JsonBridge(string _CCSNAME, List<Page_JsonBridge> _page_JsonBridges)
    {
        CCSNAME = _CCSNAME;

        page_JsonBridges = _page_JsonBridges;
    }
}
