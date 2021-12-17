using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNodeUICtr : MonoBehaviour
{
  

    public List<ShouldDisplayUI> MediaSectionUIS = new List<ShouldDisplayUI>();

    public List<ShouldDisplayUI> UIS = new List<ShouldDisplayUI>();

    public InputField btnNameInputField;

    public Dropdown NodeUiDropDown;

    public InputField ipInputField;

    public InputField udpPortInputField;

    public InputField tcpPortInputField;

    public Dropdown lightidDropdown;

    public Dropdown lightCirDropdown;

    public Dropdown projectorSerialDropdown;

    public InputField sendContentInputField;

    public static AddNodeUICtr instance;

    private Sprite TEMPSPRITE;
  
    List<Dropdown.OptionData> MEDIATYPE_DROPDownOption = new List<Dropdown.OptionData>();

    List<Dropdown.OptionData> HARDWAREDEVICE_DROPDownOption = new List<Dropdown.OptionData>();

    public bool isCreateNewNode = true;
    public void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }

        OffUi();

        Dropdown.OptionData UDPBTN_optionData = new Dropdown.OptionData();

        UDPBTN_optionData.text = "UPD按钮";

        MEDIATYPE_DROPDownOption.Add(UDPBTN_optionData);

        Dropdown.OptionData PC_optionData = new Dropdown.OptionData("PC开关", TEMPSPRITE);

        Dropdown.OptionData Projector_optionData = new Dropdown.OptionData("投影机开关", TEMPSPRITE);

        Dropdown.OptionData led_optionData = new Dropdown.OptionData("LED电柜开关", TEMPSPRITE);

        Dropdown.OptionData light_optionData = new Dropdown.OptionData("灯光开关", TEMPSPRITE);

        HARDWAREDEVICE_DROPDownOption.Add(PC_optionData);

        HARDWAREDEVICE_DROPDownOption.Add(Projector_optionData);

        HARDWAREDEVICE_DROPDownOption.Add(led_optionData);

        HARDWAREDEVICE_DROPDownOption.Add(light_optionData);


    }

    private void OnEnable()
    {
        
        BtnTypeDropDownValueChanged(NodeUiDropDown);

    
    }

    public void TurnOnMe()
    {
       gameObject.SetActive(true);
        if (ValueSheet.currentSelectSection.sectionType == SectionType.MediaSection)
        {
            NodeUiDropDown.options = MEDIATYPE_DROPDownOption;
        }
        else if (ValueSheet.currentSelectSection.sectionType == SectionType.HardWareSection)
        {
            NodeUiDropDown.options = HARDWAREDEVICE_DROPDownOption;
        }

    }

    public void getbtnValue(Node node)
    {
        ipInputField.text = node.ip;

        tcpPortInputField.text = node.getTCPPort().ToString();

        udpPortInputField.text = node.getUDPPort().ToString();

        sendContentInputField.text = Utility.convertStringArraytoString(node.OnClicksend);

        btnNameInputField.text = node.BtnName;

        if (node.parentSection.sectionType == SectionType.MediaSection)
        {
            NodeUiDropDown.options = MEDIATYPE_DROPDownOption;

            NodeUiDropDown.value = node.deviceType;
        }
        else if (node.parentSection.sectionType == SectionType.HardWareSection)
        {
            NodeUiDropDown.options = HARDWAREDEVICE_DROPDownOption;

            NodeUiDropDown.value = node.deviceType-1;
        }

        lightCirDropdown.value = node.getLightCir();

        lightidDropdown.value = Utility.convertLightIDToDropDownVal(node.getLightID());

        projectorSerialDropdown.value = 0;
       
    }


    public void Submit()
    {
        string ip = ipInputField.text;//
        string deviceip = ipInputField.text;//


        int tempint = 0;
        bool b = int.TryParse(tcpPortInputField.text, out tempint);
        int tcpPort=0;//
        int udpPort = 29010;
        if (b)
        {
            tcpPort = tempint;
        }

        b = int.TryParse(udpPortInputField.text, out tempint);
        if (b)
        {
            udpPort = tempint;//
        }
        int deviceType =Utility.ConvertDropDownValueToDeviceType(NodeUiDropDown.value,ValueSheet.currentSelectSection.sectionType);

        Debug.Log(deviceType);

        int lightcir = lightCirDropdown.value;

        Debug.Log(lightcir);
        string BtnName = btnNameInputField.text;//
        string lightID = lightidDropdown.options[lightidDropdown.value].text;
        string[] sendContent = Utility.convertStringtoStringArray(sendContentInputField.text);//
        string ProjectorSerial = "PJLink";



        Node_JsonBridge node_JsonBridge = new Node_JsonBridge(ip, deviceip, tcpPort, udpPort, deviceType, BtnName, lightID, lightcir, sendContent, ProjectorSerial);
        if (isCreateNewNode)
        {
            Node TEMPNODE = Utility.CreateNode(CreateUI.instance, node_JsonBridge, ValueSheet.currentSelectSection.btnParent);

            TEMPNODE.INI(node_JsonBridge, ValueSheet.currentSelectSection);

            if (TEMPNODE == null)
            {
                return;
            }
            else
            {
                ValueSheet.currentSelectSection.node.Add(TEMPNODE);
            }
        }
        else//设置当前Node
        {
            ValueSheet.currentSelectNode.SetVal(node_JsonBridge);
        }

        OffUi();
    }
    public void OffUi()
    {
        instance.gameObject.SetActive(false);
    }

    public void BtnTypeDropDownValueChanged(Dropdown _dropdown)
    {

        if(ValueSheet.currentSelectSection.sectionType== SectionType.MediaSection)
        {
            MediaSectionUIS[_dropdown.value].Show();
        }
        else if (ValueSheet.currentSelectSection.sectionType == SectionType.HardWareSection)
        {
            UIS[_dropdown.value].Show();

        }
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
