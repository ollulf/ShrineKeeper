using System.Collections.Generic;
using Assets.Scripts.Core;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class InteractableObject : MonoBehaviour,IInteractable
    {
        public List<IInteractable.Interactions> Interactions = new List<IInteractable.Interactions>();

        private GameObject OwnInteractionCanvas;
        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"Collided with {col.name}");
            ShowInteractOptions();
        }

        void OnTriggerExit2D(Collider2D col)
        {
            Destroy(OwnInteractionCanvas);
        }

        public virtual List<IInteractable.Interactions> GetInteractOptions()
        {
            return Interactions;
        }
        public void ShowInteractOptions()
        {
            var interactionCanvasPrefab = GameInstance.Current.InteractionCanvasPrefab;

            OwnInteractionCanvas = Instantiate(interactionCanvasPrefab, this.transform);

        }
    }
}
