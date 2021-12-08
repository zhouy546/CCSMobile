using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_JsonBridge 
{
    public string ip;
    public string deviceip;
    public int TCPport;
    public int UDPport;
    public int deviceType;
    public string btn_name;
    public string LightID;
    public int LightCir;
    public string ProjectorSerial;
    public string[] OnClicksend;


    public Node_JsonBridge(string _ip, string _PCDeviceIP,int _TCPport,int _UDPport, int _deviceType, string _Name, string _LightID,int _LightCir, string[] _OnClicksend, string _ProjectorSerial = "PJLink")
    {
        ip = _ip;
        deviceip = _PCDeviceIP;
        TCPport = _TCPport;
        UDPport = _UDPport;
        deviceType = _deviceType;
        btn_name = _Name;
        LightID = _LightID;
        LightCir = _LightCir;
        ProjectorSerial = _ProjectorSerial;
        OnClicksend = _OnClicksend;
    }
}
