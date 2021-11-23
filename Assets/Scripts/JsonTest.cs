using UnityEngine;
 using System.Collections;
  using LitJson;    //导入Json
  using UnityEngine.UI;    //导入UI
  using System.Text;   //使用StringBuilder
  using System.IO;  //使用文件流
 
 /// <summary>
 /// Json手机端读取测试
 /// </summary>
 public class JsonTest : MonoBehaviour 
 {
     public Text jsonText;    //显示Json的文本框
     public InputField input;   //修改Json数据的输入文本框
     public string name;   //测试是否更换了Json里面的值
 
     void Awake()
     {
         name = "Person";  //写一个人物的属性
         SaveJsonString(GetJson());  //得到一个Json数据之后,把这个数据存储起来
     }

     public void DidReadJsonButton_Click()      //读取Json文本的按钮事件
     {
             jsonText.text = GetJsonString();  //读取json数据,并且显示到文本框里面
         }

     public void DidConfirmInputButton_Click()      //读取确定输入框内容的按钮事件
     {
             name = input.text;    //获取文本框里面的数据
             SaveJsonString(GetJson());  //存储起来
         }

     public string GetJson()   //由于这里是测试, 本人就在这里简单写一个Json数据
     {   //得到Json格式字符串
             StringBuilder sb = new StringBuilder();
             JsonWriter writer = new JsonWriter(sb);
             writer.WriteObjectStart();    //字典开始
             writer.WritePropertyName(name);    //键值(人物属性 通过改变name来打印出来值观察)
             writer.WriteObjectStart();
             writer.WritePropertyName("Hp");   //里面有这些属性
             writer.Write("20");
             writer.WritePropertyName("Mp");
             writer.Write("60");
             writer.WritePropertyName("Attack");
             writer.Write("30");
             writer.WritePropertyName("Exp");
             writer.Write("100");
             writer.WriteObjectEnd();
             writer.WriteObjectEnd();    //字典结束
             return sb.ToString();  //返回Json格式的字符串
         }

     public void SaveJsonString(string JsonString)    //保存Json格式字符串
     {
        FileInfo file = new FileInfo(Application.persistentDataPath + "JsonData.Json");   //这里是重点,会在下面细说的,这里只需要知道它只是一个路径
        Debug.Log(file);     
        StreamWriter writer = file.CreateText();   //用文本写入的方式
        writer.Write(JsonString);   //写入数据
        writer.Close();   //关闭写指针
        writer.Dispose();    //销毁写指针
     }

     public string GetJsonString()     //从文件里面读取json数据
     {  //由于这里只是测试,所以就不写具体的解析数据了
            StreamReader reader = new StreamReader(Application.persistentDataPath + "JsonData.Json");
            string jsonData = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            return jsonData;
     }
 }