using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Node CreateNode(CreateUI _createUI,Node_JsonBridge node_JsonBridge,Transform partent)
    {
        DeviceType deviceType = GetDeviceType(node_JsonBridge);

        if (deviceType== DeviceType.pcUDP)
        {
            GameObject tempG_node = Instantiate(_createUI.g_btns[0], partent) as GameObject;
            return tempG_node.GetComponent<BTN_PCUDP>();
        }


        Debug.Log("unknowDevice");
        return null;
    } 

    public static DeviceType GetDeviceType(Node_JsonBridge node_JsonBridge)
    {
        if (node_JsonBridge.deviceType == 0)
        {
            return DeviceType.pc_on_off;
        }
        if (node_JsonBridge.deviceType == 1)
        {
            return DeviceType.projector;
        }
        if (node_JsonBridge.deviceType == 2)
        {
            return DeviceType.led;
        }
        if (node_JsonBridge.deviceType == 3)
        {
            return DeviceType.light;
        }
        if (node_JsonBridge.deviceType == 4)
        {
            return DeviceType.pcUDP;
        }

        return DeviceType.Unknow;
    }

}
