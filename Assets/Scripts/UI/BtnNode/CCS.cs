using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCS : MonoBehaviour
{
    public string CCSNAME;

    public List<Page> page = new List<Page>();

    //public GameObject[] editUIBtns;

    public void INI(string _CCSNAME, List<Page> _page)
    {
        CCSNAME = _CCSNAME;

        page = _page;

        //EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }

    public void AddPage()
    {
        Page tempPage = CreateUI.instance.CreatePage();

        List<Section> sections = new List<Section>();

        tempPage.INI(ValueSheet.mobileCcs.page.Count,"default", sections);

        ValueSheet.mobileCcs.page.Add(tempPage);
    }

    //private void OnEdit(bool b)
    //{
    //    setEditUIBtnONOFF(b);
    //}

    //private void setEditUIBtnONOFF(bool b)
    //{
    //    foreach (var item in editUIBtns)
    //    {
    //        item.SetActive(b);
    //    }
    //}

    //private void OnDestroy()
    //{
    //    EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    //}
}
