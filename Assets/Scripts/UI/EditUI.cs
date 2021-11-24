using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditUI : MonoBehaviour
{
    public GameObject ccsTitleEditor;
    public InputField PageTitleInputField;

    public GameObject G_pageEditor;
    public GameObject G_selectEditor;
    public GameObject G_nodeEditor;

    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener<object>(EventDefine.OnObjectAddInCurrentEditor, EditorSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EditorSwitch(object obj)
    {
        if(object.Equals(ValueSheet.currentSelectPage, obj))
        {
            G_pageEditor.SetActive(true);
            G_selectEditor.SetActive(false);
            G_nodeEditor.SetActive(false);
        }
        else if(object.Equals(ValueSheet.currentSelectSection, obj))
        {
            G_pageEditor.SetActive(false);
            G_selectEditor.SetActive(true);
            G_nodeEditor.SetActive(false);
        }
        else if (object.Equals(ValueSheet.currentSelectNode, obj))
        {
            G_pageEditor.SetActive(false);
            G_selectEditor.SetActive(false);
            G_nodeEditor.SetActive(true);
        }
    }


    public void OnEditUIClick()
    {
        ValueSheet.isEditMode = !ValueSheet.isEditMode;
        EventCenter.Broadcast(EventDefine.OnEditUIClick, ValueSheet.isEditMode);
    }
    #region CCS UI EDITOR

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
}
