using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_PCGroupTcp : MonoBehaviour
{
    public lightgroupunit floorDeviceUnit;

    public List<PCgroupunit> PCgroupunits = new List<PCgroupunit>();

    public void SetOnClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = OnclickCallback;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }
    public void SetoffClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = OffClickCallback;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }

    private void OnclickCallback()
    {
        StartCoroutine(onclick());
    }
    private IEnumerator onclick()
    {
        Debug.Log("pc¿ª");
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        floorDeviceUnit.Onclick();

        yield return new WaitForSeconds(15);

        foreach (var item in PCgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(PCgroupunits.IndexOf(item)+1, PCgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.Onclick();

        }

        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);
    }

    private void OffClickCallback()
    {
        StartCoroutine(offclick());
    }

    private IEnumerator offclick()
    {
        Debug.Log("pc¹Ø");

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in PCgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(PCgroupunits.IndexOf(item)+1, PCgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.OffClick();
        }


        yield return new WaitForSeconds(15);

        floorDeviceUnit.Onclick();

        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);
    }
}

[System.Serializable]
public class PCgroupunit
{
    public string name;
    public string ip;
    public int port;


    public void Onclick()
    {

        if (Utility.checkIp(ip))
        {


            Threadtcp tcp_thread = new Threadtcp(ip, port, ValueSheet.MediaServerCmd[0], false);

            tcp_thread.sendDefaultString();

        }
    }

    public void OffClick()
    {
        if (Utility.checkIp(ip))
        {

            Threadtcp tcp_thread = new Threadtcp(ip, port, ValueSheet.MediaServerCmd[1], false);

            tcp_thread.sendDefaultString();
        }
    }


}
