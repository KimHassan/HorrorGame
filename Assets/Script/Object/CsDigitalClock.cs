﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDigitalClock : MonoBehaviour
{
    [SerializeField]
    private GameObject clock;
    [SerializeField]
    private GameObject text;

    private TextMesh textMeshClock = null;

    private AudioSource audio;
    private CsObjectActiveItem activeItem = null;

    [SerializeField]
    private float clockTime = 0;

    private bool mute;

    public bool Mute
    {
        get => mute;
        set
        {
            mute = value;
            audio.mute = value;
        }
    }

    public float ClockTime { get => clockTime; set => clockTime = value; }
    public GameObject Text { get => text; set => text = value; }

    public void ActiveClock()
    {
        Mute = true;
        Text.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        textMeshClock = Text.GetComponent<TextMesh>();
        audio = clock.GetComponent<AudioSource>();
        Mute = true;

        activeItem = clock.GetComponent<CsObjectActiveItem>();
        activeItem.itemActive = ActiveClock;
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int minute = (int)(ClockTime / 60);
        int second = (int)(ClockTime % 60);
        
        textMeshClock.text = string.Format("{0:D2}:{1:D2}", minute, second);
    }

    public void StartTimeCounting(float time)
    {
        clockTime = time;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (ClockTime > 0)
        {
            ClockTime -= 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        if (text.activeSelf == false)
            yield break;
        Mute = false;
        StartCoroutine(SpawnTimer());
        yield break;
    }

    IEnumerator SpawnTimer()
    {
        while(Mute == false)
        {
            CsGameManager.instance.MonsterSpawnTime -= 1;
            yield return new WaitForSeconds(1.0f);
        }
        yield break;
    }


}
