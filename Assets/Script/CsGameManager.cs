using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class CsGameManager : MonoBehaviour
{
    static public CsGameManager instance;

    public GameObject player;

    public GameObject Lights;

    public CsUIControll UI;
    
    [SerializeField]
    private GameObject monster = null;
    private CsMonster csMonster;

    [SerializeField]
    private List<GameObject> clockList = new List<GameObject>();

    public GameObject ClockList{set => clockList.Add(value); }

    [SerializeField]
    private GameObject clockPrefab = null;

    [SerializeField]
    private float monsterSpawnTime = 0;
    public float MonsterSpawnTime { get => monsterSpawnTime; set => monsterSpawnTime = value; }

    int itemCount = 0;

    int maxItemCount = 3;

    float time = 0;
    float eventTime = 0;

    bool isMonsterAwake = false;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(this);
        csMonster = monster.GetComponent<CsMonster>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(MonsterSpawnTime < 0 && monster.activeSelf == false)
        {
            MonsterAwake();
        }
    }

    public GameObject GetClock(int number)
    {
        return clockList[number];
    }

    public GameObject AddDigitalClock(int time = 0)
    {
        GameObject clock = Instantiate(clockPrefab);
        CsDigitalClock digitalClock = clock.GetComponent<CsDigitalClock>();
        digitalClock.ClockTime = time;
        return clock;
    }

    public void MonsterAwake()
    {
        monster.SetActive(true);
        isMonsterAwake = true;
        for(int i = 0; i < clockList.Count; i++)
        {
            GameObject clock = clockList[i];
            monster.transform.position = clock.transform.position;
            clock.GetComponent<CsDigitalClock>().Mute = true;
        }
        monster.transform.LookAt(player.transform);
    }

}
