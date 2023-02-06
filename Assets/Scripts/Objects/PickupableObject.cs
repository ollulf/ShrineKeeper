using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class PickupableObject : InteractableObject
    {
        public override List<IInteractable.Interactions> GetInteractOptions()
        {
            var interactionsList = base.GetInteractOptions();
            if(!interactionsList.Contains(IInteractable.Interactions.Pickup))
            {
                interactionsList.Add(IInteractable.Interactions.Pickup);
            }

            return interactionsList;
        }
    }
}
