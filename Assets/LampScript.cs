using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    private Material rampMat = null;
    private MeshRenderer renderer = null;

    public GameObject lampLight = null;
    public Texture2D texture = null;
    public Rect rect;
    private Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rampMat = renderer.materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LampCoroutine());
    }

    IEnumerator LampCoroutine()
    {
        float time = 0;
        while (true)
        {
            time += Time.deltaTime;
            if (texture.GetPixel((int)time, 10).r == 0)
            {
                lampLight.SetActive(false);
            }
            else
                lampLight.SetActive(true);
        }
    }
}
