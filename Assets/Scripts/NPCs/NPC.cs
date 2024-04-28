using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus;

public class NPC : MonoBehaviour
{
    public enum Goal {Idle, Walk, Pray, Donate} 

    [SerializeField] private Goal goal = Goal.Idle;

    [SerializeField] private float donateChance = 50;
    [SerializeField] private float donateMin = 1, donateMax = 5;

    private NavMeshAgent2D agent = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent2D>();
    }

    void Start()
    {
        LookForGoal();
    }

    private void LookForGoal()
    {
        agent.SetDestination(new Vector2(10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
