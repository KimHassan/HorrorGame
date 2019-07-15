﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectGenerator : CsObject
{
    public GameObject[] battery = new GameObject[3];

    CsPlayer Player;

    CsItemManager ItemManager;

    int count;

    bool isFinish;

    AudioSource audioSource;
    
    public AudioClip audioClip;

    // Start is called before the first frame update

    private void Awake()
    {
        ItemManager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<CsItemManager>();

        audioSource = GetComponent<AudioSource>();
        
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


        if (Player.batteryHaving <= 0)
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
        if (Player.batteryHaving <= 0)
            return;

        Player.batteryHaving -= 1;

        Player.PlaySoundEffect("BatteryPut");

        battery[count].SetActive(true);

        count++;

        if (count > 2)
        {
            isFinish = true;

            Player.isAbleEscape = true;

            CsUIControll.instance.ChangeText("도어락이 켜진 거 같다");
            audioSource.PlayOneShot(audioClip);


        }
    }

    void InitAllObject()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ActiveObject");

        foreach(GameObject obj in gameObjects)
        {
            Debug.Log("AAA:" + obj.name +"::::XXXXX");

            if (obj.name == "Localclock" || obj.name == "battery(Clone)")
                continue;

            obj.GetComponent<CsObject>().InitObject();
        }
    }

    public override void InitObject()
    {
        Debug.Log(name);
    }


}
