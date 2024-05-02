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

    public IEnumerator Interact(NPC npc)
    {
        ResourceHandler.AddResource(Resource.Type.Faith, 10);

        Debug.Log(npc + " interacted with " + this);

        yield break;
    }
}
