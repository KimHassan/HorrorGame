using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    AudioSource musicPlayer;

    AudioClip normal_BGM;

    AudioClip monster_BGM;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = gameObject.GetComponent<AudioSource>();

        

        normal_BGM = Resources.Load<AudioClip>("Sound/normal_BGM");

        musicPlayer.PlayOneShot(normal_BGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBgm(string _fileName)
    {
        normal_BGM = Resources.Load<AudioClip>("Sound/" + _fileName);

        musicPlayer.Stop();

        musicPlayer.PlayOneShot(normal_BGM);
    }
}
