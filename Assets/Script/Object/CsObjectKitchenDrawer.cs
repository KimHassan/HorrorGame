using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectKitchenDrawer : CsObject
{

    Quaternion originRot;

    Quaternion destRot;

    Quaternion destination;

    bool isOpen;

    public bool isLeft;

    float moveSpeed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        originRot = transform.localRotation;

        destRot = transform.localRotation;

        if(isLeft)
            destRot = Quaternion.Euler(new Vector3(0, 0, 90));
       else
            destRot = Quaternion.Euler(new Vector3(0, 0, -90));

        destination = destRot;

        isOpen = false;

    }

    // Update is called once per frame

    public override void Active()
    {
       //transform.localRotation = destination;

         StartCoroutine("OpenKitchenDrawer");
       // Debug.Log(transform.localRotation);
       // Debug.Log(destination);
    }

    IEnumerator OpenKitchenDrawer()
    {
        if (isOpen)
            destination = originRot;
        else
            destination = destRot;

        isOpen = !isOpen;

        var i = 0;
        
        while (transform.localRotation != destination)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, destination, moveSpeed * Time.deltaTime);
            i++;
            yield return null;
        }
        Debug.Log(transform.rotation);
        Debug.Log(destination);
        Debug.Log(i);
    }

}
