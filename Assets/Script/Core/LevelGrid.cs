
using BTS.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Core
{
	public class LevelGrid : MonoBehaviour
	{
        [SerializeField] private Transform gridDebugObjectPrefab;

        private GridSystem gridSystem;
        //private MouseToWorldPosition mousePosition;

        private void Awake()
        {

            gridSystem = new GridSystem(10, 10, 2f);
            //mousePosition = FindObjectOfType<MouseToWorldPosition>();

            gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
        }


        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return gridSystem.GetGridObject(gridPosition);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return gridSystem.GetGridPosition(worldPosition);
        }
       


    }
}