﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectActiveItem : MonoBehaviour //
{
    //오브젝트에 스크립트 추가
    // 태그를 activeItem으로 변경

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        CsGameManager.instance.GetItem();
        Destroy(this.gameObject);
    }
}
