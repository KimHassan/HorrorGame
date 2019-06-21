using System.Collections;
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
        GameObject.FindWithTag("Player").GetComponent<CsPlayer>().isBatteryHaving = true;
        Destroy(this.gameObject);
    }

    public override void InitObject()
    {

    }

    public override void Active()
    {
        CsUIControll.instance.ChangeText("배터리를 얻었다.");
        itemActive();
    }

    public override void RayCast()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0017f);
    }
}
