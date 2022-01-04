using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBarUpdate : MonoBehaviour
{
    public Image ProcessGreenBar;

    public GameObject G_ProcessBar;

    public GameObject g_warning;

    public static ProcessBarUpdate instance;

    public static CallBack currentCallBack;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.OnGroupbtnStartProcess, TurnOnG_processbar);

        EventCenter.AddListener(EventDefine.OnGroupbtnEndtProcess, TurnOffG_processbar);

        EventCenter.AddListener(EventDefine.ShowWarnning, TurnOng_warning);

        EventCenter.AddListener(EventDefine.HidWarnning, TurnOffg_warning);

        instance = this;
    }
    public void WarnningSubmit()
    {
        EventCenter.Broadcast(EventDefine.HidWarnning);

        currentCallBack.Invoke();
    }

    public void WarnningCancel()
    {
        EventCenter.Broadcast(EventDefine.HidWarnning);
    }

    public void UpdateFill(int _amout,int totalAmout)
    {
        ProcessGreenBar.fillAmount = (float)_amout / (float)totalAmout;
    }

    private void TurnOnG_processbar()
    {
        ProcessGreenBar.fillAmount = 0;
        G_ProcessBar.SetActive(true);
    }
    private void TurnOffG_processbar()
    {
        G_ProcessBar.SetActive(false);
        currentCallBack = null;
    }

    private void TurnOng_warning()
    {
        g_warning.SetActive(true);
    }
    private void TurnOffg_warning()
    {
        g_warning.SetActive(false);
    }

}
