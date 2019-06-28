using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDrug : CsObject
{
    public delegate void ItemActive();

    public ItemActive itemActive = null;

    AudioSource audioSource;

    private void Awake()
    {
        itemActive = DestroyItem;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
    }
    void Update()
    {

    }

    void DestroyItem()
    {
        //Time 증가 함수 넣어주기
        Destroy(this.gameObject);
    }

    public override void InitObject()
    {

    }

    public override void Active()
    {
        CsUIControll.instance.ChangeText("알약을 얻었다.");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<CsPlayer>().CameraVolume = CsPlayer.CAMERA_VOLUME.CAMERA_FILL;

        player.GetComponent<CsPlayer>().PlaySoundEffect("DrugSound");

        player.GetComponent<CsPlayer>().PlaySoundEffect("HeartBounce");
        itemActive();
    }

    public override void RayCast()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0017f);
    }

}
