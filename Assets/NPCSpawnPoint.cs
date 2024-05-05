using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnPoint : MonoBehaviour, INPCInteractable
{
    [SerializeField] private Transform[] interactLocations;

    void Start()
    {
        NPCInteractableManager.Register(this);
    }

    public Transform[] GetInteractionLocations()
    {
        return interactLocations;
    }

    public IEnumerator Interact(NPC npc)
    {
        Destroy(npc.gameObject);
        yield break;
    }
}
