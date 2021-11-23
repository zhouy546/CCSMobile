using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ValueSheet 
{
    public static MobileCCS_JsonBridge m_MobileCCS_JsonBridge;
    public static CCS mobileCcs;
}

public enum DeviceType
{
    pcUDP,pc_on_off,projector,led,light,Unknow
}
