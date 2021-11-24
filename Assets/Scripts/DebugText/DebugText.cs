using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public static DebugText instance;

    public Text text;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Log(string str)
    {
        text.text += "\n" + str;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
