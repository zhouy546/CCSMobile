using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    #region jsonArea
    public int pageNum;

    public List<Section> Section = new List<Section>();

    #endregion

    public Text PageTitletext;

    public Transform SectionParent;

    public GameObject[] editUIBtns;

    public InputField EditTitleInputField;

    public Button TitleSubmitBtn;

    public Page Pervious;

    public Page Next;


    public void INI(int _pageNum, string _pageTitle,List<Section> _Section)
    {
        pageNum = _pageNum;

        Section = _Section;

        PageTitletext.text = _pageTitle;

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }
    public void MoveAway()
    {
        this.transform.localPosition = new Vector3(5000, 0, 0);
    }

    public void MoveIn()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnEdit(bool b)
    {
        foreach (var item in editUIBtns)
        {
            item.SetActive(b);
        }
  
    }

    public void ClickEditTitleBtn()
    {
        EditTitleInputField.gameObject.SetActive(!EditTitleInputField.gameObject.active);
        TitleSubmitBtn.gameObject.SetActive(!TitleSubmitBtn.gameObject.active);
    }

    public void SubmitTitleChange()
    {
        ValueSheet.currentSelectPage = this;
        PageTitletext.text = EditTitleInputField.text;

        EditTitleInputField.gameObject.SetActive(false);
        TitleSubmitBtn.gameObject.SetActive(false);
    }

    public void SectionADD()
    {
        ValueSheet.currentSelectPage = this;

        Section temp = CreateUI.instance.CreateSection();

        List<Node> nodes = new List<Node>();

        temp.INI("defaultName", this, nodes);

        Section.Add(temp);
    }

    private void OnDestroy()
    {
        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }


}
