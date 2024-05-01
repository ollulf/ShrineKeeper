using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayingShrine : MonoBehaviour, INPCInteractable
{
    [SerializeField] private Transform [] interactLocations;

    void Start ()
    {
        NPCInteractableManager.Register(this);
    }
    public Transform[] GetInteractionLocations()
    {
        return interactLocations;
    }

    public void Interact(NPC npc)
    {
        ResourceHandler.AddResource(Resource.Type.Faith, 10);
    }
}
