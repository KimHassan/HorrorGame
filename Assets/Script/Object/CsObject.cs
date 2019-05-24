using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);

    }

    public virtual void Active()
    {

    }

    public void RayCast()
    {
       gameObject.GetComponent<Renderer>().material.SetFloat("_Outline",0.001f);


    }
}
