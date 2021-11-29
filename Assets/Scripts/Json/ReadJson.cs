using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReadJson : MonoBehaviour
{

    public static ReadJson instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public string GetJsonString(string path)     //从文件里面读取json数据
    {  //由于这里只是测试,所以就不写具体的解析数据了
        StreamReader reader = new StreamReader(path);
        string jsonData = reader.ReadToEnd();
        reader.Close();
        reader.Dispose();
        return jsonData;
    }

    public  void readJson(string path)
    {
        string _jsonstr = GetJsonString(path);

        JsonData _itemDate = JsonMapper.ToObject(_jsonstr.ToString());


        string CCSNAME = _itemDate["CCSNAME"].ToString();

    
        Debug.Log(CCSNAME);
        
        List<Page_JsonBridge> tempPage_JsonBridges = new List<Page_JsonBridge>();
        for (int i = 0; i < _itemDate["page_JsonBridges"].Count; i++)
        {
            int pageNum = i;

            string PageTitle = _itemDate["page_JsonBridges"][i]["pageTitle"].ToString();


            List<Section_JsonBridge> tempSection_JsonBridges = new List<Section_JsonBridge>();
            for (int k = 0; k < _itemDate["page_JsonBridges"][i]["Section_JsonBridges"].Count; k++)
            {
                string SectionName = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["SectionName"].ToString();

                Debug.Log(SectionName);

                List < Node_JsonBridge > tempNode_JsonBridges = new List<Node_JsonBridge>();
                for (int j = 0; j < _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"].Count; j++)
                {
                    string ip = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["ip"].ToString();
                    string deviceip = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["deviceip"].ToString();
                    int TCPport = int.Parse( _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["TCPport"].ToString());
                    int UDPport = int.Parse(_itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["UDPport"].ToString());
                    int deviceType = int.Parse(_itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["deviceType"].ToString());
                    string m_Name = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["btn_name"].ToString();
                    string lightid = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["LightID"].ToString();
                    string ProjectorSerial = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["ProjectorSerial"].ToString();
                    
                    List<string> OnClicksend = new List<string>();
                    for (int m   = 0; m < _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["OnClicksend"].Count; m++)
                    {
                        OnClicksend.Add(_itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["OnClicksend"][m].ToString());
                    }
                    
                    Node_JsonBridge node_JsonBridge = new Node_JsonBridge(ip, deviceip, TCPport, UDPport, deviceType, m_Name, lightid, OnClicksend.ToArray(), ProjectorSerial);
                    tempNode_JsonBridges.Add(node_JsonBridge);
                }

                Section_JsonBridge section_JsonBridge = new Section_JsonBridge(SectionName, tempNode_JsonBridges);
                tempSection_JsonBridges.Add(section_JsonBridge);
            }

            Page_JsonBridge Page_JsonBridge = new Page_JsonBridge(pageNum, PageTitle, tempSection_JsonBridges);
            tempPage_JsonBridges.Add(Page_JsonBridge);
        }

        ValueSheet.m_MobileCCS_JsonBridge= new MobileCCS_JsonBridge(CCSNAME, tempPage_JsonBridges);

        Debug.Log(ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[0].Section_JsonBridges[0].node_JsonBridges[0].OnClicksend[0]);

        EventCenter.Broadcast(EventDefine.ini);
    }




}
