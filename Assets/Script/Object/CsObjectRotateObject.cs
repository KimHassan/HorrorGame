using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectRotateObject : CsObject
{
    public Vector3 destVec;

    Quaternion originRot;

    Quaternion destRot;

    Quaternion destination;

    bool isOpen;

    float moveSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        originRot = transform.localRotation;

        destRot = transform.localRotation;

        destRot = Quaternion.Euler(destVec);

        destination = destRot;

        isOpen = false;

    }

    // Update is called once per frame

    public override void Active()
    {
       //transform.localRotation = destination;

         StartCoroutine("RotateObject");
       // Debug.Log(transform.localRotation);
       // Debug.Log(destination);
    }

    IEnumerator RotateObject()
    {
        if (isOpen)
            destination = originRot;
        else
            destination = destRot;

        isOpen = !isOpen;

        while (transform.localRotation != destination)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, destination, moveSpeed * Time.deltaTime);

            yield return null;
        }

    }

}
