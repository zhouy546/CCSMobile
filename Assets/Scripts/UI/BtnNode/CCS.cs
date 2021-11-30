using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCS : MonoBehaviour
{
    public string CCSNAME;

    public List<Page> page = new List<Page>();

    public GameObject g_AddPage;
    public void INI(string _CCSNAME, List<Page> _page)
    {
        CCSNAME = _CCSNAME;

        page = _page;

        if (page != null)
        {
            if (page.Count != 0)
            {
                IniLinkedList(_page);
            }
        }

        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }


    public void addPage()
    {
       Page temp = CreateUI.instance.CreatePage();


        if (ValueSheet.currentSelectPage.Next == null)
        {
            page.Add(temp);
        }
        else
        {
            page.Insert(page.IndexOf(ValueSheet.currentSelectPage.Next), temp);

        }

        if (ValueSheet.currentSelectPage == null)
        {
            temp.Next = null;
            temp.Pervious = null;
        }

        if (ValueSheet.currentSelectPage.Next != null)
        {
            temp.Next = ValueSheet.currentSelectPage.Next;
            temp.Pervious = ValueSheet.currentSelectPage;
            ValueSheet.currentSelectPage.Next.Pervious = temp;
            ValueSheet.currentSelectPage.Next = temp;
            
        }
        if(ValueSheet.currentSelectPage.Next==null)
        {
            temp.Next = null;
            temp.Pervious = ValueSheet.currentSelectPage;
            ValueSheet.currentSelectPage.Next = temp;
        }





        ValueSheet.currentSelectPage.MoveAway();
        temp.MoveIn();

        ValueSheet.currentSelectPage = temp;

    }

    public void IniLinkedList(List<Page> _page) {
        for (int i = 0; i < _page.Count; i++)
        {

            if (page.Count == 0)
            {
                return;
            }

            if (i == 0)
            {
                page[i].MoveIn();
            }
            else
            {
                page[i].MoveAway();
            }

            if(_page.Count == 1)
            {
                page[i].Pervious = null;
                page[i].Next = null;
            }
            else if (_page.Count == 2)
            {

                if (i == 0)
                {
                    page[i].Pervious = null;
                    page[i].Next = page[i+1];
                }
                else if (i == 1)
                {
                    page[i].Pervious = page[i - 1];
                    page[i].Next = null;
                }
            }
            else
            {
                if (i == 0)
                {
                    page[i].Pervious = null;
                    page[i].Next = page[i + 1];
                }
                else if (i == page.Count-1)
                {
                    page[i].Pervious = page[i - 1];
                    page[i].Next = null;
                }else 
                {
                    page[i].Next = page[i + 1];
                    page[i].Pervious = page[i - 1];
                }
            }

        }
    }

    private void OnEdit(bool b)
    {
        g_AddPage.SetActive(b);
    }

    private void OnDestroy()
    {
        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }

    public void GoNext()
    {
        if (ValueSheet.currentSelectPage.Next != null)
        {
            ValueSheet.currentSelectPage.MoveAway();
            ValueSheet.currentSelectPage = ValueSheet.currentSelectPage.Next;
            ValueSheet.currentSelectPage.MoveIn();
        }
    }

    public void GoPervious()
    {
        if (ValueSheet.currentSelectPage.Pervious != null)
        {
            ValueSheet.currentSelectPage.MoveAway();
            ValueSheet.currentSelectPage = ValueSheet.currentSelectPage.Pervious;
            ValueSheet.currentSelectPage.MoveIn();
        }
    }
}
