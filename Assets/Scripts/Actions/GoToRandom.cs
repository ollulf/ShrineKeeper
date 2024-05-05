using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToRandom : Action
{
    NavMeshAgent2D m_Agent = null;

    [SerializeField] private float m_WanderDistance = 3;

    private Transform goToTarget = null;

    public GoToRandom (NPC npc ,float wanderDistance)
    {
        m_Agent = npc.Agent;
        m_WanderDistance = wanderDistance;
    }

    public override IEnumerator StartActionRoutine(NPC npc)
    {
        yield return base.StartActionRoutine(npc);
    }

    protected override IEnumerator ActionCoroutine()
    {
        // get random position
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * m_WanderDistance;
        randomDirection += m_Agent.transform.position;

        NavMeshHit hit;
        while (!NavMesh.SamplePosition(randomDirection, out hit, m_WanderDistance, 1))
        {
            randomDirection = UnityEngine.Random.insideUnitSphere * m_WanderDistance;
            randomDirection += m_Agent.transform.position;

            yield return null;
        }

        Vector2 finalPosition = NavMeshUtils2D.ProjectTo2D(hit.position);

        //Debug.Log("Next Go To Position: " + finalPosition);

        m_Agent.SetDestination(finalPosition);

        // wait until reached position
        while (!m_Agent.reachedDestination)
        {
            yield return null;
        }
    }    
}
