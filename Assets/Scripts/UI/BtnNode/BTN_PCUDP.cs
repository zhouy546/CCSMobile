using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BTN_PCUDP : Node
{
    public int udpPort;
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

    }

    

    public override void Onclick()
    {
        base.Onclick();

        send().GetAwaiter();
      
    }


    async Task send()
    {
        for (int i = 0; i < OnClicksend.Length; i++)
        {
            SendUPDData.instance.udp_Send(OnClicksend[0], ip, udpPort);
            await Task.Delay(500);
            Debug.Log("Wait 500millsecond");
        }
    }
}
