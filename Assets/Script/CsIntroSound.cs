using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CsIntroSound : MonoBehaviour
{

    AudioSource audioSource;

    AudioClip[] sounds;

    int max = 5;

    int index = 0;

    public Image sightImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sounds = new AudioClip[max];
        
        for(int i=0;i<max;i++)
        {
            sounds[i] = Resources.Load<AudioClip>("Sound/IntroSound/IntroSound_" + i.ToString());
        }

        StartCoroutine("PlaySound");
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
    }


    IEnumerator PlaySound()
    {
        while (index < max)
        {
            if (audioSource.isPlaying == false)
            {
                if(index == 3)
                {
                    sightImage.color = new Color(0, 0, 0);
                }
                audioSource.PlayOneShot(sounds[index]);

                index++;

                yield return new WaitForSeconds(2);
               
            }

            yield return null;
        }

        SceneManager.LoadScene("MainScene");
    }
}
