using System;
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

        if (deviceType == DeviceType.light)
        {
            GameObject tempG_node = Instantiate(_createUI.g_btns[4], partent) as GameObject;
            return tempG_node.GetComponent<BTN_LightTCP>();
        }


        Debug.Log("unknowDevice");
        return null;
    }

    public string convertDropDownToLightID(string s)
    {
        return "null";
    }


    public static string[] convertStringtoStringArray(string s)
    {
        return s.Split('-');
    }

    public static DeviceType GetDeviceType(Node_JsonBridge node_JsonBridge)
    {
        if (node_JsonBridge.deviceType == 0)
        {
            return DeviceType.pcUDP;
        }
        if (node_JsonBridge.deviceType == 1)
        {
            return DeviceType.pc_on_off;
        }
        if (node_JsonBridge.deviceType == 2)
        {
            return DeviceType.projector;
        }
        if (node_JsonBridge.deviceType == 3)
        {
            return DeviceType.led;
        }
        if (node_JsonBridge.deviceType == 4)
        {
            return DeviceType.light;
        }


        return DeviceType.Unknow;
    }

    public static bool checkIp(string ipStr)
    {
        IPAddress ip;
        if (IPAddress.TryParse(ipStr, out ip))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //十六进制字符串转byte数组
    public static byte[] strToToHexByte(string hexString)
    {
        hexString = hexString.Replace(" ", "");
        if ((hexString.Length % 2) != 0)
            hexString += " ";
        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        return returnBytes;
    }

}
