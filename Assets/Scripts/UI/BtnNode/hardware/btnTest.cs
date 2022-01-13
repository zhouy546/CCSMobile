using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnTest : MonoBehaviour
{
    public List<lightgroupunit> lightgroupunits = new List<lightgroupunit>();

    public void onlight()
    {
        StartCoroutine(onclick());
    }

    public void offlight()
    {
        StartCoroutine(offclick());
    }
    private IEnumerator onclick()
    {
        Debug.Log("灯光开");


        foreach (var item in lightgroupunits)
        {
           // ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item) + 1, lightgroupunits.Count);

            yield return new WaitForSeconds(1.5F);
            item.Onclick();

        }

    }


    private IEnumerator offclick()
    {


        Debug.Log("灯光关");

        foreach (var item in lightgroupunits)
        {
            Debug.Log(lightgroupunits.IndexOf(item));

          //  ProcessBarUpdate.instance.UpdateFill(lightgroupunits.IndexOf(item) + 1, lightgroupunits.Count);

            yield return new WaitForSeconds(1.5F);
            item.OffClick();

        }


    }
}
