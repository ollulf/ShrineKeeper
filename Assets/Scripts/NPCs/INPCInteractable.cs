using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCInteractable
{
    public IEnumerator Interact(NPC npc);
    public Transform [] GetInteractionLocations(); 
}
