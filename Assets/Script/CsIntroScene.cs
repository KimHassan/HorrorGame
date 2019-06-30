using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CsIntroScene : MonoBehaviour
{

    public GameObject Drug;

    public Image Eyes;

    AudioSource audio;

    public AudioClip drugSound;

    public AudioClip drugSound2;

    public AudioClip badSound;

    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EatDrug()
    {
        Destroy(Drug);

        audio.PlayOneShot(drugSound);
        audio.PlayOneShot(drugSound);

    }

    public void CloseBad()
    {
        audio.PlayOneShot(badSound);
    }

    public void CloseEyes()
    {
        StartCoroutine("AlphaDown");
    }

    IEnumerator AlphaDown()
    {
        while(Eyes.color.a < 1)
        {
            Color c = Eyes.color;
            c.a += 0.01f;
            Eyes.color = c;
            yield return null;
        }

        SceneManager.LoadScene("MainScene");

        
    }
}
