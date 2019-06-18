using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsUIControll : MonoBehaviour
{

    public GameObject mainCursor;

    public GameObject handCursor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainCursor.SetActive(true);

        handCursor.SetActive(false);

    }

    public void RayCast()
    {
        mainCursor.SetActive(false);

        handCursor.SetActive(true);
    }
}
