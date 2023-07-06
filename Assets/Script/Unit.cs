using UnityEngine;

namespace BTS
{
    public class Unit : MonoBehaviour
    {
        private Vector3 targetPosition;
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float stoppingDistance = 0.1f;

        private void Update()
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

            if (Input.GetKeyDown(KeyCode.T))
            {
                Move(new Vector3(4, 0, 4));
            }


        }


        private void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    } 
}
