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

    public GameObject DeleteBtn;

    private Page parentPage;
    public void INI(string _SectionName,Page _page, List<Node> _nodes)
    {
        TitleText.text =SectionName = _SectionName;

        node = _nodes;

        parentPage = _page;

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);

    }

    public void ShowAddNodeUI()
    {
        ValueSheet.currentSelectSection = this;

        AddNodeUICtr.instance.gameObject.SetActive(true);
    }

    public void SectionDelete()
    {
        ValueSheet.currentSelectSection = this;

        ValueSheet.currentSelectPage = parentPage;

        parentPage.Section.Remove(this);

        Destroy(this.gameObject, 0.5f);

    }


    private void OnEdit(bool b)
    {
        SelectBtn.SetActive(b);

        DeleteBtn.SetActive(b);
    }

}
