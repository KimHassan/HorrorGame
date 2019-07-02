using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class CsEndingScene : MonoBehaviour
{
    public GameObject Drug;

    public Image Eyes;

    public AudioClip badSound;

    public AudioClip soomSound;

    public AudioClip crashSound;

    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    void CrashDrug()
    {
        PlayCrashDrugSound();
        Drug.GetComponent<Rigidbody>().AddForce(new Vector3(200, 200, 0), ForceMode.Force);
    }

    void CloseEyes()
    {
        StartCoroutine("AlphaDown2");
    }
    IEnumerator AlphaDown2()
    {
        while (Eyes.color.a < 1)
        {
            Color c = Eyes.color;
            c.a += 0.01f;
            Eyes.color = c;
            yield return null;
        }

        SceneManager.LoadScene("CreditScene");


    }

    void PlayBadSound()
    {
        audio.PlayOneShot(badSound);
    }

    void PlaySoomSound()
    {
        audio.PlayOneShot(soomSound);
    }
    void PlayCrashDrugSound()
    {
        audio.PlayOneShot(crashSound);
    }


}
