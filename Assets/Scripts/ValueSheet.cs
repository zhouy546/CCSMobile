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

    #region �ƹ��շ�
    public static string[] LightCmd = { "06 00 02 00 01"/*ON*/, "06 00 01 00 00"/*OFF*/, "03 00 03 00 01"/*READ*/};
    public static string[] LightReceiveCmd = { "03020001"/*READ��ֵ��*/, "03020000"/*READ��ֵ��*/, "0600020001"/*���Ϳ����ֵ*/, "0600010000"/*���͹غ��ֵ*/};
    #endregion
}

public enum DeviceType
{
    pcUDP,pc_on_off,projector,led,light,Unknow
}
