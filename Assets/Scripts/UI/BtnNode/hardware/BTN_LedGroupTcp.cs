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
        BTN_MainDeviceTcp.instance.HintText.text = "�Ƿ�Ҫִ�д˲���";

    }
    public void SetoffClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = OffClickCallback;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
        BTN_MainDeviceTcp.instance.HintText.text = "�Ƿ�Ҫִ�д˲���";

    }

    private void OnclickCallback()
    {
        StartCoroutine(onclick());
    }
    public IEnumerator onclick()
    {
        Debug.Log("LED��");
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);
        yield return new WaitForSeconds(1);
        foreach (var item in LEDgroupunits)
        {

            ProcessBarUpdate.instance.UpdateFill(LEDgroupunits.IndexOf(item) + 1, LEDgroupunits.Count);

            yield return new WaitForSeconds(1);
            item.Onclick();

        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }

    private void OffClickCallback()
    {
        StartCoroutine(offclick());
    }

    public IEnumerator offclick()
    {
        Debug.Log("led��");
        BTN_MainDeviceTcp.instance.HintText.text = "�Ƿ�Ҫִ�д˲���";
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);
        yield return new WaitForSeconds(1);
        foreach (var item in LEDgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(LEDgroupunits.IndexOf(item) + 1, LEDgroupunits.Count);

            yield return new WaitForSeconds(1);
            item.OffClick();

        }
        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }
}

