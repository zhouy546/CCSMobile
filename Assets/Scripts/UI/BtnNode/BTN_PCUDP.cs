using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BTN_PCUDP : Node ,IPointerEnterHandler,IPointerExitHandler
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

    public override void INI(Node_JsonBridge _node_JsonBridge,Section parentSection)
    {
        base.INI(_node_JsonBridge, parentSection);
        udpPort = _node_JsonBridge.UDPport;
        btnText.text = _node_JsonBridge.btn_name;
    }

    public override void SetBtn()
    {
        AddNodeUICtr.instance.isCreateNewNode = false;

        ValueSheet.currentSelectNode = this;

        ValueSheet.currentSelectSection = parentSection;

        AddNodeUICtr.instance.TurnOnMe();

        AddNodeUICtr.instance.getbtnValue(this);
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

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void DestoryBtn()
    {
        ValueSheet.currentSelectNode = this;

        parentSection.node.Remove(this);

        base.DestoryBtn();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = CreateUI.instance.udp_HeighlightBtn;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = CreateUI.instance.udp_DeheighlightBtn;

    }
}
