using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour
{
    [SerializeField]
    private Object g_CCS;
    [SerializeField]
    private Object g_Page;
    [SerializeField]
    private Object g_Section;

    [SerializeField]
    public Object[] g_btns;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.ini, iniUI);

        g_CCS=  Resources.Load("Prefabs/CCS", typeof(GameObject));
        g_Page = Resources.Load("Prefabs/Page", typeof(GameObject));
        g_Section = Resources.Load("Prefabs/SectionNode", typeof(GameObject));
    }

    private void iniUI()
    {
        GameObject tempG_ccs = Instantiate(g_CCS,this.transform) as GameObject;

        ValueSheet.mobileCcs = tempG_ccs.GetComponent<CCS>();

        List<Page> pages = new List<Page>();

        for (int i = 0; i < ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges.Count; i++)
        {
            GameObject tempG_page = Instantiate(g_Page, tempG_ccs.transform) as GameObject;

            Page temppage = tempG_page.GetComponent<Page>();

       

            List<Section> sections = new List<Section>();

            for (int j = 0; j < ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[i].Section_JsonBridges.Count; j++)
            {
                GameObject tempG_section = Instantiate(g_Section, temppage.SectionParent) as GameObject;

                Section tempsection = tempG_section.GetComponent<Section>();
          
                List<Node> nodes = new List<Node>();
                for (int k = 0; k < ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[i].Section_JsonBridges[j].node_JsonBridges.Count; k++)
                {
                    Node_JsonBridge node_JsonBridge = ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[i].Section_JsonBridges[j].node_JsonBridges[k];


                    Node node =   Utility.CreateNode(this, node_JsonBridge, tempsection.btnParent);

                    node.INI(node_JsonBridge);

                    nodes.Add(node);
                }
                tempsection.INI(ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[i].Section_JsonBridges[j].SectionName, nodes);

                sections.Add(tempsection);
            }

            temppage.INI(ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[i].pageNum, sections);

            pages.Add(temppage);
        }

        

        ValueSheet.mobileCcs.INI(ValueSheet.m_MobileCCS_JsonBridge.CCSNAME, pages);

    }

}