using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CsMonster : MonoBehaviour
{
    // 오브젝트 관련
    [SerializeField]
    private GameObject player = null;

    private NavMeshAgent nav = null;

    // 이동 관련
    [SerializeField]
    private List<Vector3> destinationList = new List<Vector3>();
    private int targetPoint = 0;


    public GameObject monsterModel = null;


    public enum MONSTER_STATE
    {
        MONSTER_TRAKING,
        MONSTER_PATROL,
        MONSTER_IDLE
    }
    private MONSTER_STATE moveState = MONSTER_STATE.MONSTER_TRAKING;

    public MONSTER_STATE MoveState
    {
        get
        {
            return moveState;
        }
        set
        {
            moveState = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (MoveState)
        {
            case MONSTER_STATE.MONSTER_TRAKING:
                MonsterTrakingMove();
                break;
            case MONSTER_STATE.MONSTER_PATROL:
                MonsterPatrolMove();
                break;
            default:
                break;
        }
    }

    public void StartTracking()
    {
        MoveState = MONSTER_STATE.MONSTER_TRAKING;

        StartCoroutine("MonsterTrakingEnable");

    }

    void MonsterTrakingMove()
    {
        nav.SetDestination(player.transform.position);
    }

    void MonsterTrakingVisual()
    {

    }

    IEnumerator MonsterTrakingEnable()
    {
        bool isVisual = true;

        float playerToMonster = 0;

        while(MoveState == MONSTER_STATE.MONSTER_TRAKING)
        {
            monsterModel.SetActive(isVisual);

            isVisual = !isVisual;

            float rand = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(rand);
        }
    }

    void MonsterPatrolMove()
    {
        if (Vector3.Distance(transform.position, destinationList[targetPoint]) < 0.1f)
            StartPatrolMove();
        nav.SetDestination(destinationList[targetPoint]);
    }

    private void StartPatrolMove()
    {
        targetPoint += 1;
        if (destinationList.Count <= targetPoint)
            targetPoint = 0;
    }

    public void AttackPlayer(Vector3 playerPos, Vector3 playerFrontVec)
    {
        nav.enabled = false;

        transform.position = playerPos + playerFrontVec * 0.5f;
        transform.Translate(new Vector3(0, -0.1f));

        transform.LookAt(playerPos);

        MoveState = MONSTER_STATE.MONSTER_IDLE;
    }
}