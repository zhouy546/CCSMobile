using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_PCGroupTcp : MonoBehaviour
{
   // public lightgroupunit floorDeviceUnit;

    public List<PCgroupunit> PCgroupunits = new List<PCgroupunit>();
    //public BTN_LedGroupTcp LED;
    //public bool isDebug;
   // public int id;

    public void Update()
    {

    }

    public void SetOnClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = OnclickCallback;
        BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }
    public void SetoffClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = OffClickCallback;
        BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }

    private void OnclickCallback()
    {
        StartCoroutine(onclick());
    }
    private IEnumerator onclick()
    {
        Debug.Log("pc开");
     
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);
        foreach (var item in PCgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(PCgroupunits.IndexOf(item) + 1, PCgroupunits.Count);

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
        Debug.Log("pc关");

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in PCgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(PCgroupunits.IndexOf(item) + 1, PCgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.OffClick();
        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);
    }
}
