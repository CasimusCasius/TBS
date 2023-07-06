using BTS.Core;
using UnityEngine;

namespace BTS.Units
{
    public class Unit : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float stoppingDistance = 0.1f;
        [SerializeField] private Animator animator = null;

        private Vector3 targetPosition;

        private void Awake()
        {
            targetPosition = transform.position;
        }
        private void Update()
        {
            MovingToTargetPosition();
        }

        public void SetMoveTarget(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }

        private void MovingToTargetPosition()
        {
            if (DistanceToTarget() > stoppingDistance)
            {
                StartMove();
                StartWalkAnimation(true);
            }
            else
            {
                StopMove();
                StartWalkAnimation(false);
            }
        }

        private void StartWalkAnimation(bool isWalking)
        {
            animator.SetBool("isWalking", isWalking);
        }

        private void StopMove()
        {
            transform.position = targetPosition;
        }

        private void StartMove()
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
        }

        private float DistanceToTarget()
        {
            return Vector3.Distance(targetPosition, transform.position);
        }


    }
}
