using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_MainDeviceTcp : MonoBehaviour
{
    public static BTN_MainDeviceTcp instance;
    public Text HintText;
     public lightgroupunit[] floorDeviceUnit;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    //public void floorDeviceUnitON(int INDEX)
    //{
    //    floorDeviceUnit[INDEX].Onclick();
    //}

    //public void floorDeviceUnitOFF(int INDEX)
    //{
    //    floorDeviceUnit[INDEX].OffClick();
    //}
}
