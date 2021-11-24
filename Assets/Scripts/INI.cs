using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class INI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ini().GetAwaiter();
    }

    async Task ini()
    {
        string spath = ValueSheet.JsonUrl;
        FileInfo info = new FileInfo(spath);
        DebugText.instance.Log("I am Running");

        if (!info.Exists)
        {
            DebugText.instance.Log("File not exists");
            WriteJson.instance.writeDefaultJson(spath);
            await Task.Delay(500);
            ReadJson.instance.readJson(spath);
        }
        else
        {
            await Task.Delay(500);
            DebugText.instance.Log("File exists");
            ReadJson.instance.readJson(spath);
        }
    }


}
