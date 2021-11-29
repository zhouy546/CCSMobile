using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNodeUICtr : MonoBehaviour
{
    public List<ShouldDisplayUI> UIS = new List<ShouldDisplayUI>();

    public InputField btnNameInputField;

    public Dropdown NodeUiDropDown;

    public InputField ipInputField;

    public InputField udpPortInputField;

    public InputField tcpPortInputField;

    public Dropdown lightidDropdown;

    public Dropdown projectorSerialDropdown;

    public InputField sendContentInputField;

    public static AddNodeUICtr instance;



    public void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

        OffUi();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {

        BtnTypeDropDownValueChanged(NodeUiDropDown);
    }


    public void Submit()
    {
        string ip = ipInputField.text;
        string deviceip = ipInputField.text;


        int tempint = 0;
        bool b = int.TryParse(tcpPortInputField.text, out tempint);
        int tcpPort=0;
        int udpPort = 29010;
        if (b)
        {
            tcpPort = tempint;
        }

        b = int.TryParse(udpPortInputField.text, out tempint);
        if (b)
        {
            udpPort = tempint;
        }
        int deviceType = NodeUiDropDown.value;

        Debug.Log(deviceType);

        string BtnName = btnNameInputField.text;
        string lightID = lightidDropdown.options[lightidDropdown.value].text;
        string[] sendContent = Utility.convertStringtoStringArray(sendContentInputField.text);
        string ProjectorSerial = "PJLink";



        Node_JsonBridge node_JsonBridge = new Node_JsonBridge(ip, deviceip, tcpPort, udpPort, deviceType, BtnName, lightID, sendContent, ProjectorSerial);
        Node TEMPNODE =  Utility.CreateNode(CreateUI.instance, node_JsonBridge, ValueSheet.currentSelectSection.btnParent);

        TEMPNODE.INI(node_JsonBridge,ValueSheet.currentSelectSection);

        if (TEMPNODE == null)
        {
            return;
        }
        else
        {
            ValueSheet.currentSelectSection.node.Add(TEMPNODE);
        }

        OffUi();
    }
    public void OffUi()
    {
        instance.gameObject.SetActive(false);
    }

    public void BtnTypeDropDownValueChanged(Dropdown _dropdown)
    {
        UIS[_dropdown.value].Show();
    }
}

[System.Serializable]
public class ShouldDisplayUI
{
    public string name;

    public List<GameObject> uiShow = new List<GameObject>();

    public List<GameObject> uioff = new List<GameObject>();

    public void Show()
    {
        foreach (var item in uiShow)
        {
            item.SetActive(true);
        }

        foreach (var item in uioff)
        {
            item.SetActive(false);
        }
    }
}
