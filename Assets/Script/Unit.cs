using BTS.Core;
using UnityEngine;

namespace BTS
{
    public class Unit : MonoBehaviour
    {
       
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float stoppingDistance = 0.1f;

        private Vector3 targetPosition;
        private MouseToWorldPosition mousePosition;

        private void Start()
        {
            mousePosition = FindObjectOfType<MouseToWorldPosition>();
        }
        private void Update()
        {
            StartMoveToTarget();
            StopMovingWhenTargetReached();
        }

        private void StartMoveToTarget()
        {
            if (mousePosition != null && Input.GetMouseButtonDown(0))
            {
                Move(mousePosition.GetMousePosition());
            }
        }

        private void StopMovingWhenTargetReached()
        {
            if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
            {
                Vector3 moveDirection = (targetPosition - transform.position).normalized;
                transform.position += moveDirection * Time.deltaTime * moveSpeed;
            }
            else
            {
                transform.position = targetPosition;
            }
        }

        private void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    } 
}
