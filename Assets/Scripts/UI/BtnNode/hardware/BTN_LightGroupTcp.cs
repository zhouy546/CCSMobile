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
            BTN_MainDeviceTcp.instance.HintText.text = "�Ƿ�Ҫִ�д˲���";
        }
        else
        {
            BTN_MainDeviceTcp.instance.HintText.text = "�Ƿ�Ҫִ�д˲���";
        }
    }
    public void SetoffClickCallBack() {
        ProcessBarUpdate.currentCallBack = OffClickBack;
        EventCenter.Broadcast(EventDefine.ShowWarnning);

        if (isMainEBOX)
        {
            BTN_MainDeviceTcp.instance.HintText.text = "��ȷ���ȹر�����������LED����";
        }
        else
        {
            BTN_MainDeviceTcp.instance.HintText.text = "�Ƿ�Ҫִ�д˲���";
        }
    }

    private void OnclickCallBack()
    {
        StartCoroutine(onclick());
    }
    private IEnumerator onclick()
    {



        Debug.Log("�ƹ⿪");

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


        Debug.Log("�ƹ��");
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
