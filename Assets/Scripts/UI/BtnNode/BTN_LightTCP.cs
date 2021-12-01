using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_LightTCP : Node
{
    public int TCPPort;
    public string lightID;
    public Text TitleText;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void INI(Node_JsonBridge _node_JsonBridge,Section parentSection)
    {
        base.INI(_node_JsonBridge, parentSection);
        TCPPort = _node_JsonBridge.TCPport;
        lightID = _node_JsonBridge.LightID;
        TitleText.text = _node_JsonBridge.btn_name;
    }

    public override string getLightID()
    {
        return lightID;
    }

    public override int getTCPPort()
    {
        return TCPPort;
    }



    public override void Onclick()
    {
        base.Onclick();

        if (Utility.checkIp(ip))
        {


            string str = lightID + " " + ValueSheet.LightCmd[0];

            Debug.Log(str);

            string sendstr = str + " " + CRC.CRCCalc(str);

            Threadtcp tcp_thread = new Threadtcp(ip, TCPPort, sendstr, false);
            tcp_thread.sendHexString();

        }
    }

    public override void OffClick()
    {
        if (Utility.checkIp(ip))
        {



            string str = lightID + " " + ValueSheet.LightCmd[1];

            Debug.Log(str);

            string sendstr = str + " " + CRC.CRCCalc(str);
            Threadtcp tcp_thread = new Threadtcp(ip, TCPPort, sendstr, false);
            tcp_thread.sendHexString();
        }
    }

    public override void OnDestroy()
    {
        ValueSheet.currentSelectNode = this;

        parentSection.node.Remove(this);

        base.OnDestroy();
    }
}
