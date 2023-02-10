using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float MoveSpeed = 5f;

        public Rigidbody2D rb;
        public Animator animator;
        public Transform PickupTransform;

        [SerializeField]
        private ContactFilter2D interactionContactFilter;
        private Vector2 mMovement;

        private GameObject heldItem;

        void Update()
        {
            mMovement.x = Input.GetAxisRaw("Horizontal");
            mMovement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", mMovement.x);
            animator.SetFloat("Vertical",mMovement.y);
            animator.SetFloat("Speed",mMovement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (heldItem != null)
                {
                    DropItem(heldItem);
                }
                else
                {
                    var listOfOverlapColliders = new Collider2D[20];
                    if (rb.OverlapCollider(interactionContactFilter, listOfOverlapColliders) > 0)
                    {
                        if (listOfOverlapColliders.Any(c => c.gameObject.GetComponent<PickupableObject>()))
                        {
                            var itemToPickUp =
                                listOfOverlapColliders.First(c => c.gameObject.GetComponent<PickupableObject>());
                            PickUpItem(itemToPickUp.gameObject);
                        }
                    }
                }
            }
        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + mMovement * MoveSpeed * Time.fixedDeltaTime);
        }

        public void PickUpItem(GameObject objectToPickUp)
        {
            objectToPickUp.transform.position = PickupTransform.position;
            objectToPickUp.transform.parent = PickupTransform;
            heldItem = objectToPickUp;
        }

        public void DropItem(GameObject objectToDrop)
        {
            objectToDrop.transform.parent = null;
            objectToDrop.GetComponent<ObjectLayerer>().UpdateLayering();
            heldItem = null;
        }
    }
}
