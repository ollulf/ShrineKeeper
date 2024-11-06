using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class TryInteract : Action
{
    private Type m_type;

    private NavMeshAgent2D agent = null;
    private NPC m_NPC = null;


    public TryInteract (NPC Npc, Type type)
    {
        m_NPC = Npc;
        agent = m_NPC.Agent;
        m_type = type;
    }

    protected override IEnumerator ActionCoroutine()
    {
        var interactable = NPCInteractableManager.GetFirstInteractable(m_type);

        if (interactable == null)
        {
            Debug.Log("Could not find interactable " + m_type + " in level");
            yield break;
        }

        agent.SetDestination(NavMeshUtils2D.ProjectTo2D(interactable.GetInteractionLocations()[0].position));

        while (!agent.reachedDestination)
        {
            //Debug.Log(agent.remainingDistance);

            yield return null;
        }

        yield return m_NPC.StartCoroutine(interactable.Interact(m_NPC));
    }

    public override IEnumerator StartActionRoutine(NPC npc)
    {
        yield return base.StartActionRoutine(npc);
    }

}
