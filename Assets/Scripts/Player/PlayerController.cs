using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float MoveSpeed = 5f;

        public Rigidbody2D rb;
        public Animator animator;

        private Vector2 mMovement;

        void Update()
        {
            mMovement.x = Input.GetAxisRaw("Horizontal");
            mMovement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", mMovement.x);
            animator.SetFloat("Vertical",mMovement.y);
            animator.SetFloat("Speed",mMovement.sqrMagnitude);
        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + mMovement * MoveSpeed * Time.fixedDeltaTime);
        }
    }
}
