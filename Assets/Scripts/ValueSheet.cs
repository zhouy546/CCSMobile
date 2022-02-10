using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ValueSheet 
{
    public static int heartBeatSendWaitTime = 2000;
    public static int TcpReceiveWaitTime = 2000;
    public static int TcpSendWaitTime = 1000;


    public static MobileCCS_JsonBridge m_MobileCCS_JsonBridge;
    public static CCS mobileCcs;
    public static CCS currentSelectCCS; 
    public static Page currentSelectPage;
    public static Section currentSelectSection;
    public static Node currentSelectNode;

    public static string JsonUrl = Application.persistentDataPath + "/" + "JsonData.Json";

    public static bool isEditMode=false;

    #region pc
    public static string[] MediaServerCmd = { "start", "stop", "read" };

    #endregion

    #region 灯光收发

    public static string[] LightUnitONCmd = { "06 00 02 00 01","06 00 03 00 01", "06 00 04 00 01", "06 00 05 00 01", "06 00 06 00 01",
    "06 00 07 00 01","06 00 08 00 01","06 00 09 00 01","06 00 0A 00 01" ,"06 00 0B 00 01","06 00 0C 00 01","06 00 0D 00 01",
    "06 00 0E 00 01"};
    public static string[] LightUnitOFFCmd = { "06 00 01 00 00"/*OFF*/,"06 00 03 00 00", "06 00 04 00 00", "06 00 05 00 00", "06 00 06 00 00",
    "06 00 07 00 00","06 00 08 00 00","06 00 09 00 00","06 00 0A 00 00" ,"06 00 0B 00 00","06 00 0C 00 00","06 00 0D 00 00",
    "06 00 0E 00 00"};
    public static string[] LightCmd = { "06 00 02 00 01"/*ON*/, "06 00 01 00 00"/*OFF*/, "03 00 03 00 01"/*READ*/};
    public static string[] LightReceiveCmd = { "03020001"/*READ回值开*/, "03020000"/*READ回值关*/, "0600020001"/*发送开后回值*/, "0600010000"/*发送关后回值*/};
    #endregion

    #region LED电柜
    public static string[] LEDCmd = { "00000000000601050801FF00"/*on*/, "00000000000601050802FF00"/*off*/,};

    #endregion

}

public enum DeviceType
{
    pcUDP,pc_on_off,projector,led,light,Unknow
}

public enum SectionType
{
    MediaSection,HardWareSection,Unknow
}


[System.Serializable]
public class ledgroupunit: device_node
{
    //public string name;
    //public string ip;
    //public int port;


    public override string getOffStr()
    {
        string sendstr = ValueSheet.LEDCmd[1];

        return sendstr;
    }

    public override string getOnStr()
    {
        string sendstr = ValueSheet.LEDCmd[0];

        return sendstr;
    }
    public void Onclick()
    {

        if (Utility.checkIp(ip))
        {


            HardwareTCPThread.instance.tcp_thread = new Threadtcp(ip, port, ValueSheet.LEDCmd[0], false);

            HardwareTCPThread.instance.tcp_thread.sendHexString();

        }
    }

    public void OffClick()
    {
        if (Utility.checkIp(ip))
        {

            HardwareTCPThread.instance.tcp_thread = new Threadtcp(ip, port, ValueSheet.LEDCmd[1], false);

            HardwareTCPThread.instance.tcp_thread.sendHexString();
        }
    }


}

[System.Serializable]
public class PCgroupunit: device_node
{
    //public string name;
    //public string ip;
    //public int port;

    public override string getOffStr()
    {
        string sendstr = ValueSheet.MediaServerCmd[1];

        return sendstr;
    }

    public override string getOnStr()
    {
        string sendstr = ValueSheet.MediaServerCmd[0];

        return sendstr;
    }
    public void Onclick()
    {

        if (Utility.checkIp(ip))
        {


            HardwareTCPThread.instance.tcp_thread = new Threadtcp(ip, port, ValueSheet.MediaServerCmd[0], false);

            HardwareTCPThread.instance.tcp_thread.sendDefaultString();

        }
    }

    public void OffClick()
    {
        if (Utility.checkIp(ip))
        {

            HardwareTCPThread.instance.tcp_thread = new Threadtcp(ip, port, ValueSheet.MediaServerCmd[1], false);

            HardwareTCPThread.instance.tcp_thread.sendDefaultString();
        }
    }


}


[System.Serializable]
public class lightgroupunit: device_node
{
    //public string name;
    //public string ip;
    //public int port;
    public int lightcir;
    public string lightID;


    public override string getOffStr()
    {
        string str = lightID + " " + /*"06 00 05 00 00"*/ ValueSheet.LightUnitOFFCmd[lightcir];

        string sendstr = str + " " + CRC.CRCCalc(str);

        return sendstr;
    }

    public override string getOnStr()
    {
        string str = lightID + " " + /*"06 00 0 00 01"*/ValueSheet.LightUnitONCmd[lightcir];

        string sendstr = str + " " + CRC.CRCCalc(str);

        return sendstr;
    }

    public void Onclick()
    {

        if (Utility.checkIp(ip))
        {


            string str = lightID + " " + /*"06 00 0 00 01"*/ValueSheet.LightUnitONCmd[lightcir];

            string sendstr = str + " " + CRC.CRCCalc(str);

            Debug.Log(sendstr);

            HardwareTCPThread.instance.tcp_thread = new Threadtcp(ip, port, sendstr, false);

            HardwareTCPThread.instance.tcp_thread.sendHexString();

        }
    }

    public void OffClick()
    {
        if (Utility.checkIp(ip))
        {
            string str = lightID + " " + /*"06 00 05 00 00"*/ ValueSheet.LightUnitOFFCmd[lightcir];


            string sendstr = str + " " + CRC.CRCCalc(str);

            //Debug.Log(sendstr);

            HardwareTCPThread.instance.tcp_thread = new Threadtcp(ip, port, sendstr, false);
            HardwareTCPThread.instance.tcp_thread.sendHexString();
        }
    }


}
[System.Serializable]
public class device_node
{
    public string name;
    public string ip;
    public int port;

    public virtual string getOffStr()
    {
        return "";
    }

    public virtual string getOnStr()
    {
        return "";
    }

}

public struct LinkInfos
{
   public List<device_node> device_Nodes;
}

