﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsBattery : CsObject
{
    public delegate void ItemActive();

    public ItemActive itemActive = null;


    private void Awake()
    {
        itemActive = DestroyItem;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
    }
    void Update()
    {

    }

    void DestroyItem()
    {

        Destroy(this.gameObject);
    }

    public override void InitObject()
    {
        Debug.Log("I'm okay");
    }

    public override void Active()
    {
        GameObject.FindWithTag("Player").GetComponent<CsPlayer>().batteryHaving += 1;


        CsGameManager.instance.BatteryCount += 1;

        if (GameObject.FindWithTag("Player").GetComponent<CsPlayer>().batteryHaving == 1)
        {
            CsUIControll.instance.ChangeText("배터리를 얻었다. 베란다에 있는 발전기에 넣자");
        }
        else
        {
            CsUIControll.instance.ChangeText("배터리를 얻었다.");
        }
        GameObject.FindWithTag("Player").GetComponent<CsPlayer>().PlaySoundEffect("BatterySound");
        itemActive();
    }

    public override void RayCast()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0017f);
    }
}
