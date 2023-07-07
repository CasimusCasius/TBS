using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Grid
{
	public class GridObject
	{
		private GridSystem gridSystem;
		private GridPosition gridPosition;

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;   
        }
    } 
}
