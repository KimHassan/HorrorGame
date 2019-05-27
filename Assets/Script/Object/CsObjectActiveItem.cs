using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectActiveItem : CsObject //
{
    //오브젝트에 스크립트 추가
    // 태그를 activeItem으로 변경


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

    public override void Active()
    {
        Destroy(this.gameObject);
    }

    public override void RayCast()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.001f);
    }
}
