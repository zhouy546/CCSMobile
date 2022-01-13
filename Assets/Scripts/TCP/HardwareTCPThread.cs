using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwareTCPThread : MonoBehaviour
{
    public static HardwareTCPThread instance;

    public Threadtcp tcp_thread; 

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

}
