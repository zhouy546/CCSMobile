using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WriteJson : MonoBehaviour
{

    public static WriteJson instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            WriteJsonFromObject(ValueSheet.JsonUrl, ValueSheet.mobileCcs);
        }
    }



    public void writeDefaultJson(string path)
    {       

        string[] tempstr = { "defaultStr" };

        List<Node_JsonBridge> tempNodes = new List<Node_JsonBridge>();

        List<Section_JsonBridge> tempSections = new List<Section_JsonBridge>();

        List<Page_JsonBridge> Pages = new List<Page_JsonBridge>();

        Node_JsonBridge tempNode = new Node_JsonBridge("192.168.80.248","192.168.20.254",4000,29010,0,"默认按钮","03", tempstr);

        tempNodes.Add(tempNode);

        Section_JsonBridge tempSection = new Section_JsonBridge("默认区块", tempNodes);

        tempSections.Add(tempSection);

        Page_JsonBridge tempPage = new Page_JsonBridge(0,"默认页面标题", tempSections);

        Pages.Add(tempPage);

        MobileCCS_JsonBridge TempMobileCCS = new MobileCCS_JsonBridge("默认测试中控系统", Pages);

        string json = ConvertClassToJsonData(TempMobileCCS).ToJson();

        Debug.Log("Json写入地址： " + path);

        CreatJsonFile(json, path);

    }



    public void onSaveJsonBtnClick() {

        WriteJsonFromObject(ValueSheet.JsonUrl, ValueSheet.mobileCcs);

    }

    private void WriteJsonFromObject(string path,CCS ccs) {
        List<Page_JsonBridge> PagesBridge = new List<Page_JsonBridge>();
        for (int i = 0; i < ccs.page.Count; i++)
        {
            List<Section_JsonBridge> SectionBridges = new List<Section_JsonBridge>();
            for (int j = 0; j < ccs.page[i].Section.Count; j++)
            {
              
                List<Node_JsonBridge> nodesBridges = new List<Node_JsonBridge>();
                for (int k = 0; k < ccs.page[i].Section[j].node.Count; k++)
                {
                    Node tempNodee = ccs.page[i].Section[j].node[k];
                    string ip = tempNodee.ip;
                    string pcdeviceip = tempNodee.ip;
                    int tcpPort = tempNodee.getTCPPort();
                    int udpPort = tempNodee.getUDPPort();
                    int deviceType = tempNodee.deviceType;
                    string _name = tempNodee.BtnName;
                    string lightid = tempNodee.getLightID();
                    string[] onclicksend = tempNodee.OnClicksend;
                    string projectserial = tempNodee.getProjectorSerial();
                    Node_JsonBridge tempNode = new Node_JsonBridge(ip, pcdeviceip, tcpPort, udpPort, deviceType, _name, lightid, onclicksend, projectserial);
                    nodesBridges.Add(tempNode);
                }
                Section_JsonBridge tempSection = new Section_JsonBridge(ccs.page[i].Section[j].SectionName, nodesBridges);
                SectionBridges.Add(tempSection);
            }
            Page_JsonBridge tempPage = new Page_JsonBridge(i, ccs.page[i].PageTitletext.text, SectionBridges);
            PagesBridge.Add(tempPage);
        }


        ValueSheet.m_MobileCCS_JsonBridge = new MobileCCS_JsonBridge(ccs.CCSNAME, PagesBridge);


        string json = ConvertClassToJsonData(ValueSheet.m_MobileCCS_JsonBridge).ToJson();

        CreatJsonFile(json, path);
    }

    JsonData ConvertClassToJsonData(object obj)
    {
      return  JsonMapper.ToObject(JsonMapper.ToJson(obj));
    }

    //public void UpdateJson(string[] Jsonarray)
    //{
    //    string temp = "";
    //    for (int i = 0; i < Jsonarray.Length; i++)
    //    {
    //        temp += Jsonarray[i];
    //    }

    //    string ss2 = Regex.Unescape(temp);
    //    CreatJsonFile(ss2);
    //}

    void CreatJsonFile(string jsonStr, string url)
    {
        string spath = url;

        StringBuilder sb = new StringBuilder();
        StreamWriter sw;
        FileInfo info = new FileInfo(spath);
        if (!info.Exists)
        {
            sw = info.CreateText();
            print("文件不存在，创建数据");
        }
        else
        {
            info.Delete();
            print("文件已经存在，删除数据");
            sw = info.CreateText();
        }

        sw.Write(jsonStr);
        sw.Close();

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
