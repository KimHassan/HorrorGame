using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectGenerator : CsObject
{
    public GameObject[] battery = new GameObject[3];

    int count;

    bool isFinish;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        foreach(GameObject obj in battery)
        {
            obj.SetActive(false);
        }

        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active()
    {
        if (isFinish)
            return;
        PutBattery();
    }

    void PutBattery()
    {
        battery[count].SetActive(true);

        count++;

        if(count > 2)
        {
            isFinish = true;
        }
    }


}
