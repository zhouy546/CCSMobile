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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            readJson();
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

    public  void readJson()
    {
      string path = Application.persistentDataPath + "/" + "JsonData.Json"; ;

     

        string _jsonstr = GetJsonString(path);

        JsonData _itemDate = JsonMapper.ToObject(_jsonstr.ToString());


        string CCSNAME = _itemDate["CCSNAME"].ToString();

    
        Debug.Log(CCSNAME);
        
        List<Page_JsonBridge> tempPage_JsonBridges = new List<Page_JsonBridge>();
        for (int i = 0; i < _itemDate["page_JsonBridges"].Count; i++)
        {
            int pageNum = int.Parse( _itemDate["page_JsonBridges"][i]["pageNum"].ToString());
            Debug.Log(pageNum);

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
                    string ProjectorSerial = _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["ProjectorSerial"].ToString();
                    
                    List<string> OnClicksend = new List<string>();
                    for (int m   = 0; m < _itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["OnClicksend"].Count; m++)
                    {
                        OnClicksend.Add(_itemDate["page_JsonBridges"][i]["Section_JsonBridges"][k]["node_JsonBridges"][j]["OnClicksend"][m].ToString());
                    }
                    
                    Node_JsonBridge node_JsonBridge = new Node_JsonBridge(ip, deviceip, TCPport, UDPport, deviceType, m_Name, ProjectorSerial, OnClicksend.ToArray());
                    tempNode_JsonBridges.Add(node_JsonBridge);
                }

                Section_JsonBridge section_JsonBridge = new Section_JsonBridge(SectionName, tempNode_JsonBridges);
                tempSection_JsonBridges.Add(section_JsonBridge);
            }

            Page_JsonBridge Page_JsonBridge = new Page_JsonBridge(pageNum, tempSection_JsonBridges);
            tempPage_JsonBridges.Add(Page_JsonBridge);
        }

        ValueSheet.m_MobileCCS_JsonBridge= new MobileCCS_JsonBridge(CCSNAME, tempPage_JsonBridges);

        Debug.Log(ValueSheet.m_MobileCCS_JsonBridge.page_JsonBridges[0].Section_JsonBridges[0].node_JsonBridges[0].OnClicksend[0]);

        EventCenter.Broadcast(EventDefine.ini);
    }



    public static async Task<string> Getjson(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            if (www.isNetworkError || www.isHttpError)
            {
                // log error:
#if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
#endif

                // nothing to return on error:
                return null;
            }
            else
            {
                string _jsonString = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                // return valid results:
                return _jsonString;
            }
        }
    }
}
