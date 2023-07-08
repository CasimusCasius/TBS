
using BTS.Core;
using BTS.Grid;
using BTS.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Actions
{
    public class MoveAction : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float stoppingDistance = 0.1f;
        [SerializeField] private Animator animator = null;

        [SerializeField] private int maxMoveDistance = 4;

        private Unit unit;
        private Vector3 targetPosition;
        private LevelGrid levelGrid;

        private void Awake()
        {

            targetPosition = transform.position;
            unit = GetComponent<Unit>();
            
        }
        private void Start()
        {
            levelGrid = FindObjectOfType<LevelGrid>();
        }

        private void Update()
        {
            MovingToTargetPosition();
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
        public bool IsValidGridPosition(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
            return validGridPositionList.Contains(gridPosition);
        }

        public List<GridPosition> GetValidActionGridPositionList()
        {
            var validGridPositionList = new List<GridPosition>();
            GridPosition unitGridPosition = unit.GetGridPosition();

            for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
            {
                for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
                {
                    GridPosition offsetGridPosition = new GridPosition(x, z);
                    GridPosition testGridPosition = unitGridPosition + offsetGridPosition;
                    if (!levelGrid.isValidGridPosition(testGridPosition)) continue;
                    if (unitGridPosition == testGridPosition) continue;
                    if (levelGrid.HasAnyUnitOnGridPosition(testGridPosition)) continue;
                    validGridPositionList.Add(offsetGridPosition);
                }
            }
            return validGridPositionList;
        }

        public void SetMoveTarget(GridPosition targetPosition)
        {
            this.targetPosition = levelGrid.GetWorldPosition(targetPosition);
        }

        private void StartMove()
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
        }

        private void StartWalkAnimation(bool isWalking)
        {
            animator.SetBool("isWalking", isWalking);
        }

        private void StopMove()
        {
            transform.position = targetPosition;
        }

        private float DistanceToTarget()
        {
            return Vector3.Distance(targetPosition, transform.position);
        }
    }
}