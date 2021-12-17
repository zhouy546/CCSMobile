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

    public static int convertLightIDToDropDownVal(string s)
    {
        if (s == "03")
        {
            return 0; 
        }else if(s=="04")
        {
            return 1;
        }
        else if (s == "05")
        {
            return 2;
        }
        else if (s == "06")
        {
            return 3;
        }
        else if (s == "07")
        {
            return 4;
        }
        else if (s == "08")
        {
            return 5;
        }
        else if (s == "09")
        {
            return 6;
        }
        else if (s == "0A")
        {
            return 7;
        }
        else if (s == "0B")
        {
            return 8;
        }
        else if (s == "0C")
        {
            return 9;
        }
        else if (s == "0D")
        {
            return 10;
        }
        else if (s == "0E")
        {
            return 11;
        }


        return 0;
    }


    public static string[] convertStringtoStringArray(string s)
    {
        return s.Split('-');
    }

    public static string convertStringArraytoString(string[] s)
    {
        string temp = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (i == 0)
            {
                temp = s[0];
            }
            else
            {
                temp = temp + "-" + s[i];
            }
   
        }
        return temp;
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

    public static int ConvertDropDownValueToDeviceType(int index, SectionType sectionType)
    {
        if (sectionType == SectionType.MediaSection)
        {
            return  0;
        }
        else if(sectionType == SectionType.HardWareSection)
        {
            return index + 1;
        }
        return 0;
    }

    public static SectionType getSectionType(Section_JsonBridge _section_JsonBridge) {
        if (_section_JsonBridge.sectionType == 0)
        {
            return SectionType.MediaSection;
        }
        if (_section_JsonBridge.sectionType == 1)
        {
            return SectionType.HardWareSection;
        }

        return SectionType.Unknow;
    }

    public static int convertSectionTypeToInt(Section section)
    {
        if (section.sectionType == SectionType.MediaSection)
        {
            return 0;
        }
        if (section.sectionType == SectionType.HardWareSection)
        {
            return 1;
        }
        if(section.sectionType == SectionType.Unknow)
        {
            return -1;
        }
        return -1;
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
        Debug.Log(hexString);

        hexString = hexString.Replace(" ", "");
        if ((hexString.Length % 2) != 0)
            hexString += " ";
        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        return returnBytes;
    }

}
