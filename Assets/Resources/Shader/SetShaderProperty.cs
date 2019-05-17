using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderProperty : MonoBehaviour
{
    public Material mat;
    public string propertyName;
    public Transform obj;

    // Update is called once per frame
    void Update()
    {
        if (obj != null)
            mat.SetVector(propertyName, obj.position);
        else
            Debug.Log("Assign the obj property");
    }
}
