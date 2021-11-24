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

    //public GameObject[] editUIBtns;

    public GameObject SelectBtn;

    //public InputField EditTitleInputField;



    public void INI(int _pageNum, string _pageTitle,List<Section> _Section)
    {
        pageNum = _pageNum;

        Section = _Section;

        PageTitletext.text = _pageTitle;

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }

    public void AddPageToCurrentSelectPage()
    {
        ValueSheet.currentSelectPage = this;
        object OBJ = this;
        EventCenter.Broadcast(EventDefine.OnObjectAddInCurrentEditor,OBJ);
    }

    public void DeletePage()
    {
        ValueSheet.mobileCcs.page.Remove(this);

        Destroy(this.gameObject, 0.5f);
    }

    private void OnEdit(bool b)
    {
        SelectBtn.SetActive(b);
    }

    public void AddSection()
    {

    }

    private void OnDestroy()
    {
        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }


}
