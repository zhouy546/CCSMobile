using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_LedGroupTcp : MonoBehaviour
{
    public List<ledgroupunit> LEDgroupunits = new List<ledgroupunit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        Debug.Log("LED¿ª");

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in LEDgroupunits)
        {

            ProcessBarUpdate.instance.UpdateFill(LEDgroupunits.IndexOf(item)+1, LEDgroupunits.Count);

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
        Debug.Log("led¹Ø");

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in LEDgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(LEDgroupunits.IndexOf(item)+1, LEDgroupunits.Count);

            yield return new WaitForSeconds(1);
            item.OffClick();

        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }
}

[System.Serializable]
public class ledgroupunit
{
    public string name;
    public string ip;
    public int port;


    public void Onclick()
    {

        if (Utility.checkIp(ip))
        {

           
            Threadtcp tcp_thread = new Threadtcp(ip, port, ValueSheet.LEDCmd[0], false);

            tcp_thread.sendHexString();

        }
    }

    public void OffClick()
    {
        if (Utility.checkIp(ip))
        {

            Threadtcp tcp_thread = new Threadtcp(ip, port, ValueSheet.LEDCmd[1], false);

            tcp_thread.sendHexString();
        }
    }


}
