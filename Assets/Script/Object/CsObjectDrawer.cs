using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectDrawer : CsObject
{
    Vector3 originPos;

    Vector3 destPos;

    Vector3 destination;

    float moveSpeed = 0.5f;

    bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        originPos = gameObject.transform.localPosition;

        destPos = originPos;

        destPos.x += 0.2f;

        isOpen = false;

        destination = destPos;
    }

    private void Update()
    {
        

    }

    public override void Active()
    {
        StartCoroutine("OpenDrawer");
    }

    IEnumerator OpenDrawer()
    {
        if (isOpen)
            destination = originPos;
        else
            destination = destPos;

        isOpen = !isOpen;

        while (transform.localPosition != destination)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, moveSpeed * Time.deltaTime);

            yield return null;
        }
       
    }
}
