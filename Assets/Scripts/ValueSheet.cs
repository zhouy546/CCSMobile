using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ValueSheet 
{
    public static MobileCCS_JsonBridge m_MobileCCS_JsonBridge;
    public static CCS mobileCcs;
    public static CCS currentSelectCCS; 
    public static Page currentSelectPage;
    public static Section currentSelectSection;
    public static Node currentSelectNode;

    public static string JsonUrl = Application.persistentDataPath + "/" + "JsonData.Json";

    public static bool isEditMode=false;
}

public enum DeviceType
{
    pcUDP,pc_on_off,projector,led,light,Unknow
}
