using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCS : MonoBehaviour
{
    public string CCSNAME;

    public List<Page> page = new List<Page>();

    public GameObject SelectBtn;


    public void INI(string _CCSNAME, List<Page> _page)
    {
        CCSNAME = _CCSNAME;

        page = _page;

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }

    public void AddCCSToCurrentSelectCCS()
    {
        ValueSheet.currentSelectCCS = this;
        object OBJ = this;
        //EventCenter.Broadcast(EventDefine.OnObjectAddInCurrentEditor, OBJ);
    }



    private void OnEdit(bool b)
    {
        SelectBtn.SetActive(b);
    }

    private void OnDestroy()
    {
        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }
}
