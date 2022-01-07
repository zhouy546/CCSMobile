using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditUI : MonoBehaviour
{
    public GameObject ccsTitleEditor;
    public InputField PageTitleInputField;

    public GameObject G_cssEditor;
    public GameObject G_pageEditor;
    public GameObject G_selectEditor;

    public GameObject G_pswUI;
    public InputField pswInput;
    // Start is called before the first frame update
    void Start()
    {
      //  EventCenter.AddListener<object>(EventDefine.OnObjectAddInCurrentEditor, EditorSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckPassword(string psw)
    {
        return psw == "hh888899990";
    }


    public void OnPswSubmit()
    {
        bool b = CheckPassword(pswInput.text);

        if (b)
        {
            OnEditUIClick();
            ClosePswUI();
        }
        else
        {
            pswInput.text = "密码错误";
        }
    }

    public void ClosePswUI()
    {
        G_pswUI.SetActive(false);
    }
    public void ShowPswUI()
    {
        G_pswUI.SetActive(true);
        pswInput.text = "";
    }



    public void OnEditUIClick()
    {
        ValueSheet.isEditMode = !ValueSheet.isEditMode;
        EventCenter.Broadcast(EventDefine.OnEditUIClick, ValueSheet.isEditMode);
    }

    #region CCS UI EDITOR

    public void PageAdd()
    {
        Page tempPage = CreateUI.instance.CreatePage();

        List<Section> sections = new List<Section>();

        tempPage.INI(ValueSheet.mobileCcs.page.Count, "default", sections);

        ValueSheet.mobileCcs.page.Add(tempPage);
    }

    public void PageDelete()
    {
        ValueSheet.mobileCcs.page.Remove(ValueSheet.currentSelectPage);

        Destroy(ValueSheet.currentSelectPage.gameObject, 0.5f);
    }

    #endregion


    #region PAGE UI EDITOR

    public void PageTitleEditorONOFF()
    {
        ccsTitleEditor.SetActive(!ccsTitleEditor.active);
    }



    public void PageTitleSubmit()
    {
        if (ValueSheet.currentSelectPage == null)
        {
            Debug.Log("当前未选中Page");
            return;
        }
        else
        {
            ValueSheet.currentSelectPage.PageTitletext.text = PageTitleInputField.text;
        }
    }
    #endregion

    #region Section UI EDITOR


    #endregion
}
