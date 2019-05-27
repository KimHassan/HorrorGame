using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectMiniDrawer : CsObject
{
    Vector3 originPos;

    Vector3 destPos;

    Vector3 destination;

    bool isOpen;

    float moveSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.localPosition;

        destPos = originPos;

        destPos.z = 0.1f;

        destination = destPos;

        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Active()
    {
        StartCoroutine("OpenMiniDrawer");
    }
    IEnumerator OpenMiniDrawer()
    {
        if (isOpen)
            destination = originPos;
        else
            destination = destPos;

        isOpen = !isOpen;

        while(destination != transform.localPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, moveSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
