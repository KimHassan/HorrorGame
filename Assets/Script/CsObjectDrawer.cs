using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectDrawer : MonoBehaviour
{
    Vector3 originPos;

    Vector3 destPos;


    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.localPosition;

        destPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
