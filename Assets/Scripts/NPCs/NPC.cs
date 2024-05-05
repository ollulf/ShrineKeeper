using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus;
using Sirenix.OdinInspector;

public class NPC : MonoBehaviour
{
    private List <Action> actionsequence = new();

    [ShowInInspector] private int actionIndex = 0;

    NavMeshAgent2D agent = null;
    public NavMeshAgent2D Agent => agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent2D>();

        actionsequence.Add(new Wait(5));
        actionsequence.Add(new GoToRandom(this, 4));
        actionsequence.Add(new Wait(4));
        actionsequence.Add(new TryInteract(this, typeof(PrayingShrine)));
        actionsequence.Add(new GoToRandom(this, 4));
        actionsequence.Add(new Wait(4));
    }

    void Start()
    {
        if (actionsequence.Count == 0)
            Destroy(gameObject);

        StartCoroutine(ChooseNextInteraction());
    }

    //Defines the NPC behaviour
    private IEnumerator ChooseNextInteraction()
    {
        yield return StartCoroutine(actionsequence[actionIndex].StartActionRoutine(this));

        OnInteractionFinished();
    }

    private void OnInteractionFinished()
    {
        actionIndex++;

        if(actionsequence.Count == actionIndex)
        {
            Debug.Log("Action Sequence done, leaving now.");

            StartCoroutine( new TryInteract(this, typeof(NPCSpawnPoint)).StartActionRoutine(this));

            return;
        }

        StartCoroutine(ChooseNextInteraction());
    }
}
