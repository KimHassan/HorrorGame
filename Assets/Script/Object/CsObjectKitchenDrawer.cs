using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectKitchenDrawer : MonoBehaviour
{

    Quaternion LeftOriginRot;

    Quaternion LeftDestRot;

    // Start is called before the first frame update
    void Start()
    {
        LeftOriginRot = transform.rotation;
        LeftDestRot = transform.rotation;
        LeftDestRot.z += 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
