using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Section : MonoBehaviour
{
    public Text TitleText;

    public string SectionName;

    public SectionType sectionType;

    public List<Node> node = new List<Node>();

    public Page parentPage;

    public Transform btnParent;

    public GameObject AddNodeBtn;

    public GameObject DeleteBtn;

    public GameObject EditTitleBtn;

    public GameObject EditTitleInputField;



    public virtual void INI(Section_JsonBridge _section_JsonBridge, Page _page, List<Node> _nodes)
    {

        node = _nodes;

        TitleText.text = SectionName = _section_JsonBridge.SectionName;

        parentPage = _page;

        sectionType = Utility.getSectionType(_section_JsonBridge);

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }

    public virtual void OnDestroy()
    {
        EventCenter.RemoveListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }


    public virtual void ShowAddNodeUI()
    {
        ValueSheet.currentSelectSection = this;

        Debug.Log(ValueSheet.currentSelectSection.sectionType);

        AddNodeUICtr.instance.TurnOnMe();

        AddNodeUICtr.instance.isCreateNewNode = true;
    }

    public virtual void SectionDelete()
    {
        ValueSheet.currentSelectSection = this;

        ValueSheet.currentSelectPage = parentPage;

        parentPage.m_Section.Remove(this);

        Destroy(this.gameObject, 0.5f);

    }


    public virtual void OnEdit(bool b)
    {
        AddNodeBtn.SetActive(b);

        DeleteBtn.SetActive(b);

        EditTitleBtn.SetActive(b);
    }

    public virtual void OnTitleInputFieldValueChanged()
    {
        InputField input = EditTitleInputField.GetComponent<InputField>();
        TitleText.text = SectionName = input.text;
    }

    public virtual void OnEditTitleBtnClick()
    {
        EditTitleInputField.SetActive(true);
    }

    public virtual void OnEditTitleInputFieldSubmitClick()
    {
        EditTitleInputField.SetActive(false);
    }

}
