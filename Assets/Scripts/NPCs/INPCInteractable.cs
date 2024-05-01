using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCInteractable
{
    public void Interact(NPC npc);
    public Transform [] GetInteractionLocations(); 
}
