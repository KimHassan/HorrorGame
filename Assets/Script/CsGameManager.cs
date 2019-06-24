using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class CsGameManager : MonoBehaviour
{
    static public CsGameManager instance;

    public GameObject player;

    public GameObject Lights;

    public CsUIControll UI;
    
    public GameObject monster = null;
    private CsMonster csMonster;

    [SerializeField]
    private float monsterSpawnTime = 0;

    float time = 0;
    float eventTime = 0;

    bool isMonsterAwake = false;

    private CsDigitalClock activeClock = null;

    private GAME_STATE gameState = new GAME_USUALLY();

    // Property
    public float MonsterSpawnTime { get => monsterSpawnTime; set => monsterSpawnTime = value; }
    public GAME_STATE GameState { get => gameState; set => gameState = value; }
    public float Time { get => time; set => time = value; }

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
        GameState.Update(this);
    }


    public GameObject AddDigitalClock(int time = 0)
    {
        GameObject[] clock = GameObject.FindGameObjectsWithTag("Clock");

        int index = Random.Range(0, clock.Length - 1);
        activeClock = clock[index].GetComponent<CsDigitalClock>();

        activeClock.GetComponentInChildren<Text>();
        activeClock.StartTimeCounting(time);

        return activeClock.gameObject;
    }

    public void MonsterAwake()
    {
        monster.SetActive(true);
        isMonsterAwake = true;
        GameObject[] clockList = GameObject.FindGameObjectsWithTag("Clock");
        monster.transform.position = activeClock.transform.position;
        activeClock.GetComponent<CsDigitalClock>().Mute = true;
        monster.transform.LookAt(player.transform);
    }
}

public interface GAME_STATE
{
    void Update(CsGameManager manager);
}

public class GAME_USUALLY : GAME_STATE
{
    public void Update(CsGameManager manager)
    {
        manager.Time += UnityEngine.Time.deltaTime;

        if ((int)manager.Time % 30 == 0)
        {
            manager.AddDigitalClock(5);

            manager.GameState = new MONSTER_WAITING();
        }
    }
}

public class MONSTER_WAITING : GAME_STATE
{
    public void Update(CsGameManager manager)
    {
        if (manager.MonsterSpawnTime < 0 && manager.monster.activeSelf == false)
        {
            manager.MonsterAwake();

            manager.GameState = new MONSTER_ACTIVE();
        }
    }
}

public class MONSTER_ACTIVE : GAME_STATE
{
    public void Update(CsGameManager manager)
    {

    }
}
