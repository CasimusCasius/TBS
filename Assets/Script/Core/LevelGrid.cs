
using BTS.Grid;
using BTS.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Core
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField] private Transform gridDebugObjectPrefab;

        private GridSystem gridSystem;

        private void Awake()
        {
            gridSystem = new GridSystem(10, 10, 2f);

            gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
        }

        public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            gridObject.AddUnit(unit);
        }

        public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            return gridObject.GetUnitList();
        }

        public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            gridObject.RemoveUnit(unit);
        }
        public Vector3 GetWorldPosition(GridPosition gridPosition)=> gridSystem.GetWorldPosition(gridPosition);
        public GridObject GetGridObject(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition);
        public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
        public bool isValidGridPosition(GridPosition gridPosition) => gridSystem.isValidGridPosition(gridPosition);
        public bool HasAnyUnitOnGridPosition(GridPosition gridPosition) => GetGridObject(gridPosition).HasAnyUnit();



    }
}