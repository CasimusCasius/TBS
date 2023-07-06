using BTS.Core;
using UnityEngine;

namespace BTS
{
    public class Unit : MonoBehaviour
    {
       
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float stoppingDistance = 0.1f;
        [SerializeField] private Animator animator = null;

        private Vector3 targetPosition;
        private MouseToWorldPosition mousePosition;

        private void Start()
        {
            mousePosition = FindObjectOfType<MouseToWorldPosition>();
        }
        private void Update()
        {
            OnMouseClick();
            MovingToTargetPosition();
        }

        private void OnMouseClick()
        {
            if (mousePosition != null && Input.GetMouseButtonDown(0))
            {
                SetMoveTarget(mousePosition.GetMousePosition());
            }
        }

        private void MovingToTargetPosition()
        {
            if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
            {
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                transform.position += moveDirection * Time.deltaTime * moveSpeed;

                transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime* rotationSpeed);

                animator.SetBool("isWalking", true);
            }
            else
            {
                transform.position = targetPosition;
                animator.SetBool("isWalking", false);
            }
        }

        private void SetMoveTarget(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    } 
}
