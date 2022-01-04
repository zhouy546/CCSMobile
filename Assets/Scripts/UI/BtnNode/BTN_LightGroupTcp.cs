using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_LightGroupTcp : MonoBehaviour
{
    public List<lightgroupunit> lightgroupunits = new List<lightgroupunit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetOnClickCallBack() {
        ProcessBarUpdate.currentCallBack = OnclickCallBack;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }
    public void SetoffClickCallBack() {
        ProcessBarUpdate.currentCallBack = OffClickBack;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }

    private void OnclickCallBack()
    {
        StartCoroutine(onclick());
    }
    private IEnumerator onclick()
    {
        Debug.Log("灯光开");

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in lightgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item)+1, lightgroupunits.Count);

            yield return new WaitForSeconds(1);
            item.Onclick();

        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }

    private void OffClickBack()
    {
        StartCoroutine(offclick());
    }

    private IEnumerator offclick()
    {
        Debug.Log("灯光关");
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in lightgroupunits)
        {
            Debug.Log(lightgroupunits.IndexOf(item));

            ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item)+1, lightgroupunits.Count);

            yield return new WaitForSeconds(1);
            item.OffClick();

        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }
}

[System.Serializable]
public class lightgroupunit
{
    public string name;
    public string ip;
    public int port;
    public int lightcir;
    public string lightID;

    public void Onclick()
    {

        if (Utility.checkIp(ip))
        {


            string str = lightID + " " + /*"06 00 0 00 01"*/ValueSheet.LightUnitONCmd[lightcir];

            Debug.Log(str);

            string sendstr = str + " " + CRC.CRCCalc(str);

            Threadtcp tcp_thread = new Threadtcp(ip, port, sendstr, false);

            tcp_thread.sendHexString();

        }
    }

    public void OffClick()
    {
        if (Utility.checkIp(ip))
        {
            string str = lightID + " " + /*"06 00 05 00 00"*/ ValueSheet.LightUnitOFFCmd[lightcir];

            Debug.Log(str);

            string sendstr = str + " " + CRC.CRCCalc(str);
            Threadtcp tcp_thread = new Threadtcp(ip, port, sendstr, false);
            tcp_thread.sendHexString();
        }
    }


}
