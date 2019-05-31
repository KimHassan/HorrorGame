using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDigitalClock : MonoBehaviour
{
    [SerializeField]
    private GameObject clock;
    private TextMesh textMeshClock = null;

    [SerializeField]
    private float clockTime = 0;
    
    public CsDigitalClock(int _second)
    {
        clockTime = _second;
    }

    // Start is called before the first frame update
    void Start()
    {
        textMeshClock = clock.GetComponent<TextMesh>();
        
        StartTimeCounting();
    }

    // Update is called once per frame
    void Update()
    {
        int minute = (int)(clockTime / 60);
        int second = (int)(clockTime % 60);
        
        textMeshClock.text = string.Format("{0:D2}:{1:D2}", minute, second);
    }

    public void StartTimeCounting()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (clockTime > 0)
        {
            clockTime -= 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        yield break;
    }

}
