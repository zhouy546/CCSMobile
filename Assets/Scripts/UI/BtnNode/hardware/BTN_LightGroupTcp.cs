using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_LightGroupTcp : MonoBehaviour
{
    public List<lightgroupunit> lightgroupunits = new List<lightgroupunit>();

    public bool isMainEBOX;
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

        if (isMainEBOX)
        {
            BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
        }
        else
        {
            BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
        }
    }
    public void SetoffClickCallBack() {
        ProcessBarUpdate.currentCallBack = OffClickBack;
        EventCenter.Broadcast(EventDefine.ShowWarnning);

        if (isMainEBOX)
        {
            BTN_MainDeviceTcp.instance.HintText.text = "请确认先关闭所有主机与LED电箱";
        }
        else
        {
            BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
        }
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
            ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item) + 1, lightgroupunits.Count);

            yield return new WaitForSeconds(1.5F);
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

            ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item) + 1, lightgroupunits.Count);

            yield return new WaitForSeconds(1.5F);
            item.OffClick();

        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }
}
