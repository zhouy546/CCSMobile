using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Device_LED_PowerTCP : MonoBehaviour
{
    public BTN_PCGroupTcp btn_PCGroupTcp;
    public BTN_LedGroupTcp btn_LedGroupTcp;
    public BTN_LightGroupTcp btn_PowerTcp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setclickOnCallBack()
    {
        ProcessBarUpdate.currentCallBack = clickOn;

        EventCenter.Broadcast(EventDefine.ShowWarnning);

        BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
    }

    public void setclickoffCallBack()
    {
        ProcessBarUpdate.currentCallBack = clickOff;

        EventCenter.Broadcast(EventDefine.ShowWarnning);

        BTN_MainDeviceTcp.instance.HintText.text = "是否要执行此操作";
    }


    private void clickOn()
    {
        StartCoroutine(IEclickOn());
    }

    private IEnumerator IEclickOn()
    {
        yield return StartCoroutine(btn_PowerTcp.onclick());

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        yield return new WaitForSeconds(80);

        yield return StartCoroutine(btn_PCGroupTcp.onclick());

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        yield return new WaitForSeconds(10);

        yield return StartCoroutine(btn_LedGroupTcp.onclick());
    }

    private void clickOff()
    {
        StartCoroutine(IEclickOff());
    }

    public IEnumerator IEclickOff()
    {

        yield return StartCoroutine(btn_PCGroupTcp.offclick());

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        yield return new WaitForSeconds(10);

        yield return StartCoroutine(btn_LedGroupTcp.offclick());

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        yield return new WaitForSeconds(40);

        yield return StartCoroutine(btn_PowerTcp.offclick());

    }
}
