using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public int pageNum;

    public Transform SectionParent;

    public List<Section> Section = new List<Section>();

    public void INI(int _pageNum, List<Section> _Section)
    {
        pageNum = _pageNum;

        Section = _Section;
    }
}
