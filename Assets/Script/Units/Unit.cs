
using BTS.Core;
using BTS.Grid;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Units
{
    public class Unit : MonoBehaviour, IGridMove
    {

        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float stoppingDistance = 0.1f;
        [SerializeField] private Animator animator = null;

        private Vector3 targetPosition;
        private LevelGrid levelGrid = null;
        private GridPosition currentGridPosition;

        private void Awake()
        {
            targetPosition = transform.position;
        }

        private void Start()
        {
            levelGrid = FindObjectOfType<LevelGrid>();
            currentGridPosition = levelGrid.GetGridPosition(transform.position);
            AddUnitAtGridPosition(currentGridPosition, this);

        }

        private void Update()
        {
            MovingToTargetPosition();
        }

        public void SetMoveTarget(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
        public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = levelGrid.GetGridObject(gridPosition);
            gridObject.AddUnit(this);
        }

        public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = levelGrid.GetGridObject(gridPosition);
            return gridObject.GetUnitList();
        }

        public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = levelGrid.GetGridObject(gridPosition);
            gridObject.RemoveUnit(this);
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
            GridPosition newGridPosition = levelGrid.GetGridPosition(transform.position);

            if (newGridPosition != currentGridPosition)
            {
                UnitMoveGridPosition(newGridPosition);
                currentGridPosition = newGridPosition;
            }
        }

        private void UnitMoveGridPosition(GridPosition newGridPosition)
        {
            RemoveUnitAtGridPosition(currentGridPosition, this);
            AddUnitAtGridPosition(newGridPosition, this);
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
