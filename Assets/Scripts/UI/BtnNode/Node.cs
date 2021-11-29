using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public string ip;
    public string deviceip;
    public int deviceType;
    public string BtnName;
    public string[] OnClicksend;

    public Button Mbutton;

    public Section parentSection;

    public List<GameObject> editUIBtns = new List<GameObject>();
    public virtual void Start()
    {
        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);

        OnEdit(ValueSheet.isEditMode);
    }

    public virtual void Update()
    {

    }

    public virtual void INI(Node_JsonBridge node_JsonBridge,Section _paretnSection)
    {
        parentSection = _paretnSection;
        ip = node_JsonBridge.ip;
        deviceip = node_JsonBridge.deviceip;
        deviceType = node_JsonBridge.deviceType;
        BtnName = node_JsonBridge.btn_name;
        OnClicksend = node_JsonBridge.OnClicksend;

    }

    public virtual void Onclick()
    {

    }

    public virtual int getUDPPort()
    {
        return 0;
    }

    public virtual int getTCPPort()
    {
        return 0;
    }

    public virtual string getLightID()
    {
        return "null";
    }

    public virtual string getProjectorSerial()
    {
        return "null";
    }

    public virtual void OnDestroy()
    {
        EventCenter.AddListener<bool>(EventDefine.OnEditUIClick, OnEdit);
    }

    private void OnEdit(bool b)
    {
        foreach (var item in editUIBtns)
        {
            item.SetActive(b);
        }

    }

    public virtual void DestoryBtn()
    {


        Destroy(this.gameObject,0.5f);
    }

}
