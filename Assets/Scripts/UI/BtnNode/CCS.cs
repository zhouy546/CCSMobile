using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCS : MonoBehaviour
{
    public string CCSNAME;

    public List<Page> page = new List<Page>();

    public void INI(string _CCSNAME, List<Page> _page)
    {
        CCSNAME = _CCSNAME;

        page = _page;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
