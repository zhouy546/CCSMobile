using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Section_UDP : Section
{

    

    public override void INI(Section_JsonBridge _section_JsonBridge, Page _page, List<Node> _nodes)
    {
        base.INI(_section_JsonBridge, _page, _nodes);
    }

    public override void SectionDelete()
    {
        base.SectionDelete();
    }

    public override void ShowAddNodeUI()
    {
        base.ShowAddNodeUI();
    }


    public override void OnEdit(bool b)
    {
        base.OnEdit(b);
    }

    public void OpenALL()
    {
        StartCoroutine(openall());
    }

    private IEnumerator openall() {
        foreach (var item in node)
        {
            item.Onclick();
            yield return new WaitForSeconds(1f);
        }
    }

    public void CloseAll()
    {
        StartCoroutine(closeall());
    }

    private IEnumerator closeall()
    {
        foreach (var item in node)
        {
            item.OffClick();
            yield return new WaitForSeconds(1f);
        }
    }
}
