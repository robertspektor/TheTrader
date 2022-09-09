using UnityEngine;

namespace Core
{
    public class Movement : MonoBehaviour
    {
        public float speed = 5f;

        public Animator animator;

        private Vector3 moveDirection;
    
        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(horizontal, vertical).normalized;

            AnimateMovement(moveDirection);
        }

        private void FixedUpdate()
        {
            transform.position += moveDirection * speed * Time.deltaTime;
        }

        void AnimateMovement(Vector3 direction)
        {
            // check if animator is not null
            if (animator != null)
            {
                if (direction.magnitude > 0) {
                    animator.SetFloat("horizontal", direction.x);
                    animator.SetFloat("vertical", direction.y);
                    animator.SetBool("isMoving", true);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }
            }


        }
    }
}
