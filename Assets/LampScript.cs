using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    private Material rampMat = null;
    private MeshRenderer renderer = null;

    public GameObject lampLight = null;
    public Texture2D texture = null;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rampMat = renderer.materials[0];

        time = Time.time;
        //StartCoroutine(LampCoroutine());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (texture.GetPixel((int)((Time.time - time) * 100), 10).r == 0)
        {
            lampLight.SetActive(false);
        }
        else
            lampLight.SetActive(true);
    }

    private void FixedUpdate()
    {
    }

    //IEnumerator LampCoroutine()
    //{
    //    float time = 0;

    //    while (true)
    //    {
    //        time += 1;
    //        if (texture.GetPixel((int)time, 10).r == 0)
    //        {
    //            lampLight.SetActive(false);
    //        }
    //        else
    //            lampLight.SetActive(true);

    //        yield return new WaitForSeconds(Time.deltaTime);
    //    }
    //}
}
