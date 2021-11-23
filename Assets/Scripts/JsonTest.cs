using UnityEngine;
 using System.Collections;
  using LitJson;    //����Json
  using UnityEngine.UI;    //����UI
  using System.Text;   //ʹ��StringBuilder
  using System.IO;  //ʹ���ļ���
 
 /// <summary>
 /// Json�ֻ��˶�ȡ����
 /// </summary>
 public class JsonTest : MonoBehaviour 
 {
     public Text jsonText;    //��ʾJson���ı���
     public InputField input;   //�޸�Json���ݵ������ı���
     public string name;   //�����Ƿ������Json�����ֵ
 
     void Awake()
     {
         name = "Person";  //дһ�����������
         SaveJsonString(GetJson());  //�õ�һ��Json����֮��,��������ݴ洢����
     }

     public void DidReadJsonButton_Click()      //��ȡJson�ı��İ�ť�¼�
     {
             jsonText.text = GetJsonString();  //��ȡjson����,������ʾ���ı�������
         }

     public void DidConfirmInputButton_Click()      //��ȡȷ����������ݵİ�ť�¼�
     {
             name = input.text;    //��ȡ�ı������������
             SaveJsonString(GetJson());  //�洢����
         }

     public string GetJson()   //���������ǲ���, ���˾��������дһ��Json����
     {   //�õ�Json��ʽ�ַ���
             StringBuilder sb = new StringBuilder();
             JsonWriter writer = new JsonWriter(sb);
             writer.WriteObjectStart();    //�ֵ俪ʼ
             writer.WritePropertyName(name);    //��ֵ(�������� ͨ���ı�name����ӡ����ֵ�۲�)
             writer.WriteObjectStart();
             writer.WritePropertyName("Hp");   //��������Щ����
             writer.Write("20");
             writer.WritePropertyName("Mp");
             writer.Write("60");
             writer.WritePropertyName("Attack");
             writer.Write("30");
             writer.WritePropertyName("Exp");
             writer.Write("100");
             writer.WriteObjectEnd();
             writer.WriteObjectEnd();    //�ֵ����
             return sb.ToString();  //����Json��ʽ���ַ���
         }

     public void SaveJsonString(string JsonString)    //����Json��ʽ�ַ���
     {
        FileInfo file = new FileInfo(Application.persistentDataPath + "JsonData.Json");   //�������ص�,��������ϸ˵��,����ֻ��Ҫ֪����ֻ��һ��·��
        Debug.Log(file);     
        StreamWriter writer = file.CreateText();   //���ı�д��ķ�ʽ
        writer.Write(JsonString);   //д������
        writer.Close();   //�ر�дָ��
        writer.Dispose();    //����дָ��
     }

     public string GetJsonString()     //���ļ������ȡjson����
     {  //��������ֻ�ǲ���,���ԾͲ�д����Ľ���������
            StreamReader reader = new StreamReader(Application.persistentDataPath + "JsonData.Json");
            string jsonData = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            return jsonData;
     }
 }