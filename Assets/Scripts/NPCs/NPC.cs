using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus;

public class NPC : MonoBehaviour
{
    public enum Goal {Idle, Walk, Pray, Donate}


    [Header("Wander Settings")]
    [SerializeField] private int wanderDistance = 2;
    [SerializeField] private int idleTimeMin = 3, idleTimeMax = 10;

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
        TryInteract(typeof(PrayingShrine));
    }

    //Defines the NPC behaviour
    private void ChooseNextInteraction()
    {
        Wander(UnityEngine.Random.Range(idleTimeMin, idleTimeMax));
    }

    private void TryInteract(Type type)
    {
        StartCoroutine(InteractRoutine(type));
    }

    private void Wander (int time)
    {
        StartCoroutine(WanderCoroutine(time));
    }

    //Coroutines

    private IEnumerator WanderCoroutine(int time)
    {
        float elapsedTime = 0;

        // waits until idle time done
        while (time > elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // get random position
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderDistance;
        randomDirection += transform.position;

        NavMeshHit hit;
        while (!NavMesh.SamplePosition(randomDirection, out hit, wanderDistance, 1))
        {
            randomDirection = UnityEngine.Random.insideUnitSphere * wanderDistance;
            randomDirection += transform.position;

            yield return null;
        }

        Vector2 finalPosition = NavMeshUtils2D.ProjectTo2D(hit.position);
        //Debug.Log("Next Go To Position: " + finalPosition);

        agent.SetDestination(finalPosition);

        // wait until reached position
        while (!agent.reachedDestination)
        {
            yield return null;
        }

        elapsedTime = 0;

        // waits until idle time done
        while(time > elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        OnInteractionFinished();
    }

    private IEnumerator InteractRoutine(Type type)
    {
        yield return null;

        var interactable = NPCInteractableManager.GetFirstInteractable(type);

        if (interactable == null)
        {
            Debug.Log("Could not find interactable " + type + " in level");
            OnInteractionFinished();
            yield break;
        }

        agent.SetDestination(interactable.GetInteractionLocations()[0].position);

        while (!agent.reachedDestination)
        {
            //Debug.Log(agent.remainingDistance);

            yield return null;
        }

        Debug.Log(this.name + " reached interact destination");

        yield return StartCoroutine(interactable.Interact(this));

        OnInteractionFinished();
    }


    private void OnInteractionFinished()
    {
        ChooseNextInteraction();
    }
}
