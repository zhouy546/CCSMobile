using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Section : MonoBehaviour
{
    public string SectionName;

    public List<Node> node = new List<Node>();

    public Transform btnParent;

    public Text TitleText;

    public GameObject SelectBtn;

    public void INI(string _SectionName, List<Node> _nodes)
    {
        TitleText.text =SectionName = _SectionName;

        node = _nodes;

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }

    public void AddSectionToCurrentSelectSection()
    {
        ValueSheet.currentSelectSection = this;
        object OBJ = this;
        EventCenter.Broadcast(EventDefine.OnObjectAddInCurrentEditor, OBJ);
    }

    private void OnEdit(bool b)
    {
        SelectBtn.SetActive(b);
    }

}
