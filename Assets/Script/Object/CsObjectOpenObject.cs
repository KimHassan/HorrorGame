using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectOpenObject : CsObject
{
    public Vector3 plusDestPos;
    Vector3 destPos;
    Vector3 originPos;
    Vector3 destination;

    public float speed;

    bool isOpen;

    AudioSource audioSource;

    public AudioClip openSound;
    public AudioClip closeSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originPos = transform.localPosition;

        destPos = originPos + plusDestPos;

        destination = destPos;

        isOpen = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InitObject()
    {
        transform.localPosition = originPos;

        destination = destPos;

        isOpen = false;

        Debug.Log(name);

    }

    public override void Active()
    {
        StartCoroutine("OpenObject");
    }

    IEnumerator OpenObject()
    {
        if (isOpen)
        {
            destination = originPos;
            audioSource.PlayOneShot(closeSound);
        }
        else
        {
            destination = destPos;
            audioSource.PlayOneShot(openSound);
        }
        isOpen = !isOpen;

        while (destination != transform.localPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed * Time.deltaTime);

            yield return null;
        }
        audioSource.Stop();
    }
}
