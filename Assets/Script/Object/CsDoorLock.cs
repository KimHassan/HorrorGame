using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDoorLock : CsObject
{
    public GameObject door;

    CsPlayer Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<CsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active()
    {
        if(Player.isAbleEscape)
            door.GetComponent<CsObjectRotateObject>().Active();
    }


}
