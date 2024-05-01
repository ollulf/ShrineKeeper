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
        PrayingRoutine();
    }

    private void PrayingRoutine()
    {
        var interactable = NPCInteractableManager.GetFirstInteractable(typeof(PrayingShrine));

        if (interactable == null)
            return;

        agent.SetDestination(interactable.GetInteractionLocations()[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
