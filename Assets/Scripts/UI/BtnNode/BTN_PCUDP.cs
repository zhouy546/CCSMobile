using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BTN_PCUDP : Node
{
    public int udpPort;
    public Text btnText;
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

    public override void INI(Node_JsonBridge _node_JsonBridge)
    {
        base.INI(_node_JsonBridge);
        udpPort = _node_JsonBridge.UDPport;
        btnText.text = _node_JsonBridge.btn_name;
    }

    

    public override void Onclick()
    {
        base.Onclick();

        send().GetAwaiter();
      
    }

    public override int getUDPPort()
    {
        return udpPort;
    }


    async Task send()
    {
        for (int i = 0; i < OnClicksend.Length; i++)
        {
            SendUPDData.instance.udp_Send(OnClicksend[i], ip, udpPort);
            await Task.Delay(500);
            Debug.Log("Wait 500millsecond");
        }
    }
}
