using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class WriteJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            writeDefaultJson();
        }
    }



    public void writeDefaultJson()
    {

        string path = Application.persistentDataPath +"/"+ "JsonData.Json";

        string[] tempstr = { "defaultStr" };

        List<Node_JsonBridge> tempNodes = new List<Node_JsonBridge>();

        List<Section_JsonBridge> tempSections = new List<Section_JsonBridge>();

        List<Page_JsonBridge> Pages = new List<Page_JsonBridge>();

        Node_JsonBridge tempNode = new Node_JsonBridge("127.0.0.1","192.168.20.254",4000,29010,4,"默认按钮","03", tempstr);

        tempNodes.Add(tempNode);

        Section_JsonBridge tempSection = new Section_JsonBridge("默认区块", tempNodes);

        tempSections.Add(tempSection);

        Page_JsonBridge tempPage = new Page_JsonBridge(0, tempSections);

        Pages.Add(tempPage);

        MobileCCS_JsonBridge TempMobileCCS = new MobileCCS_JsonBridge("默认测试中控系统", Pages);

        string json = ConvertClassToJsonData(TempMobileCCS).ToJson();

        Debug.Log("Json写入地址： " + path);

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
