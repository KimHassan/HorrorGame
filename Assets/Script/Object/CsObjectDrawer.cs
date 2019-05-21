using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DrawerFloor
{

  public GameObject Floor;

    Vector3 originPos;
    Vector3 destPos;
    bool isOpen;

    public void Init(Vector3 _origin,Vector3 _dest)
    {
        originPos = _origin;
        destPos = _dest;
        isOpen = false;
    }
};

public class CsObjectDrawer : MonoBehaviour
{
    DrawerFloor[] floor = new DrawerFloor[3];


    // Start is called before the first frame update
    void Start()
    {

    }
}
