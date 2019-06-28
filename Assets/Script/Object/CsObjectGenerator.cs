using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectGenerator : CsObject
{
    public GameObject[] battery = new GameObject[3];

    CsPlayer Player;

    CsItemManager ItemManager;

    int count;

    bool isFinish;
    // Start is called before the first frame update

    private void Awake()
    {
        ItemManager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<CsItemManager>();
    }
    void Start()
    {
        count = 0;

        foreach(GameObject obj in battery)
        {
            obj.SetActive(false);
        }

        isFinish = false;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active()
    {
        if (isFinish)
        {
            return;
        }


        if (Player.isBatteryHaving == false)
        {
            CsUIControll.instance.ChangeText("배터리를 가지고 있지 않다.");
            return;
        }
        PutBattery();

        InitAllObject();

        ItemManager.AddBatteryItems();

        ItemManager.AddDrugItems();

    }

    void PutBattery()
    {
        Player.isBatteryHaving = false;

        Player.PlaySoundEffect("BatterySound");

        battery[count].SetActive(true);

        count++;

        if (count > 2)
        {
            isFinish = true;

            Player.isAbleEscape = true;
        }
    }

    void InitAllObject()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ActiveObject");

        foreach(GameObject obj in gameObjects)
        {
            Debug.Log("first:" + obj.name +"in");

            if (obj.name == "Localclock")
                continue;

            obj.GetComponent<CsObject>().InitObject();
        }
    }

    public override void InitObject()
    {
        Debug.Log(name);
    }


}
