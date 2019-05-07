using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsGameManager : MonoBehaviour
{

    static public CsGameManager instance;

    public GameObject player;

    public GameObject Lights;

    public CsUIControll UI;

    int itemCount = 0;

    int maxItemCount = 3;
    enum EV_TIME
    {
        EV_NORMAL,
        EV_READY,
        EV_DARK
    }

    float time = 0;

    float eventTime = 0;

    EV_TIME stateEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       

        stateEvent = EV_TIME.EV_NORMAL;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > eventTime)
        {
            SetEvent();
        }
        
    }

    void SetEvent()
    {
        switch(stateEvent)
        {
            case EV_TIME.EV_NORMAL: // 평상시

                setNormalEvent();

                stateEvent = EV_TIME.EV_READY;

                eventTime = Random.Range(10,20);

                break;

            case EV_TIME.EV_READY: // 잡소리 많이 들림

                setReadyEvent();

                stateEvent = EV_TIME.EV_DARK ;

                eventTime = Random.Range(10, 20);

                break;

            case EV_TIME.EV_DARK: // 어두워지고 귀신 등장

                setDarkEvent();

                stateEvent = EV_TIME.EV_NORMAL;

                eventTime = Random.Range(10, 20);

                break;
        }

        time = 0;
    }

    void setNormalEvent()
    {
        Lights.SetActive(true);
    }

    void setReadyEvent()
    {

    }
    void setDarkEvent()
    {
        Lights.SetActive(false);
    }

    public void GetItem()
    {
        itemCount++;
        UI.ItemText.text = "얻은 아이템 : " + itemCount + "/" + maxItemCount;
    }

}
