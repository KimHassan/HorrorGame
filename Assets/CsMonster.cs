﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CsMonster : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    private NavMeshAgent nav = null;

    private void Initialize()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        nav.SetDestination(player.transform.position);
    }
}
