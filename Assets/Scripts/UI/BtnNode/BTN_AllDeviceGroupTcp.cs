using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN_AllDeviceGroupTcp : MonoBehaviour
{


    public List<lightgroupunit> DeviceMainEletri = new List<lightgroupunit>();


    public List<PCgroupunit> PCgroupunits = new List<PCgroupunit>();
    public List<ledgroupunit> LEDgroupunits = new List<ledgroupunit>();
    public List<lightgroupunit> lightgroupunits = new List<lightgroupunit>();

    public BTN_LightGroupTcp[] bTN_LightGroupTcps;
    public BTN_LedGroupTcp[] bTN_LedtGroupTcps;
    public BTN_PCGroupTcp[] bTN_PCGroupTcps;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bTN_LightGroupTcps.Length; i++)
        {
            lightgroupunits.AddRange(bTN_LightGroupTcps[i].lightgroupunits);
        }
        for (int i = 0; i < bTN_LedtGroupTcps.Length; i++)
        {
            LEDgroupunits.AddRange(bTN_LedtGroupTcps[i].LEDgroupunits);
        }
        for (int i = 0; i < bTN_PCGroupTcps.Length; i++)
        {
            PCgroupunits.AddRange(bTN_PCGroupTcps[i].PCgroupunits);
        }
    }

    public void SetOnClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = AllDeviceOnCallback;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }
    public void SetoffClickCallBack()
    {
        ProcessBarUpdate.currentCallBack = AllDeviceOffCallback;
        EventCenter.Broadcast(EventDefine.ShowWarnning);
    }

    private void AllDeviceOnCallback()
    {
        StartCoroutine(AllDeviceOn());
    }

    private void AllDeviceOffCallback()
    {
        StartCoroutine(AllDeviceOff());
    }

    private IEnumerator AllDeviceOn()
    {
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in DeviceMainEletri)
        {
            ProcessBarUpdate.instance.UpdateFill(DeviceMainEletri.IndexOf(item) + 1, DeviceMainEletri.Count);

            yield return new WaitForSeconds(1);

            item.Onclick();
        }

        yield return new WaitForSeconds(15);

        foreach (var item in lightgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item) + 1, lightgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.Onclick();
        }

        yield return new WaitForSeconds(2);

        foreach (var item in LEDgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(LEDgroupunits.IndexOf(item) + 1, LEDgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.Onclick();
        }

        yield return new WaitForSeconds(2);

        foreach (var item in PCgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(PCgroupunits.IndexOf(item) + 1, PCgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.Onclick();
        }

        EventCenter.Broadcast(EventDefine.OnGroupbtnEndtProcess);

    }

    private IEnumerator AllDeviceOff()
    {
        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);

        foreach (var item in PCgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(PCgroupunits.IndexOf(item) + 1, PCgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.OffClick();
        }

        yield return new WaitForSeconds(2);

        foreach (var item in LEDgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(LEDgroupunits.IndexOf(item) + 1, LEDgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.OffClick();
        }

        yield return new WaitForSeconds(2);

        foreach (var item in lightgroupunits)
        {
            ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item) + 1, lightgroupunits.Count);

            yield return new WaitForSeconds(1);

            item.OffClick();
        }

        yield return new WaitForSeconds(15);

        foreach (var item in DeviceMainEletri)
        {
            ProcessBarUpdate.instance.UpdateFill(DeviceMainEletri.IndexOf(item) + 1, DeviceMainEletri.Count);

            yield return new WaitForSeconds(1);

            item.OffClick();
        }

        EventCenter.Broadcast(EventDefine.OnGroupbtnStartProcess);


    }

}
