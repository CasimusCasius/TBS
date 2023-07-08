
using BTS.Actions;
using BTS.Core;
using BTS.Grid;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Units
{
    public class Unit : MonoBehaviour
    {

        private LevelGrid levelGrid = null;
        private GridPosition currentGridPosition;
        private MoveAction moveAction;

        private void Awake()
        {
            moveAction = GetComponent<MoveAction>();
        }

        private void Start()
        {
            levelGrid = FindObjectOfType<LevelGrid>();
            currentGridPosition = levelGrid.GetGridPosition(transform.position);
            levelGrid.AddUnitAtGridPosition(currentGridPosition, this);
        }

        private void Update()
        {

            GridPosition newGridPosition = levelGrid.GetGridPosition(transform.position);

            if (newGridPosition != currentGridPosition)
            {
                UnitMoveGridPosition(newGridPosition);
                currentGridPosition = newGridPosition;
            }
        }

        


        public MoveAction GetMoveAction() => moveAction;
        public GridPosition GetGridPosition()
        {
            return currentGridPosition;
        }

        private void UnitMoveGridPosition(GridPosition newGridPosition)
        {
            levelGrid.RemoveUnitAtGridPosition(currentGridPosition, this);
            levelGrid.AddUnitAtGridPosition(newGridPosition, this);
        }

    }
}
